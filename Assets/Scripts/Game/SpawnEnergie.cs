using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnergie : MonoBehaviour
{
    public GameObject Energie;

    private float score = 0f;
    private float NewScoreTarget = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
    }

    void Spawn()
    {
        if (GameObject.Find("SelectPower").GetComponent<SelectPower>().LaserIsTrue)
        {
            score = GameObject.Find("Perso").GetComponent<CharacterController>().Score;
        }
        else if (GameObject.Find("SelectPower").GetComponent<SelectPower>().BallIsTrue)
        {
            score = GameObject.Find("PersoJaune").GetComponent<CharacterController>().Score;
        }
        else if (GameObject.Find("SelectPower").GetComponent<SelectPower>().BulletIsTrue)
        {
            score = GameObject.Find("PersoGris").GetComponent<CharacterController>().Score;
        }

        if (GameObject.Find("Black").GetComponent<PowerJauge>().PowerIsGoing)
        {
            if (GameObject.Find("SelectPower").GetComponent<SelectPower>().LaserIsTrue)
            {
                if (PlayerPrefs.GetInt("GameDifficulty") == 3)
                {
                    if (score >= 700 + NewScoreTarget)
                    {
                        Instantiate(Energie, new Vector3(Random.Range(-287f, 287f), Random.Range(0f, 156f), -4), Quaternion.identity);
                        NewScoreTarget = score;
                    }
                }
            }
            else if (score >= 300 + NewScoreTarget)
            {
                Instantiate(Energie, new Vector3(Random.Range(-287f, 287f), Random.Range(0f, 156f), -4), Quaternion.identity);
                NewScoreTarget = score;
            }
        }
        else
        {
            if (score >= 50 + NewScoreTarget)
            {
                Instantiate(Energie, new Vector3(Random.Range(-287f, 287f), Random.Range(0f, 156f), -4), Quaternion.identity);
                NewScoreTarget = score;
            }
        }
    }
}
