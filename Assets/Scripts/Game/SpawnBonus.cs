using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnBonus : MonoBehaviour
{

    public GameObject PointMultiplicator;
    public GameObject TextDoublePoint;

    private float startime;
    private float GameDifficulty;

    public bool DoublePoint;
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnPointMultiplicator());
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("GameDifficulty") == 1)
        {
            GameDifficulty = Random.Range(35f, 85f);
        }
        else if(PlayerPrefs.GetInt("GameDifficulty") == 2)
        {
            GameDifficulty = Random.Range(30f, 80f);
        }
        else if (PlayerPrefs.GetInt("GameDifficulty") == 3)
        {
            GameDifficulty = Random.Range(25f, 75f);
        }

        if (DoublePoint)
        {
            TextDoublePoint.SetActive(true);
        }
        else
        {
            TextDoublePoint.SetActive(false);
        }
    }

    IEnumerator spawnPointMultiplicator()
    {
        yield return new WaitForSeconds(15f);
        for (int i = 0; i <10000;i++)
        {
            GameObject NewPointMultiplicator = Instantiate(PointMultiplicator, new Vector3(gameObject.transform.position.x -100, gameObject.transform.position.y + Random.Range(-50f,100f), -2), Quaternion.identity);
            
            yield return new WaitForSeconds(GameDifficulty);
        }
    }

   
}
