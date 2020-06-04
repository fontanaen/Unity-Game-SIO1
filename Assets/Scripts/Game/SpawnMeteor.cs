using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMeteor : MonoBehaviour
{
    public GameObject Meteor;

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
            GameDifficulty = Random.Range(5f, 25f);
        }
        else if (PlayerPrefs.GetInt("GameDifficulty") == 2)
        {
            GameDifficulty = Random.Range(4f, 15f);
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
            GameObject NewMeteor = Instantiate(Meteor, new Vector3(gameObject.transform.position.x + Random.Range(-200f, 0f), transform.position.y, -2), Quaternion.identity);
            NewMeteor.GetComponent<Rigidbody2D>().velocity = new Vector2(-150, 0);
            Destroy(NewMeteor, 8f);
            yield return new WaitForSeconds(GameDifficulty);
        }
    }
}
