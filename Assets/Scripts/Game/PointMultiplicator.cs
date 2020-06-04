using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointMultiplicator : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject.Find("SpawnBonus").GetComponent<SpawnBonus>().DoublePoint = true;
            gameObject.transform.eulerAngles = new Vector2(90, 0);
            yield return new WaitForSeconds(20f);
            GameObject.Find("SpawnBonus").GetComponent<SpawnBonus>().DoublePoint = false;
            Destroy(gameObject, 1f);
        }
    }
}
