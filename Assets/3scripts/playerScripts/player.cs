using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class player : MonoBehaviour
{
    public int maxZDistace = 0;
    public ParticleSystem particle;

    public scoreManager scrManager;
    public Image deadScreen;
    public Slider progressBar; //aka max slider
    public Slider currentPositionBar;
    
    
    // Start is called before the first frame update
    void Start()
    {

        //finds all the gameobjects for scripts
        scrManager = GameObject.FindGameObjectWithTag("mainScript").GetComponent<scoreManager>();
        deadScreen = GameObject.Find("DeadScreen").GetComponent<Image>(); //so fucking stupid, you have to set the dead screen or anything active to find it using the gameobject.find fucntion; 
        progressBar = GameObject.Find("maxDistanceSlider").GetComponent<Slider>();
        currentPositionBar = GameObject.Find("CurrentDistance").GetComponent<Slider>();
        deadScreen.gameObject.SetActive(false);
        

        //normal stuff

        maxZDistace = (int)this.gameObject.transform.position.z;
        scrManager.addScore(10);
        scrManager.addScore(20);
        progressBar.maxValue = GameObject.FindGameObjectWithTag("endingBlock").transform.position.z;
        currentPositionBar.maxValue = GameObject.FindGameObjectWithTag("endingBlock").transform.position.z;
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
            progressBar.value = maxZDistace;
            progressBar.maxValue = GameObject.FindGameObjectWithTag("endingBlock").transform.position.z;
            currentPositionBar.maxValue = GameObject.FindGameObjectWithTag("endingBlock").transform.position.z;

        }
        currentPositionBar.value = transform.position.z;
        
    }
    public void Die() {

        //lose control of player
        GetComponent<movement>().controlsEnabled = false;
        // show a respawn screen
        deadScreen.gameObject.SetActive(true);

        // Explode
        //particle.Play();
        // wait for the player to press r >> this gets detected in movement.cs

        
    }
    
}
