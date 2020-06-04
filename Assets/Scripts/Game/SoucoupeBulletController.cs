using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoucoupeBulletController : MonoBehaviour
{
    public Transform target;

    public GameObject explosion;
    
    private Rigidbody2D Rigidbody;

    public float speed = 15f;
    public float rotatespeed = 200f;
    public float GameDifficulty;
    
    // Start is called before the first frame update
    void Start()
    {
        difficulty();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        difficulty();
        BulletTarget();
    }

    public void difficulty()
    {
        if (PlayerPrefs.GetInt("GameDifficulty") == 1)
        {
            GameDifficulty = 1;
        }
        else if (PlayerPrefs.GetInt("GameDifficulty") == 2)
        {
            GameDifficulty = 2;
        }
        else if (PlayerPrefs.GetInt("GameDifficulty") == 3)
        {
            GameDifficulty = 3;
        }
    }

    void BulletTarget()
    {
        Vector2 direction = (Vector2)target.position - Rigidbody.position;
        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        Rigidbody.angularVelocity = -rotateAmount * rotatespeed;

        Rigidbody.velocity = transform.up * (speed * GameDifficulty);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag =="plateforme" || collision.gameObject.tag == "PowerLaser" || collision.gameObject.tag == "PlayerBullet" || collision.gameObject.tag == "BallThunder")
        {
            Instantiate(explosion, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -2), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
