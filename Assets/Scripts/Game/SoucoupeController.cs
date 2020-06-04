using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoucoupeController : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject LifeRed;
    private GameObject NewLifeRed;
    public GameObject LifeGreen;
    private GameObject NewLifeGreen;

    public Vector2 PointDepart;
    private Vector2 velocity;

    private float distance;
    public float Speed = 100f;
    public float DistanceParcourue;
    public float starttime;
    private float Health = 150f;
    private float InitialHealth = 150f;

    private bool IsGoingToRight = false;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("GameDifficulty") == 1)
        {
            Health = 100f;
            InitialHealth = 100f;
        } else if (PlayerPrefs.GetInt("GameDifficulty") == 2)
        {
            Health = 125f;
            InitialHealth = 125f;
        } else if (PlayerPrefs.GetInt("GameDifficulty") == 3)
        {
            Health = 150f;
            InitialHealth = 150f;
        }
        NewLifeRed = Instantiate(LifeRed, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 35, gameObject.transform.position.z), Quaternion.identity);
        NewLifeRed.transform.parent = gameObject.transform;
        NewLifeGreen = Instantiate(LifeGreen, new Vector3(NewLifeRed.transform.position.x, NewLifeRed.transform.position.y, NewLifeRed.transform.position.z-1), Quaternion.identity);
        NewLifeGreen.transform.parent = NewLifeRed.transform;
        NewLifeRed.transform.eulerAngles = new Vector2(0, 0);
        StartCoroutine(SpawnBullet());
        velocity = new Vector2(-Speed, 0);
        PointDepart = transform.position;
        Move();
    }

    // Update is called once per frame
    void Update()
    {
        HealthJauge();
        distance = Random.Range(600.0f, 1800.0f);
        Move();
    }

    void Move()
    {
        DistanceParcourue = PointDepart.x - transform.position.x;
        if (IsGoingToRight)
        {
            transform.Translate(velocity.x * Time.deltaTime, 0, 0);
            if (DistanceParcourue > distance)
            {
                
                //Change Orientation
                transform.eulerAngles = new Vector2(0, 180);
                NewLifeGreen.transform.position = new Vector3(NewLifeRed.transform.position.x, NewLifeRed.transform.position.y, NewLifeRed.transform.position.z - 1);
                IsGoingToRight = false;
            }
        }
        else
        {
            transform.Translate(velocity.x * Time.deltaTime, 0, 0);
            if (DistanceParcourue <= PointDepart.x - 300)
            {
                
                //Change Orientation
                transform.eulerAngles = new Vector2(0, 360);
                NewLifeGreen.transform.position = new Vector3(NewLifeRed.transform.position.x, NewLifeRed.transform.position.y, NewLifeRed.transform.position.z + 1);
                IsGoingToRight = true;
            }
        }
    }

    public void HealthJauge()
    {
        if (Health > 0)
        {
            NewLifeGreen.transform.localScale = new Vector3(1 * (Health / InitialHealth), 1, 10);

        }

    }

    IEnumerator SpawnBullet()
    {
        GameObject NewBullet = Instantiate(Bullet, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1.5f), Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(4f, 14f));
    }

    public IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "PlayerBullet")
        {
            Health = Health - 25f;
            if (Health <= 0f)
            {
                Destroy(gameObject);
            }
        }

        else if (collision.gameObject.tag == "BallThunder")
        {
            Destroy(gameObject);
        }

        else if (collision.gameObject.tag == "PowerLaser" || collision.gameObject.tag == "PowerThunder")
        {
            while (collision.gameObject.tag == "PowerLaser" || collision.gameObject.tag == "PowerThunder")
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
                Health = Health - 7.5f;
                if (Health <= 0)
                {
                    Destroy(gameObject);
                }
                yield return new WaitForSeconds(0.1f);
            }
        }
        else if (collision.gameObject.tag == "InfinityMissile")
        {
            if (GameObject.Find("SpawnBonus").GetComponent<SpawnBonus>().DoublePoint == true)
            {
                Health = Health - 80;
                GameObject.Find("PersoGris").GetComponent<CharacterController>().Score = GameObject.Find("PersoGris").GetComponent<CharacterController>().Score + 100;
            }
            else
            {
                Health = Health - 80;
                GameObject.Find("PersoGris").GetComponent<CharacterController>().Score = GameObject.Find("PersoGris").GetComponent<CharacterController>().Score + 50;
            }

            if (Health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
