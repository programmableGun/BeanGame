using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    int maxZDistace = 0;
    public scoreManager scrManager;
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
}
