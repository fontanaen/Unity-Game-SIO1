using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public GameObject Panel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Panel.SetActive(true);
            Time.timeScale = 0f;
        }
        if (GameObject.Find("Perso").GetComponent<CharacterController>().GameOver)
        {
            Panel.SetActive(false);
        }
        else if (GameObject.Find("PersoJaune").GetComponent<CharacterController>().GameOver)
        {
            Panel.SetActive(false);
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        Panel.SetActive(false);
    }

    public void Settings()
    {

    }

    public void Quit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }
}
