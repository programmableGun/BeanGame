using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHandler : MonoBehaviour
{
    Queue<IPowerUps> powerUps;
    void Start()
    {
        powerUps = new Queue<IPowerUps>();
        powerUps.Enqueue(GameObject.FindGameObjectWithTag("powerup").GetComponent<IPowerUps>());
    }

    // Update is called once per frame
    public void usePowerup()
    {
        IPowerUps power = powerUps.Dequeue();
        Debug.Log(power.powerUpName);
        power.Activate();
    }
}
