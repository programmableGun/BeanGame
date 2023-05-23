using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class scoreManager : MonoBehaviour
{
    public int score = 0;
    [SerializeField]
    public int combo = 0;
    private int oldCombo = 0;

    public Text scoreText;
    public Text comboText;

    public Animator animatior;
    public void resetCombo() {
        combo = 0;
        Debug.Log("reseting combo");
        updateComboText();
    }
    public void setScore(int amt) {
        score = amt;
        updateScoreText();
        
        
    }
    public void addScore(int amt)
    {
        score += (int)(amt*(combo + 1) + (ScriptManger.level * gameObject.GetComponent<ScriptManger>().velocityCombo * 1.5));
        setScore(score);
    }
    public void updateScoreText(){
        
        scoreText.text = score.ToString();
    }
    public void updateComboText(){
        comboText.text = combo*gameObject.GetComponent<ScriptManger>().velocityCombo + "x";
            
        if (combo*gameObject.GetComponent<ScriptManger>().velocityCombo != oldCombo){
            animatior.Play("Base Layer.TiltAndExpandLeft", 0,0);
            oldCombo = combo*gameObject.GetComponent<ScriptManger>().velocityCombo;
            Debug.Log("playing animator");
        }


    }
}
