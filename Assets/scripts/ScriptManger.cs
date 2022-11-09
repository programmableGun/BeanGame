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
    public int level = 1;
    public Text levelText;
    public GameObject parentOfClone;
    public GameObject parentOfPlayer; public static int playerskinSelected;
    public Skins skins;
    

    void Start()
    {
        //make the player
        Instantiate(skins.playerSkins[Skins.playerSkinSelected], parentOfPlayer.transform);
        //assign player scripts
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<movement>();
        //normal stuff
        obsticleSpawn.GenerateLevel(level);
        //playerMovement.winScreen.SetActive(false);
        playerMovement.setVelocity(20, 3);
        
    }

    
    void FixedUpdate()
    {
        
        playerMovement.onKeypressMove();
        playerMovement.CheckHasFallinToDeath();
        

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
   

}
