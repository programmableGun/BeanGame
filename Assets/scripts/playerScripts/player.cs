using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    int maxZDistace = 0;
    public scoreManager scrManager;
    public GameObject deadScreen;
    public ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
        maxZDistace = (int)this.gameObject.transform.position.z;
        scrManager.addScore(10);
        scrManager.addScore(20);
    }

    // Update is called once per frame
    void Update()
    {
        scoreUpdater();
    }
    void scoreUpdater() {
        if (maxZDistace < (int)this.gameObject.transform.position.z)
        {
            maxZDistace = (int)this.gameObject.transform.position.z;
            scrManager.addScore(1);
        }
        
    }
    public void Die() {

        //lose control of player
        GetComponent<movement>().controlsEnabled = false;
        // show a respawn screen
        deadScreen.SetActive(true);

        // play death effect
        particle.Play();
        // wait for the player to press r >> this gets detected in movement.cs

        
    }
    
}
