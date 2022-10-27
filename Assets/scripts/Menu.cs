using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public ScriptManger scriptManager;
    [Header("Menu Screens")]
    public GameObject menuScreen;
    public GameObject settingsScreen;
    public GameObject skinsScreen;
    public GameObject pauseMenu;

    

    // what happends when the pause button is pressed
    publid void OnPauseButtonPressed(){
        pauseMenu.SetActive(true);
    }
    publiic void OnResumeButtonPressed(){
        pauseMenu.SetActive(false);
    }
    // what happends when the play button is pressed
    public void OnPlayButtonPressed(){
        settingsScreen.SetActive(false);
        menuScreen.SetActive(false);
        skinsScreen.SetActive(false);
    }

    //what happends when the settings button is pressed
    public void OnSettingsButtonPressed(){
        settingsScreen.SetActive(true);
        menuScreen.SetActive(false);
        skinsScreen.SetActive(false);
    }
    
    public void OnResolutionChange(int index){ // prints the currently available 
        Resolution[] resolutions = Screen.resolutions;
        // Print the resolutions
        foreach (var res in resolutions)
        {
            Debug.Log(res.width + "x" + res.height + " : " + res.refreshRate);
        }
    }

    //what happends when the skins button is pressed
    public void OnSkinButtonPressed(){
        settingsScreen.SetActive(false);
        menuScreen.SetActive(false);
        skinsScreen.SetActive(true);
    }
    // what happends when the exit button is pressed
    public void OnExitButtonPressed(){
        Application.Quit(0); // this may be the wrong syntax
    }

    void Start(){
        settingsScreen.SetActive(false);
        menuScreen.SetActive(false);
        skinsScreen.SetActive(false);
    }

}