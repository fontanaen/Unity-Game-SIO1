using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAliens : MonoBehaviour
{
    public GameObject Aliens;
    private GameObject NewAliens;

    private float GameDifficulty;

    // Start is called before the first frame update
    void Start()
    {
        difficulty();
        StartCoroutine(Spawn());   
    }

    // Update is called once per frame
    void Update()
    {
        difficulty();
    }

    public void difficulty()
    {
        if (PlayerPrefs.GetInt("GameDifficulty") == 1)
        {
            GameDifficulty = Random.Range(9f, 25f);
        }
        else if (PlayerPrefs.GetInt("GameDifficulty") == 2)
        {
            GameDifficulty = Random.Range(5f, 15f);
        }
        else if (PlayerPrefs.GetInt("GameDifficulty") == 3)
        {
            GameDifficulty = Random.Range(3f, 7f);
        }
    }

    IEnumerator Spawn()
    {
        for (int i = 0; i < 10000; i++)
        {

            GameObject NewAliens = Instantiate(Aliens, new Vector3(gameObject.transform.position.x + Random.Range(-200f, 200f), gameObject.transform.position.y, -2), Quaternion.identity);

            yield return new WaitForSeconds(GameDifficulty);
        }
    }
}
