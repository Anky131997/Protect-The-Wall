using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Destroy(collision.gameObject);
            GameManager.instance.healthBar.DeductHealth(10);
            GameManager.instance.decreaseScore(5);
        }
        else if (collision.gameObject.tag == "Danger")
        {
            Destroy(collision.gameObject);
            GameManager.instance.healthBar.DeductHealth(30);
            GameManager.instance.decreaseScore(30);
        }
        else if (collision.gameObject.tag == "Bonus")
        {
            Destroy(collision.gameObject);
            GameManager.instance.healthBar.DeductHealth(20);
            GameManager.instance.decreaseScore(10);
        }
    }
}
