﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiplier : MonoBehaviour, IPowerUps
{
    public bool isPowerUpActive { get; set; }
    public string powerUpName { get; set; }
    public float Duration { get; set; }
    public float remainingTime { get; set; }
    public int effectAmount { get; set; }


    private void Start()
    {
        isPowerUpActive = false;
        powerUpName = "Multiplier";
        remainingTime = 1f;
        Duration = 15f;
        Debug.Log("started multiplier");
    }

    private void Update()
    {
        if (isPowerUpActive)
        {
            if (remainingTime > 0f)
            {
                remainingTime -= Time.deltaTime; // Count down the remaining time
                remainingTime = Mathf.Clamp(remainingTime, 0f, Duration); // Ensure remainingTime does not go below 0 or exceed duration

                // Handle any logic or effects during the countdown
                Debug.Log("using "+powerUpName+" powerup: time left: " + Mathf.Round(remainingTime));
                GameObject.FindGameObjectWithTag("mainScript").GetComponent<scoreManager>().addScore(5);
            }
            else
            {
                // Power-up has expired, perform any necessary cleanup or end effects
                Debug.Log("ending " + powerUpName + " powerup");
                Destroy(this.gameObject);

            }
        }
    }
    public void Activate()
    {
        isPowerUpActive = true;
        // when this power up is active than multiply the multiplier by the effect amount
        Debug.Log("activating " + powerUpName);

    }

    public void DeActivate()
    {
        isPowerUpActive = false;
    }

    public float GetDuration()
    {
        return Duration;
    }
    public int getEffectAmount() {
        return effectAmount;
    }

    
}
