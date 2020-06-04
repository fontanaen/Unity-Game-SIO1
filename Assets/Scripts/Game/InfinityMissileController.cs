using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinityMissileController : MonoBehaviour
{
    public GameObject Explosion;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Instantiate(Explosion, new Vector3(collision.transform.position.x, collision.transform.position.y, -2), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
