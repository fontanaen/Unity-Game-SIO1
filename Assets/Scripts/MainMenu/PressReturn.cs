using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressReturn : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject Controle;
    public GameObject Settings;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void PlayGame()
    {
       
        
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    
    } 

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SettingsDifficulty()
    {
        Controle.SetActive(true);
        
    }

    public void BackSettings()
    {
        Controle.SetActive(false);
        Settings.SetActive(true);
    }

    public void BackMenu()
    {
        Controle.SetActive(false);
        Settings.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void ReturnMenu()
    {
        MainMenu.SetActive(true);
        Controle.SetActive(false);
    }

    public void MenuSettings()
    {
        MainMenu.SetActive(false);
        Settings.SetActive(true);
    }
}
