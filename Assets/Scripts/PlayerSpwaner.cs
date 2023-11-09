using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerSpwaner : MonoBehaviour
{
    public GameObject player;
    Vector2 spawnPos;
    public ParticleSystem particle;
    private ParticleSystem ps;

    // Start is called before the first frame update

    private void Awake()
    {
        /*ps = Instantiate(particle, spawnPos, Quaternion.identity);*/
    }
    void Start()
    {
        spawnPos = new Vector2(transform.position.x, transform.position.y);
        /*spawnRate = 0.8f;*/
        StartCoroutine("SpawnObstacles");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameOver)
        {
            StopCoroutine("SpawnObstacles");
        }
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            Spawn();

            /*ps.Play();*/

            yield return new WaitForSeconds(GameManager.instance.playerSpawnRate);
        }
    }

    void Spawn()
    {
        Instantiate(player, spawnPos, transform.rotation);
        ps = Instantiate(particle, spawnPos, Quaternion.identity);
        FindObjectOfType<AudioManager>().Play("CannonShooting");
        ps.transform.position = new Vector3(transform.position.x, -3.41f, transform.position.z);
        ps.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        ps.Play();
        Destroy(ps.gameObject, 1f);

    }

    void OnMouseDrag()
    {
        Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        MousePos.z = transform.position.z;
        float xClamp = Mathf.Clamp(MousePos.x, -2.10f, 2.10f);
        transform.position = new Vector3(xClamp, transform.position.y, transform.position.z);
        Vector2 newPos = new Vector2(transform.position.x, transform.position.y);
        spawnPos = newPos;
    }
}
