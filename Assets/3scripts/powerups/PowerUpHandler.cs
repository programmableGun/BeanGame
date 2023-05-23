using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHandler : MonoBehaviour
{
    Queue<IPowerUps> powerUps;
    public UnityEngine.UI.Text powerUpListText;
    void Start()
    {
        powerUps = new Queue<IPowerUps>();
        powerUpListText.text = "Powerups:";
        updatePowerupText();

    }

    void updatePowerupText() {

        powerUpListText.text = "Powerups:";
        foreach (IPowerUps powerup in powerUps) {
            powerUpListText.text += "\n" + powerup.powerUpName;
        }

    }
    // Update is called once per frame
    public void usePowerup()
    {
        if (powerUps.Count == 0) // if there are no power ups 
        {
            // then say no more power ups
            powerUpListText.text = "Out of PowerUps:";
            Debug.LogError("No more powerups");
        }
        else
        { // other wise use the first power up in the queue.
            IPowerUps power = powerUps.Dequeue();
            updatePowerupText();
            Debug.Log(power.powerUpName);
            power.Activate();
        }
    }
    public void addPowerUp(IPowerUps powerup) {
        powerUps.Enqueue(powerup);
        updatePowerupText();
    }
    public void clearAll() {
        if (powerUps.Count == 0) { return; }
        for (int i = 0; i < powerUps.Count; i++) {
            powerUps.Dequeue();
        }
        updatePowerupText();
    }
}
