using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPowerUps
{

    // varibles needed: (chance to spawn, int) ()
    bool isPowerUpActive { get; set; }
    float Duration { get; set; }
    string powerUpName { get; set; }
    float remainingTime { get; set; }
    int effectAmount { get; set; }

    // the powerups need to have following functions:
    void Activate();

    void DeActivate();
    float GetDuration();

}
