using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnObsticles : MonoBehaviour
{

    public GameObject obsticle;
    public GameObject pointCube;
    public int randomPostionY_max = 50;
    public int randomPostionX_max = 16;
    public void startCloning(int amt, GameObject obj) {
        for (int i = 0; i < amt; i++) {
            setRandomLocation(i*15,obj);
            setRandomSize(15, 15, obj);
            GameObject clone = Instantiate(obj);
        }
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
    }
    
}
