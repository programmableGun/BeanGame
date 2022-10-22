using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnObsticles : MonoBehaviour
{
    public GameObject[] obsitcles;// list of different obsticles chunks
    public GameObject[] floors;  // list of different flooring
    public Transform spawnPointer;  //shows the generator where to instaniate the chunks of the level;
    public int constantOffset = 20; 
    public void GenerateLevel(int level){
        for(int i = 0; i < level + constantOffset;i++){
            spawnPointer.position = new Vector3(0f,0f, i * spawnPointer.localScale.z); // sets the spawn pointer to the center of the next spot
            GameObject floorClone = Instantiate(floors[Random.Range(0,floors.length)], spawnPointer);
            GameObject obsitcles = Instantiate(obsitcles[Random.Range(0,obsticle.length)], spawnPointer);
        }   
    }
    
}
