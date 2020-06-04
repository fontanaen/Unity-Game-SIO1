using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInfinityMissile : MonoBehaviour
{
    public GameObject InfinityMissile;
    public GameObject SpawnMissile;

    private int i;

    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        StartCoroutine(Infinity());
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(i);
    }

    IEnumerator Infinity()
    {
        while (i < 50)
        {
            GameObject NewInfinityMissile = Instantiate(InfinityMissile, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + Random.Range(-100f, 150f), -2), Quaternion.identity);
            NewInfinityMissile.GetComponent<Rigidbody2D>().velocity = new Vector3(Random.Range(200f, 300f), 0, 0);
            Destroy(NewInfinityMissile, 8f);
            i = i + 1;
            
            yield return new WaitForSeconds(0.5f);
           
        }
        GameObject.Find("Black").GetComponent<PowerJauge>().PowerIsTrue = false;
        if (i > 50)
        {
            gameObject.SetActive(false);
        }

      
    }
}
