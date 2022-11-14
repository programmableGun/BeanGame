using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    //public ScriptManger scriptManager;
    
    public PlayerSettings skins;

    [Header("Menu Screens")]
    public GameObject menuScreen;
    public GameObject settingsScreen;
    public GameObject skinsScreen;
    
    public GameObject CreditScreen;
    
    [Header("Settings Stuff")]
    public Dropdown resolutionMenu;
    public Toggle fullScreenToggle;
    public Slider musicSlider;
    public Slider sfxSlider;

    [Header("Player Skins")]
    public Dropdown playerSkinsDropDown; public  GameObject[] playerSkins; public int playerSkinSelected = 0;
    public Text currentSkinSelectedText;

    //Sounds
    public void changeMusicVolume(float val)
    {
        PlayerSettings.musicVolume = val;
    }
    public void changeSfxVolume(float val)
    {
        PlayerSettings.sfxVolume = val;
    }

    // what happends when the play button is pressed
    public void OnPlayButtonPressed(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("runner");
    }

    //what happends when the settings button is pressed
    public void OnSettingsButtonPressed(){
        settingsScreen.SetActive(true);
        menuScreen.SetActive(false);
        skinsScreen.SetActive(false);
        CreditScreen.SetActive(false);
    }
    public void OnMainMenuButtonPressed()
    {
        settingsScreen.SetActive(false);
        menuScreen.SetActive(true);
        skinsScreen.SetActive(false);
        CreditScreen.SetActive(false);
    }
    public void OnCreditMenuButtonPressed() {
        settingsScreen.SetActive(false);
        menuScreen.SetActive(false);
        skinsScreen.SetActive(false);
        CreditScreen.SetActive(true);
    }

    public void OnResolutionChange(int index){ 
        Resolution[] resolutions = Screen.resolutions;
        // Print the resolutions
        Screen.SetResolution(resolutions[index].width, resolutions[index].height, fullScreenToggle.isOn, resolutions[index].refreshRate);
    }
    public void OnResolutionChange()
    {
        int index = resolutionMenu.value;
        Resolution[] resolutions = Screen.resolutions;
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
    public void FillPlayerSkinDropDown()
    {

        skins.setSkins(playerSkins);
        List<string> listOfSkins = new List<string>();
        // fill drop down with skins from skins script
        for (int i = 0; i < playerSkins.Length; i++)
        {
            listOfSkins.Add(playerSkins[i].name);
            Debug.Log("Skin " + i + ": " +skins.getSkin(i).name);
        }
        playerSkinsDropDown.AddOptions(listOfSkins);

    }

    //what happends when the skins button is pressed
    public void OnSkinButtonPressed(){
        settingsScreen.SetActive(false);
        menuScreen.SetActive(false);
        skinsScreen.SetActive(true);
    }
    public static void onPlayerSkinChange(int index)
    {
        ScriptManger.playerskinSelected = index;
        PlayerSettings.playerSkinSelected = index;
        
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
        Application.Quit(0); // this may be the wrong syntax : this is the right syntax;

    }

    void Start(){
        settingsScreen.SetActive(false);
        menuScreen.SetActive(true);
        skinsScreen.SetActive(false);
        FillResolutionDropDown();
        FillPlayerSkinDropDown();
        sfxSlider.value = PlayerSettings.sfxVolume; musicSlider.value = PlayerSettings.musicVolume;
        
    }
    private void FixedUpdate()
    {
        currentSkinSelectedText.text = "Current Player Skin Selected: " + skins.getSkin(PlayerSettings.playerSkinSelected).name;
    }

}