using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obsticle : MonoBehaviour
{
    public AudioManager audiomanager;
    public int type=0;
    public float rotationSpeed = 0.5f;
    public ParticleSystem explosionParticle;
    private void OnCollisionEnter(Collision obj)
    {
        Debug.Log(obj.gameObject.name);
        audiomanager.playerDied.Play();
        if (obj.gameObject.name.Equals("bean")) {
            obj.gameObject.GetComponent<player>().Die();
            Explode();
        }
    }

    private void Start()
    {
        type = Random.Range(0, 4);
        audiomanager = GameObject.FindGameObjectWithTag("mainScript").GetComponent<AudioManager>();
    }
    
    private void Update()
    {
        if (type == 1) {
            this.gameObject.transform.Rotate(new Vector3(rotationSpeed,0f,0f));
        }
        if (type == 2)
        {
            this.gameObject.transform.Rotate(new Vector3(rotationSpeed, rotationSpeed, 0f));
        }
    }
    private void Explode(){
        //explosionParticle.Play();
    }
}
