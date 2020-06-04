using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateHeart : MonoBehaviour
{
    private int NewLife = 0;
    private int Life = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("SelectPower").GetComponent<SelectPower>().LaserIsTrue)
        {
            NewLife = GameObject.Find("Perso").GetComponent<CharacterController>().Life;
        }
        else if (GameObject.Find("SelectPower").GetComponent<SelectPower>().BallIsTrue)
        {
            NewLife = GameObject.Find("PersoJaune").GetComponent<CharacterController>().Life;
        }
        else if (GameObject.Find("SelectPower").GetComponent<SelectPower>().BulletIsTrue)
        {
            NewLife = GameObject.Find("PersoGris").GetComponent<CharacterController>().Life;
        }

        if (GameObject.Find("SelectPower").GetComponent<SelectPower>().LaserIsTrue)
        {
            Life = GameObject.Find("Perso").GetComponent<CharacterController>().Life;
        }
        else if (GameObject.Find("SelectPower").GetComponent<SelectPower>().BallIsTrue)
        {
            Life = GameObject.Find("PersoJaune").GetComponent<CharacterController>().Life;
        }
        else if (GameObject.Find("SelectPower").GetComponent<SelectPower>().BulletIsTrue)
        {
            Life = GameObject.Find("PersoGris").GetComponent<CharacterController>().Life;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Updateheart();
        if (GameObject.Find("SelectPower").GetComponent<SelectPower>().LaserIsTrue)
        {
            Life = GameObject.Find("Perso").GetComponent<CharacterController>().Life;
        }
        else if (GameObject.Find("SelectPower").GetComponent<SelectPower>().BallIsTrue)
        {
            Life = GameObject.Find("PersoJaune").GetComponent<CharacterController>().Life;
        }
        else if (GameObject.Find("SelectPower").GetComponent<SelectPower>().BulletIsTrue)
        {
            Life = GameObject.Find("PersoGris").GetComponent<CharacterController>().Life;
        }
    }

    void Updateheart()
    {
        if (NewLife > Life)
        {
            if (this.gameObject.name == "coeur" + Life)
            {
                Destroy(this.gameObject);
                NewLife = Life;
            }
        }
    }
}
