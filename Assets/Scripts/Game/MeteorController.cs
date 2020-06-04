using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    public GameObject Impact;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "plateforme")
        {
            Instantiate(Impact, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y-10, -2), Quaternion.identity);
            Destroy(gameObject, 0.1f);
        }
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "BallThunder")
        {
            Destroy(gameObject);
        }
    }
}
