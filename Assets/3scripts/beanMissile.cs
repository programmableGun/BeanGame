using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beanMissile : MonoBehaviour
{
    public float explosionForce;
    public bool isPlayerFriend;
    // Start is called before the first frame update
    void Start()
    {
        if (isPlayerFriend) {
            transform.LookAt(GameObject.FindGameObjectWithTag("Boss").transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
