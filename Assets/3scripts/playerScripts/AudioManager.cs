using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioListener audioListener;

    public AudioSource pointScored;
    public AudioSource playerDied;
    public AudioSource playerJump;
    public AudioSource playerMusic;
    public AudioSource playerSpeedMusic;

    public float[] comboSfxPitch;

    void Start()
    {
        audioListener = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioListener>();
        pointScored = GameObject.Find("PointsSound").GetComponent<AudioSource>();
        playerDied = GameObject.Find("DeathSound").GetComponent<AudioSource>();
        playerJump = GameObject.Find("JumpSound").GetComponent<AudioSource>();
        playerMusic = GameObject.Find("Music").GetComponent<AudioSource>();
        playerSpeedMusic = GameObject.Find("SpeedMusic").GetComponent<AudioSource>();
    }
}
