using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class PlayerData 
{
  public int score;
  public int highScore;
  public int bubbles;


public  PlayerData (PlayerStats player)
{
    
    score = player.score;
    highScore = player.highScore;
    bubbles = player.bubbles;
    
}

}
