using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class scoreManager : MonoBehaviour
{
    public int score = 0;
    [SerializeField]
    public int combo = 0;
    public Text scoreText;
    

    
    public void resetCombo() {
        combo = 0;
        Debug.Log("reseting combo");
    }
    public void setScore(int amt) {
        score = amt;
        updateScoreText();
        
        
    }
    public void addScore(int amt)
    {
        score += (int)(amt*combo/1.15*Time.time);
        
        setScore(score);
    }
    void updateScoreText(){
        
        scoreText.text = score.ToString();
    }
    
}
