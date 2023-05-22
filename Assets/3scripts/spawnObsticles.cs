using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnObsticles : MonoBehaviour
{
    [Header("List of Obsticles")]
    public GameObject[] easyObsitcles;// list of different obsticles chunks
    public GameObject[] mediumObsitcles;
    public GameObject[] hardObsticles;
    public GameObject[] bossObsticles;
    [Header("List of Floors")]
    public GameObject[] easyFloors;  // list of different flooring
    public GameObject[] mediumFloors;
    public GameObject[] hardFloors;
    public GameObject[] bossFloors;
    [Header("")]
    [Header("")]
    public GameObject beanBoss;
    public int bossOffSet;
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
        GameObject floorClone = Instantiate(easyFloors[selector], spawnPointer.position, spawnPointer.rotation, cloneHolder.transform);
        if (level <= 3)   // easier level generation for levels 1-5
        {
            for (int i = 1; i < level * constantOffset; i++)
            {
                selector = Random.Range(0, easyFloors.Length);
                spawnPointer.position = new Vector3(0f, 0f, i * Z_GeneratorOffset); // sets the spawn pointer to the center of the next spot
                floorClone = Instantiate(easyFloors[selector], spawnPointer.position, spawnPointer.rotation, cloneHolder.transform);
                spawnPointer.position = new Vector3(0f, floorClone.transform.localScale.y, spawnPointer.position.z);
                selector = Random.Range(0, easyObsitcles.Length);
                GameObject obsticleClone = Instantiate(easyObsitcles[selector], spawnPointer.position, spawnPointer.rotation, cloneHolder.transform); Debug.Log(spawnPointer.position.ToString());


            }
        }
        //else if (level == 4) { // medium level generation WITH BEAN BOSS
            
        //    for (int i = 1; i < level * constantOffset; i++)
        //    {
        //        selector = Random.Range(0, mediumFloors.Length);
        //        spawnPointer.position = new Vector3(0f, 0f, i * Z_GeneratorOffset); // sets the spawn pointer to the center of the next spot
        //        if (i == bossOffSet) {summonBeanBoss(spawnPointer);}
        //        floorClone = Instantiate(mediumFloors[selector], spawnPointer.position, spawnPointer.rotation, cloneHolder.transform);
        //        spawnPointer.position = new Vector3(0f, floorClone.transform.localScale.y, spawnPointer.position.z);
        //        selector = Random.Range(0, mediumObsitcles.Length);
        //        GameObject obsticleClone = Instantiate(mediumObsitcles[selector], spawnPointer.position, spawnPointer.rotation, cloneHolder.transform); Debug.Log(spawnPointer.position.ToString());


        //    }
        //}
        else if (level < 3)
        {  // medium level generation
            for (int i = 1; i < level * constantOffset; i++)
            {
                selector = Random.Range(0, mediumFloors.Length);
                spawnPointer.position = new Vector3(0f, 0f, i * Z_GeneratorOffset); // sets the spawn pointer to the center of the next spot
                floorClone = Instantiate(mediumFloors[selector], spawnPointer.position, spawnPointer.rotation, cloneHolder.transform);
                spawnPointer.position = new Vector3(0f, floorClone.transform.localScale.y, spawnPointer.position.z);
                selector = Random.Range(0, mediumObsitcles.Length);
                GameObject obsticleClone = Instantiate(mediumObsitcles[selector], spawnPointer.position, spawnPointer.rotation, cloneHolder.transform); Debug.Log(spawnPointer.position.ToString());


            }
        }
        else
        {  // if above 15 then hard generation
            for (int i = 1; i < level * constantOffset; i++)
            {
                selector = Random.Range(0, hardFloors.Length);
                spawnPointer.position = new Vector3(0f, 0f, i * Z_GeneratorOffset); // sets the spawn pointer to the center of the next spot
                floorClone = Instantiate(hardFloors[selector], spawnPointer.position, spawnPointer.rotation, cloneHolder.transform);
                spawnPointer.position = new Vector3(0f, floorClone.transform.localScale.y, spawnPointer.position.z);
                selector = Random.Range(0, hardObsticles.Length);
                GameObject obsticleClone = Instantiate(hardObsticles[selector], spawnPointer.position, spawnPointer.rotation, cloneHolder.transform); Debug.Log(spawnPointer.position.ToString());


            }
        }

        EndingBlock.transform.position = new Vector3(0f, 0f, spawnPointer.position.z + constantOffset);
        GameObject.FindGameObjectWithTag("Player").GetComponent<player>().maxZDistace = 0;
        GameObject.FindGameObjectWithTag("Player"). 
            GetComponent<player>().progressBar.maxValue = 
            GameObject.FindGameObjectWithTag("Player").GetComponent<player>().maxZDistace;
    }




    void summonBeanBoss(Transform pointer)
    {
        GameObject CloneOfBeanBoss = Instantiate(beanBoss, pointer.position, pointer.rotation, cloneHolder.transform);
        
    }


}
