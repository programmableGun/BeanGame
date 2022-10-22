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

    
    

    void Start()
    {
        obsticleSpawn.startCloning(200, obsticleSpawn.pointCube);
        obsticleSpawn.randomPostionY_max = 80;obsticleSpawn.randomPostionX_max = 32;
        obsticleSpawn.startCloning(200, obsticleSpawn.obsticle);
        obsticleSpawn.startCloning(200, obsticleSpawn.obsticle);
        obsticleSpawn.randomPostionY_max = 150; obsticleSpawn.randomPostionX_max = 64;
        obsticleSpawn.startCloning(200, obsticleSpawn.obsticle);
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
        UnityEngine.SceneManagement.SceneManager.LoadScene("runner");
    }
   

}
