using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (GameObject.Find("SelectPower").GetComponent<SelectPower>().LaserIsTrue)
            {
                if (GameObject.Find("SpawnBonus").GetComponent<SpawnBonus>().DoublePoint == true)
                {
                    GameObject.Find("Perso").GetComponent<CharacterController>().Score = GameObject.Find("Perso").GetComponent<CharacterController>().Score + 20;
                }
                else
                {
                    GameObject.Find("Perso").GetComponent<CharacterController>().Score = GameObject.Find("Perso").GetComponent<CharacterController>().Score + 10;
                }
            }
            else if (GameObject.Find("SelectPower").GetComponent<SelectPower>().BallIsTrue)
            {
                if (GameObject.Find("SpawnBonus").GetComponent<SpawnBonus>().DoublePoint == true)
                {
                    GameObject.Find("PersoJaune").GetComponent<CharacterController>().Score = GameObject.Find("PersoJaune").GetComponent<CharacterController>().Score + 20;
                }
                else
                {
                    GameObject.Find("PersoJaune").GetComponent<CharacterController>().Score = GameObject.Find("PersoJaune").GetComponent<CharacterController>().Score + 10;
                }
            }
            else if (GameObject.Find("SelectPower").GetComponent<SelectPower>().BulletIsTrue)
            {
                if (GameObject.Find("SpawnBonus").GetComponent<SpawnBonus>().DoublePoint == true)
                {
                    GameObject.Find("PersoGris").GetComponent<CharacterController>().Score = GameObject.Find("PersoGris").GetComponent<CharacterController>().Score + 20;
                }
                else
                {
                    GameObject.Find("PersoGris").GetComponent<CharacterController>().Score = GameObject.Find("PersoGris").GetComponent<CharacterController>().Score + 10;
                }
            }
            Destroy(gameObject);
        }
    }

    
}
