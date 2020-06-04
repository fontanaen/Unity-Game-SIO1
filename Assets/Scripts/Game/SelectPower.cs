using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPower : MonoBehaviour
{
    public GameObject Panel;
    public GameObject PersoRouge;
    public GameObject PersoJaune;
    public GameObject PersoGris;

    public bool LaserIsTrue;
    public bool BallIsTrue;
    public bool BulletIsTrue;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("GameDifficulty"));
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PowerLaser()
    {
        if (PlayerPrefs.GetInt("GameDifficulty") != 1 &&  PlayerPrefs.GetInt("GameDifficulty") != 2 && PlayerPrefs.GetInt("GameDifficulty") != 3)
        {
            PlayerPrefs.SetInt("GameDifficulty", 1);
        }

        Time.timeScale = 1f;
        Panel.SetActive(false);
        LaserIsTrue = true;
        PersoRouge.SetActive(true);
    }

    public void PowerDeadBall()
    {
        if (PlayerPrefs.GetInt("GameDifficulty") != 1 && PlayerPrefs.GetInt("GameDifficulty") != 2 && PlayerPrefs.GetInt("GameDifficulty") != 3)
        {
            PlayerPrefs.SetInt("GameDifficulty", 1);
        }

        Time.timeScale = 1f;
        Panel.SetActive(false);
        BallIsTrue = true;
        PersoJaune.SetActive(true);
    }

    public void PowerInfinityBullet()
    {
        if (PlayerPrefs.GetInt("GameDifficulty") != 1 && PlayerPrefs.GetInt("GameDifficulty") != 2 && PlayerPrefs.GetInt("GameDifficulty") != 3)
        {
            PlayerPrefs.SetInt("GameDifficulty", 1);
        }

        Time.timeScale = 1f;
        Panel.SetActive(false);
        PersoGris.SetActive(true);
        BulletIsTrue = true;
    }
}
