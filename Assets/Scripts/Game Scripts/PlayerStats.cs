using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int score = 0;
    public int highScore = 0;
    public int bubbles = 0;
    public LoadManager lm;

    private void Awake() 
    {
    LoadPlayer();    
    }
    public void SavePlayer()
    {
        SaveLoadMethod.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveLoadMethod.LoadPlayer();

        if(lm.continueToken)
        {
            score = data.score;
        }
        bubbles = data.bubbles;
        highScore = data.highScore;
    }
}
