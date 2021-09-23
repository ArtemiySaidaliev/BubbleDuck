using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScoreScript : MonoBehaviour
{

    public Text scoreText;
    public Text HighScoreText;
    public PlayerStats ps;
    public GameObject platformPrefab;
    public LoadManager lm;



   public void OnCollisionEnter2D(Collision2D collision)
    {
        
         if(collision.collider.name == "Character")
        {
           // lm.Pause();
           lm.isLose = true;
            ps.SavePlayer();
            if(lm.continueToken)
            {
                ps.LoadPlayer();
            }
            Time.timeScale = 0f;
            //SceneManager.LoadScene(0);
        }   
            ps.score++;
            
            if(ps.score > ps.highScore)
            {
                ps.highScore = ps.score;
            }
            scoreText.text = "Score: " + ps.score.ToString();
            HighScoreText.text = "High Score: " + ps.highScore.ToString();
    }

   
}
