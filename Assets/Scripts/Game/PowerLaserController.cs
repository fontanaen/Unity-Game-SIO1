using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerLaserController : MonoBehaviour
{

    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameObject.Find("SelectPower").GetComponent<SelectPower>().LaserIsTrue)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                GameObject.Find("Perso").GetComponent<CharacterController>().Life = GameObject.Find("Perso").GetComponent<CharacterController>().Life + 1;

            }
        }
        if (GameObject.Find("SelectPower").GetComponent<SelectPower>().BallIsTrue)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                GameObject.Find("PersoJaune").GetComponent<CharacterController>().Life = GameObject.Find("PersoJaune").GetComponent<CharacterController>().Life + 1;
            }
        }
    }
}
