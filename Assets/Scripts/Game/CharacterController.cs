using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CharacterController : MonoBehaviour
{
    public GameObject bullet;
    public GameObject Heart;
    public GameObject LaserLeft;
    public GameObject LaserRight;
    public GameObject Foudre;
    public GameObject BallFoudre;
    public GameObject SpawnerInfinity;
    public GameObject AffichageScore;
   

    public TextMeshProUGUI ScoreText;
    
    private Rigidbody2D ThisRigidbody;
    private BoxCollider2D ThisBoxCollider;

    private Vector2 Direction = Vector2.zero;
    private Vector2 MoveUp = new Vector2();
    private Vector2 MoveLeft = new Vector2();
    private Vector2 MoveRight = new Vector2();

    private float speed;
    public float timer = 0f;
    public float waitTime = 1.5f;
    public float visualTime = 0f;
    private float scrollBar = 1.0f;
    public int Score = 0;
    
    public int Life = 0;
    public int NewLife = 0;
    

    public bool nbbullet;
    public bool IsGoingToRight = true;
    public bool GameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("GameDifficulty"));
        Time.timeScale = 1f;
        GameOver = false;
        ThisRigidbody = GetComponent<Rigidbody2D>();
        ThisBoxCollider = GetComponent<BoxCollider2D>();
        transform.eulerAngles = new Vector2(0, 0);
        Direction = new Vector2(250, 0);
        IsGoingToRight = true;
        SpawnHeart();
        NewLife = Life;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        AffichageScore.SetActive(true);
        BestScore();
        Timer();
        Move();
        SpawnBullet();
        ScoreText.text = "Score : " + Score;
        Debug.Log(IsGoingToRight);
        if (NewLife > Life)
        {
            if (IsGoingToRight)
            {
                NewLife = Life;
                GameObject.Find("SpawnHeart").transform.position = new Vector3(GameObject.Find("SpawnHeart").transform.position.x + 12.5f, GameObject.Find("SpawnHeart").transform.position.y, GameObject.Find("SpawnHeart").transform.position.z);
            }
            else
            {
                NewLife = Life;
                GameObject.Find("SpawnHeart").transform.position = new Vector3(GameObject.Find("SpawnHeart").transform.position.x - 12.5f, GameObject.Find("SpawnHeart").transform.position.y, -2);
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject.Find("SpawnHeart").transform.position = new Vector3(GameObject.Find("SpawnHeart").transform.position.x, GameObject.Find("SpawnHeart").transform.position.y, -2);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            GameObject.Find("SpawnHeart").transform.position = new Vector3(GameObject.Find("SpawnHeart").transform.position.x, GameObject.Find("SpawnHeart").transform.position.y, 2);
        }
    }

    void Move()
    {

        // Move Up

       
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            MoveUp = Vector2.up;
            MoveLeft = Vector2.left;
            MoveRight = Vector2.right;
            ThisRigidbody.AddForce(MoveUp * 360);
        }

        //Move Left

       if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.eulerAngles = new Vector2(0, 180);
            Direction = new Vector2(-250, 0);
            MoveLeft = Vector2.left;
            ThisRigidbody.AddForce(MoveLeft * 360);
            IsGoingToRight = false;
            
        }

        //Move Right

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.eulerAngles = new Vector2(0, 0);
            Direction = new Vector2(250, 0);
            MoveRight = Vector2.right;
            ThisRigidbody.AddForce(MoveRight * 360);
            IsGoingToRight = true;
            
        }

        //Move Down

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            MoveUp = Vector2.down;
            MoveLeft = Vector2.left;
            MoveRight = Vector2.right;
            ThisRigidbody.AddForce(MoveUp * 260);
        }

    }

    void SpawnBullet()
    {
        // Create new bullet with delay

        if (!GameObject.Find("Black").GetComponent<PowerJauge>().PowerIsTrue)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (nbbullet)
                {
                    
                    if (IsGoingToRight)
                    {
                        
                        GameObject Newbullet = Instantiate(bullet, new Vector3(gameObject.transform.position.x + 35, gameObject.transform.position.y, -1), Quaternion.identity);

                        nbbullet = false;
                        Newbullet.GetComponent<Rigidbody2D>().velocity = new Vector3(1000, 0, 0);
                        Destroy(Newbullet, 3f);
                    }
                    else
                    {
                        
                        GameObject Newbullet = Instantiate(bullet, new Vector3(gameObject.transform.position.x - 35, gameObject.transform.position.y, -1), Quaternion.identity);

                        nbbullet = false;
                        Newbullet.GetComponent<Rigidbody2D>().velocity = new Vector3(-1000, 0, 0);
                        Destroy(Newbullet, 3f);
                    }
                }
            }
        }
        else
        {
            if (GameObject.Find("SelectPower").GetComponent<SelectPower>().LaserIsTrue)
            {
                if (IsGoingToRight)
                {
                   
                    GameObject NewLaserRight = Instantiate(LaserLeft, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 55, -2), Quaternion.identity);
                    NewLaserRight.transform.parent = gameObject.transform;
                    GameObject.Find("Black").GetComponent<PowerJauge>().PowerIsTrue = false;
                    Destroy(NewLaserRight, 12f);
                }
                else
                {
                   
                    GameObject NewLaser = Instantiate(LaserRight, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 55, -2), Quaternion.identity);
                    NewLaser.transform.parent = gameObject.transform;
                    GameObject.Find("Black").GetComponent<PowerJauge>().PowerIsTrue = false;
                    Destroy(NewLaser, 12f);
                }
            }

            if (GameObject.Find("SelectPower").GetComponent<SelectPower>().BallIsTrue)
            {
                if (IsGoingToRight)
                {
                   
                    GameObject NewFoudre = Instantiate(Foudre, new Vector3(gameObject.transform.position.x + 100, gameObject.transform.position.y, -2), Quaternion.identity);
                    GameObject NewBallFoudre = Instantiate(BallFoudre, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -2), Quaternion.identity);
                    
                    NewFoudre.transform.parent = gameObject.transform;
                    NewBallFoudre.transform.parent = gameObject.transform;
                    GameObject.Find("Black").GetComponent<PowerJauge>().PowerIsTrue = false;
                    Destroy(NewFoudre, 12f);
                    Destroy(NewBallFoudre, 12f);
                }
                else
                {
                   
                    GameObject NewFoudre = Instantiate(Foudre, new Vector3(gameObject.transform.position.x - 100, gameObject.transform.position.y, -2), Quaternion.identity);
                    GameObject NewBallFoudre = Instantiate(BallFoudre, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -2), Quaternion.identity);
                    NewFoudre.transform.eulerAngles = new Vector2(0, 180);
                    NewFoudre.transform.parent = gameObject.transform;
                    NewBallFoudre.transform.parent = gameObject.transform;
                    GameObject.Find("Black").GetComponent<PowerJauge>().PowerIsTrue = false;
                    Destroy(NewFoudre, 12f);
                    Destroy(NewBallFoudre, 12f);
                }
            }

            if (GameObject.Find("SelectPower").GetComponent<SelectPower>().BulletIsTrue)
            {
                
                Instantiate(SpawnerInfinity);
                SpawnerInfinity.SetActive(true);
                GameObject.Find("Black").GetComponent<PowerJauge>().PowerIsTrue = false;
            }
            

        }
    }

    void SpawnHeart()
    {
        // Create a heart for each life

        for(int i = 0; i < Life; i++)
        {
            GameObject NewHeart = Instantiate(Heart, new Vector3(GameObject.Find("SpawnHeart").transform.position.x - 25*Life + 25*(i+2), GameObject.Find("SpawnHeart").transform.position.y + 10, GameObject.Find("SpawnHeart").transform.position.z), Quaternion.identity);
            NewHeart.transform.parent = GameObject.Find("SpawnHeart").transform;
            NewHeart.name = "coeur" + i;
        }

    }

    void Timer()
    { 
        if (nbbullet == false) 
        {
            timer += Time.deltaTime;

            if (timer > waitTime)
            {
                visualTime = timer;
                timer = timer - waitTime;
                Time.timeScale = scrollBar;
                nbbullet = true;
            }
        }
    }

    void BestScore()
    {
        Debug.Log(PlayerPrefs.GetInt("BestScore"));
        Debug.Log(Score);
        if (Score > PlayerPrefs.GetInt("BestScore")) {
            PlayerPrefs.SetInt("BestScore", Score);
        }
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (GameObject.Find("SpawnBonus").GetComponent<SpawnBonus>().DoublePoint == true)
            {
                Score = Score + 20;
            }
            else
            {
                Score = Score + 10;
            }
            Life = Life - 1;
            if (Life <= 0)
            {
                GameOver = true;
                
                Destroy(gameObject, 1f);
            }
        }
    }

    

}
