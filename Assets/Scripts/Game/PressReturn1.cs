using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressReturn1 : MonoBehaviour
{
    
    public GameObject Controle;
    public GameObject Settings;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("GameDifficulty"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
       
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
    }

    public void ReturnMenu()
    {
      
        Controle.SetActive(false);
    }

    public void MenuSettings()
    {
        
        Settings.SetActive(true);
    }
}
