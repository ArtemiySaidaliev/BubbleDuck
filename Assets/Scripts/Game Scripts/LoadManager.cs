using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    public Animator transition;

    public TouchManagerMenu tmm;

    public ScoreScript ss;

    public PlayerStats ps;

    public float transitionTime = 1f;

    public bool GameIsPaused = false;

    public bool continueToken = true;

    public bool isLose = false;

    public GameObject pauseMenuUI;

    public GameObject LoseMenuUI;

    public GameObject Dryer;

    public float SaveTime = 3f;
    AudioSource m_AudioSource;

    

    public int multiplier = 10;

    void Start()
    {
         m_AudioSource = GetComponent<AudioSource> ();
    }
    void Update()
    {
        if(tmm.Swipe() == 0 && SceneManager.GetActiveScene().name == "Main Menu")//условие нажатия
        {
           Loadlvl(); 
        }
        if(tmm.Swipe() == 1 && SceneManager.GetActiveScene().name == "Main Menu")//условие нажатия
        {
           LoadSkins(); 
        }
        /////////////////////// Skin Scene
        if(tmm.Swipe() == 0 && SceneManager.GetActiveScene().name == "SkinScene")//условие нажатия
        {
           LoadMenu(); 
        }
        //////////////////////// Lvl Scene
        if(tmm.Swipe() == 1 && SceneManager.GetActiveScene().name == "LvlScene")//условие нажатия
        {
           LoadMenu(); 
        }
         if(tmm.Swipe() == 2 && SceneManager.GetActiveScene().name == "LvlScene")//условие нажатия
        {
           if(GameIsPaused)
           {
                
                Resume(); 
           } else 
           {  
                Pause();
           }
        }

        if(isLose)
        {
            LoseMenuUI.SetActive(true);
            if(tmm.Swipe() == 0 && SceneManager.GetActiveScene().name == "LvlScene" && continueToken)  //условие нажатия
            {
               //запуск рекламы;
               Debug.Log("ADS GOING");
               Time.timeScale = 1f;
                Dryer.SetActive(true);
               StartCoroutine(Wait());
               
               continueToken = false;
               isLose = false;
            
              
              // Resume();

            } 
            if(tmm.Swipe() == 1 && SceneManager.GetActiveScene().name == "LvlScene")  //условие нажатия
            {
                ps.bubbles += ps.score/multiplier;
                ps.score = 0;
                ps.SavePlayer();
                Time.timeScale = 1f;
                LoadMenu();
            }  
        }


    }
    


    public void LoadMenu()
    {
        StartCoroutine(LoadLevel("Main Menu"));
    }
    public void Loadlvl()
    {
        StartCoroutine(LoadLevel("LvlScene"));
    }
    public void LoadSkins()
    {
        StartCoroutine(LoadLevel("SkinScene"));
    }

     public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }



    IEnumerator LoadLevel (string sceneName)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneName);
    }
     IEnumerator Wait ()
    {
        LoseMenuUI.SetActive(false);
        yield return new WaitForSeconds(SaveTime);
        Dryer.SetActive(false);
    }
}


