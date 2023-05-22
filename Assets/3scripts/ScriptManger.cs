using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScriptManger : MonoBehaviour
{
    //obsticles scripts
    public spawnObsticles obsticleSpawn;
    //player scrips
    public movement playerMovement;
    public static int level = 1;
    public int velocityCombo = 1;
    public Text levelText;
    public GameObject parentOfClone;
    public GameObject parentOfPlayer; public static int playerskinSelected;
    public PlayerSettings skins;
    public Text comboText;
    public GameObject pauseMenu;
    public AudioManager audioManager;

    void Start()
    {
        //make the player
        Instantiate(skins.playerSkins[PlayerSettings.playerSkinSelected], parentOfPlayer.transform); // skins is just a reference to PlayerSettings
        //assign player scripts
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<movement>();
        //apply settings
        ApplyVolumeControl();
        //normal stuff
        
        
        obsticleSpawn.GenerateLevel(level);
        //playerMovement.winScreen.SetActive(false);
        playerMovement.setVelocity(20, 3);
        
    }

    
    void FixedUpdate()
    {
        
        playerMovement.onKeypressMove();
        playerMovement.CheckHasFallinToDeath();
        velocityComboChecker();
        CheckForPauseMenuButton();

    }
    public void nextLevel() {
        level++;
        cleanUpMap();
        levelText.text = "Level "+level;
        
        obsticleSpawn.GenerateLevel(level);
    }
    void cleanUpMap(){
         foreach (Transform child in parentOfClone.transform)
         {
             Destroy(child.gameObject);
         }
    }

    public void CheckForPauseMenuButton(){
        if (Input.GetKey(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            Debug.Log("setting pause menu :" + !pauseMenu.activeSelf);
            playerMovement.controlsEnabled = false;
        }


    }
    public void onMenuButtonPressed() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0); // load main menus scene
    }
    public void onResumeButtonPressed() {
        pauseMenu.SetActive(false);
        playerMovement.controlsEnabled = true;
    }
    void velocityComboChecker() {
        if (playerMovement.getVelocity() > 420)
        {
            velocityCombo = 3;
            Debug.Log("Velocity Combo >> 3");
            comboText.color = Color.green;
            gameObject.GetComponent<scoreManager>().updateComboText();
            audioManager.playerSpeedMusic.UnPause();
            audioManager.playerMusic.Pause();
            

        }
        else if (playerMovement.getVelocity() >= 200)
        {
            velocityCombo = 2;
            Debug.Log("Velocity Combo  >> 2");
            comboText.color = Color.yellow;
            gameObject.GetComponent<scoreManager>().updateComboText();
            
        }
        else
        {
            velocityCombo = 1;
            comboText.color = Color.red;
            gameObject.GetComponent<scoreManager>().updateComboText();
            audioManager.playerMusic.UnPause();
            audioManager.playerSpeedMusic.Pause();
            
            
        }
     }

    public void ApplyVolumeControl() {
        foreach (GameObject sfxObject in GameObject.FindGameObjectsWithTag("SoundEffect")) {
            sfxObject.GetComponent<AudioSource>().volume = PlayerSettings.sfxVolume;
        }
        foreach (GameObject musicObject in GameObject.FindGameObjectsWithTag("Music"))
        {
            musicObject.GetComponent<AudioSource>().volume = PlayerSettings.musicVolume;
        }
        foreach (GameObject musicSpeedObject in GameObject.FindGameObjectsWithTag("speedMusic"))
        {
            musicSpeedObject.GetComponent<AudioSource>().volume = PlayerSettings.speedMusicVolume;
            Debug.Log("Setting MUSIC SPEED OBJECT to " + PlayerSettings.speedMusicVolume);
        }

    }
}
