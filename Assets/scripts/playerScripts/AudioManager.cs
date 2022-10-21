using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioListener audioListener;

    public AudioSource pointScored;
    public AudioSource playerDied;
    public AudioSource playerJump;

    public float[] comboSfxPitch;
}
