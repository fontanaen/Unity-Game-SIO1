using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverMenu : MonoBehaviour
{
    public GameObject Panel;
    public GameObject AffichageScore;
    public GameObject PowerReady;

    public TextMeshProUGUI Score;

    private bool GameOver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("SelectPower").GetComponent<SelectPower>().LaserIsTrue)
        {
            if (GameObject.Find("Perso").GetComponent<CharacterController>().Score >= PlayerPrefs.GetInt("BestScore"))
            {
                Score.text = "High Score : " + PlayerPrefs.GetInt("BestScore");
            }
            else
            {
                Score.text = "Your Score : " + GameObject.Find("Perso").GetComponent<CharacterController>().Score;
            }
                GameOver = GameObject.Find("Perso").GetComponent<CharacterController>().GameOver;
        } else if (GameObject.Find("SelectPower").GetComponent<SelectPower>().BallIsTrue)
        {
            if (GameObject.Find("PersoJaune").GetComponent<CharacterController>().Score >= PlayerPrefs.GetInt("BestScore"))
            {
                Score.text = "High Score : " + PlayerPrefs.GetInt("BestScore");
            }
            else
            {
                Score.text = "Your Score : " + GameObject.Find("PersoJaune").GetComponent<CharacterController>().Score;
            }
            GameOver = GameObject.Find("PersoJaune").GetComponent<CharacterController>().GameOver;
        }
        else if (GameObject.Find("SelectPower").GetComponent<SelectPower>().BulletIsTrue)
        {
            if (GameObject.Find("PersoGris").GetComponent<CharacterController>().Score >= PlayerPrefs.GetInt("BestScore"))
            {
                Score.text = "High Score : " + PlayerPrefs.GetInt("BestScore");
            }
            else
            {
                Score.text = "Your Score : " + GameObject.Find("PersoGris").GetComponent<CharacterController>().Score;
            }
            GameOver = GameObject.Find("PersoGris").GetComponent<CharacterController>().GameOver;
        }

        if (GameOver)
        {
            AffichageScore.SetActive(false);
            PowerReady.SetActive(false);
            Panel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        Panel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void Quit()
    {
        Panel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
