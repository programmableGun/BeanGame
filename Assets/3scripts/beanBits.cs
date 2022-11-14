using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beanBits : MonoBehaviour
{

    void Start()
    {
        if (PlayerSettings.isPointCubeCollisionOn){
            gameObject.GetComponent<MeshCollider>().convex = PlayerSettings.isPointCubeCollisionOn;
        }
        else {
            Destroy(this.gameObject);
        }
        //Debug.Log("collision " + gameObject.GetComponent<MeshCollider>().convex);
    }

}
