using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public ParticleSystem particle1;
    public ParticleSystem particle2;
    public ParticleSystem particle3;
    private ParticleSystem bonusParticle;
    private ParticleSystem dangerParticle;
    private ParticleSystem ordinaryParticle;

    Vector2 spawnPos;


    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * GameManager.instance.playerSpeed * Time.deltaTime);
        if (transform.position.y > 4.3f)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            ordinaryParticle = Instantiate(particle3, collision.gameObject.transform.position, Quaternion.identity);
            ordinaryParticle.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            FindObjectOfType<AudioManager>().Play("StoneBreak");
            Destroy(collision.gameObject);
            Destroy(gameObject);
            GameManager.instance.increaseScore(10);
            ordinaryParticle.Play();
            Destroy(ordinaryParticle.gameObject, 0.5f);
        }
        else if (collision.gameObject.tag == "Bonus")
        {
            bonusParticle = Instantiate(particle2, collision.gameObject.transform.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("FireballExplode");
            Destroy(collision.gameObject);
            Destroy(gameObject);
            GameManager.instance.healthBar.IncreaseHealth(15);
            GameManager.instance.increaseScore(20);
            bonusParticle.Play();
            Destroy(bonusParticle.gameObject, 0.5f);
        }
        else if (collision.gameObject.tag == "Danger")
        {
            dangerParticle = Instantiate(particle1, collision.gameObject.transform.position, Quaternion.identity);
            dangerParticle.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
            FindObjectOfType<AudioManager>().Play("BarrelExplode");
            Destroy(collision.gameObject);
            Destroy(gameObject);
            GameManager.instance.increaseScore(30);
            dangerParticle.Play();
            Destroy(dangerParticle.gameObject, 0.5f);
        }
    }
}
