using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : MonoBehaviour
{
    public GameObject sphere1;
    public GameObject sphere2;
    public GameObject sphere3;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("GameDifficulty") == 1)
        {
            sphere1.SetActive(true);
            sphere2.SetActive(false);
            sphere3.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("GameDifficulty") == 2)
        {
            sphere1.SetActive(false);
            sphere2.SetActive(true);
            sphere3.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("GameDifficulty") == 3)
        {
            sphere1.SetActive(false);
            sphere2.SetActive(false);
            sphere3.SetActive(true);
        }

        Debug.Log(PlayerPrefs.GetInt("GameDifficulty"));
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("GameDifficulty") == 1)
        {
            sphere1.SetActive(true);
            sphere2.SetActive(false);
            sphere3.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("GameDifficulty") == 2)
        {
            sphere1.SetActive(false);
            sphere2.SetActive(true);
            sphere3.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("GameDifficulty") == 3)
        {
            sphere1.SetActive(false);
            sphere2.SetActive(false);
            sphere3.SetActive(true);
        }

    }

    public void Easy()
    {
        sphere1.SetActive(true);
        sphere2.SetActive(false);
        sphere3.SetActive(false);
        PlayerPrefs.SetInt("GameDifficulty", 1);
    }

    public void Medium()
    {
        sphere1.SetActive(false);
        sphere2.SetActive(true);
        sphere3.SetActive(false);
        PlayerPrefs.SetInt("GameDifficulty", 2);
    }

    public void Hard()
    {
        sphere1.SetActive(false);
        sphere2.SetActive(false);
        sphere3.SetActive(true);
        PlayerPrefs.SetInt("GameDifficulty", 3);
    }
}
