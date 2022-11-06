using System.Collections;
using System.Collections.Generic;
<<<<<<< Updated upstream
using UnityEngine;
=======
using System.IO;
using UnityEngine;
using UnityEngine.UI;
>>>>>>> Stashed changes

public class MenuScript : MonoBehaviour
{
    public ScriptManger scriptManager;
    [Header("Menu Screens")]
    public GameObject menuScreen;
    public GameObject settingsScreen;
    public GameObject skinsScreen;
    public GameObject pauseMenu;
<<<<<<< Updated upstream
    
    
=======

    [Header("Menu Stuff")]
    public Dropdown resolutionMenu;
    public Toggle fullScreenToggle;
    [Header("Player Skins")]
    public Material[] playerSkins; public Mesh[] playerMesh; public int playerSkinSelected = 0;
    [Header("Obsticle Skins")]
    public Material[] obsticleSkins; public Mesh[] obsticleMesh; public int obsticleSkinSelected = 0;
    [Header("pointCube Skins")]
    public Material[] pointCubeSkin; public Mesh[] pointCubeMesh; public int pointCubeSelected = 0;
    [Header("Floor Skins")]
    public Material[] floorSkin; 
>>>>>>> Stashed changes

    // what happends when the pause button is pressed
    public void OnPauseButtonPressed(){
        pauseMenu.SetActive(true);
    }
    public void OnResumeButtonPressed(){
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
<<<<<<< Updated upstream
    
    public void OnResolutionChange(int index){ // prints the currently available 
        Resolution[] resolutions = Screen.resolutions;
        // Print the resolutions
        foreach (var res in resolutions)
        {
            Debug.Log(res.width + "x" + res.height + " : " + res.refreshRate);
        }
    }

=======
    public void OnMainMenuButtonPressed()
    {
        settingsScreen.SetActive(false);
        menuScreen.SetActive(true);
        skinsScreen.SetActive(false);
    }

    public void OnResolutionChange(int index){ 
        Resolution[] resolutions = Screen.resolutions;
        // Print the resolutions
        Screen.SetResolution(resolutions[index].width, resolutions[index].height, fullScreenToggle.isOn, resolutions[index].refreshRate);
    }
    public void FillResolutionDropDown()
    {
        Resolution[] resolutions = Screen.resolutions;
        List<string> listOfResolutions = new List<string>();
        // Print the resolutions
        for (int i = 0; i < resolutions.Length; i++) {
            listOfResolutions.Add(resolutions[i].width + "x" + resolutions[i].height + " : " + resolutions[i].refreshRate);
        }
        resolutionMenu.AddOptions(listOfResolutions);
    }
   
>>>>>>> Stashed changes
    //what happends when the skins button is pressed
    public void OnSkinButtonPressed(){
        settingsScreen.SetActive(false);
        menuScreen.SetActive(false);
        skinsScreen.SetActive(true);
    }
    public void onPlayerSkinChange(int index){
<<<<<<< Updated upstream
        //get the player model

        //get the player shader

        //set the model to new index

        //set the shader to the according skin
   
=======
        //get list of player skins from material folder

        //set the model to new index
        //scriptManager.playerMovement.GetComponent<MeshFilter>().mesh = playerMesh[index];
        //set the shader to the according skin
        //scriptManager.playerMovement.GetComponent<MeshRenderer>().materials[0] = playerSkins[index];

        if (index == 0)
        {
            scriptManager.playerMovement.GetComponent<MeshRenderer>().material.color = new Color(1f,0,0);
        }
        else if (index == 1)
        {
            scriptManager.playerMovement.GetComponent<MeshRenderer>().material.color = new Color(0f, 1f, 0f);
        }
        else if (index == 2) {
            scriptManager.playerMovement.GetComponent<MeshRenderer>().material.color = new Color(.75f, .65f, .75f);
        }
        else if (index == 3)
        {
            scriptManager.playerMovement.GetComponent<MeshRenderer>().material.color = new Color(0f, 0f, 0f);
        }
        else if (index == 4)
        {
            scriptManager.playerMovement.GetComponent<MeshRenderer>().material.color = new Color(.58f, .35f, 1f);
        }

>>>>>>> Stashed changes
    }
    public void onObsticleSkinChange(int index){
        //get the obsticle model

        //get the obsticle shader

        //set the model to new index

        //set the shader to the according skin
    }
    public void onPointBlockSkinChange(int index){
        //get the pointBlock model

        //get the pointBlock shader

        //set the model to new index

        //set the shader to the according skin
    }
    
    // what happends when the exit button is pressed
    public void OnExitButtonPressed(){
<<<<<<< Updated upstream
        Application.Quit(0); // this may be the wrong syntax
=======
        Application.Quit(0); // this may be the wrong syntax : this is the right syntax;

>>>>>>> Stashed changes
    }

    void Start(){
        settingsScreen.SetActive(false);
        menuScreen.SetActive(true);
        skinsScreen.SetActive(false);
<<<<<<< Updated upstream
=======
        FillResolutionDropDown();
>>>>>>> Stashed changes
    }

}