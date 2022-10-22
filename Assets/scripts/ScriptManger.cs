﻿using System.Collections;
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
    
    

    void Start()
    {
        obsticleSpawn.GenerateLevel(level);
        playerMovement.winScreen.SetActive(false);
        playerMovement.setVelocity(20, 3);
    }

    
    void FixedUpdate()
    {
        playerMovement.onKeypressMove();
        playerMovement.CheckHasFallinToDeath();
        if (Input.GetKeyDown(KeyCode.P)) { playerMovement.winScreen.SetActive(false);}

    }
    public void nextLevel() {
        level
        UnityEngine.SceneManagement.SceneManager.LoadScene("runner");

    }
   

}
