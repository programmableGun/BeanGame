using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnObsticles : MonoBehaviour
{
    [Header("List of Obsticles")]
    public GameObject[] obsitcles;// list of different obsticles chunks
    [Header("List of Floors")]
    public GameObject[] floors;  // list of different flooring
    [Header("")]
    [Header("")]
    public GameObject EndingBlock;

    public int Z_GeneratorOffset;
    public Transform spawnPointer;  //shows the generator where to instaniate the chunks of the level;
    public ScriptManger scriptManager;

    public int constantOffset = 20;
    public GameObject cloneHolder;
    public void GenerateLevel(int level){
        scriptManager.parentOfClone = cloneHolder;
        int selector;
        for (int i = 0; i < level + constantOffset;i++){
            selector = Random.Range(0, floors.Length);
            spawnPointer.position = new Vector3(0f,0f, i * Z_GeneratorOffset); // sets the spawn pointer to the center of the next spot
            GameObject floorClone = Instantiate(floors[selector], spawnPointer.position, spawnPointer.rotation, cloneHolder.transform);
            spawnPointer.position = new Vector3(0f, floorClone.transform.localScale.y, spawnPointer.position.z);
            selector = Random.Range(0, obsitcles.Length);
            GameObject obsticleClone = Instantiate(obsitcles[selector], spawnPointer.position, spawnPointer.rotation, cloneHolder.transform); Debug.Log(spawnPointer.position.ToString());

        }
        EndingBlock.transform.position = new Vector3(0f, 0f, spawnPointer.position.z + constantOffset);
        GameObject.FindGameObjectWithTag("Player").GetComponent<player>().progressBar.maxValue = EndingBlock.transform.position.z - EndingBlock.transform.localScale.z;

        
    }
    
}
