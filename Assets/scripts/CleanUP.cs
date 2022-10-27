using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUP : MonoBehaviour
{
    //used to clean up the bits of bushes bean cans
    void Start()
    {
        Destroy(this.gameObject, 3); 
    }


}
