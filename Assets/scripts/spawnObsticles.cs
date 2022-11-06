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
        selector = 1; // should be defualt floor
        spawnPointer.position = new Vector3(0f, 0f, 0 * Z_GeneratorOffset); // sets the spawn pointer to the center of the next spot
        GameObject floorClone = Instantiate(floors[selector], spawnPointer.position, spawnPointer.rotation, cloneHolder.transform);

        for (int i = 1; i < level * constantOffset;i++){
            selector = Random.Range(0, floors.Length);
            spawnPointer.position = new Vector3(0f,0f, i * Z_GeneratorOffset); // sets the spawn pointer to the center of the next spot
            floorClone = Instantiate(floors[selector], spawnPointer.position, spawnPointer.rotation, cloneHolder.transform);
            spawnPointer.position = new Vector3(0f, floorClone.transform.localScale.y, spawnPointer.position.z);
            selector = Random.Range(0, obsitcles.Length);
            GameObject obsticleClone = Instantiate(obsitcles[selector], spawnPointer.position, spawnPointer.rotation, cloneHolder.transform); Debug.Log(spawnPointer.position.ToString());

        }
<<<<<<< Updated upstream
        EndingBlock.transform.position = new Vector3(0f, 0f, spawnPointer.position.z + constantOffset);
        GameObject.FindGameObjectWithTag("Player").GetComponent<player>().progressBar.maxValue = EndingBlock.transform.position.z - EndingBlock.transform.localScale.z;

        
=======
<<<<<<< Updated upstream
    }
    void setRandomSize(int widthMax, int heightMax, GameObject obj) { 
        obj.transform.localScale = new Vector3((float)Random.Range(2, widthMax), //x
            (float)Random.Range(2, heightMax),  //y
            (float)Random.Range(2, 30)); //z
    }
    private void setRandomLocation(int section, GameObject obj) {
        obj.transform.position = new Vector3((float)Random.Range(-randomPostionX_max, randomPostionX_max), //x
            (float)Random.Range(-8,randomPostionY_max),  //y
            (float)Random.Range(section,section+30)); //z
=======
        EndingBlock.transform.position = new Vector3(0f, 0f, spawnPointer.position.z + constantOffset);
        GameObject.FindGameObjectWithTag("Player").GetComponent<player>().maxZDistace = 0;
        GameObject.FindGameObjectWithTag("Player").GetComponent<player>().progressBar.maxValue = GameObject.FindGameObjectWithTag("Player").GetComponent<player>().maxZDistace;

        
>>>>>>> Stashed changes
>>>>>>> Stashed changes
    }
    
}
