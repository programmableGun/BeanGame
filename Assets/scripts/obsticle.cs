using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obsticle : MonoBehaviour
{
    public AudioManager audiomanager;
    public int type=0;
    public float rotationSpeed = 0.5f;
    public GameObject destoryedVersion;
    public ParticleSystem explosionParticle;
    private void OnCollisionEnter(Collision obj)
    {
        
     
        if (obj.gameObject.name.Equals("bean")) {
            obj.gameObject.GetComponent<player>().Die();
            audiomanager.playerDied.Play();
            Explode();
            Instantiate(destoryedVersion, transform.position, transform.rotation);
        }
    }

    private void Start()
    {
        type = Random.Range(0, 4);
<<<<<<< Updated upstream
        audiomanager = GameObject.FindGameObjectWithTag("mainScript").GetComponent<AudioManager>();
=======
<<<<<<< Updated upstream

=======
        audiomanager = GameObject.FindGameObjectWithTag("mainScript").GetComponent<AudioManager>();
        GetComponent<MeshRenderer>().materials[0] = GameObject.Find("Canvas").GetComponent<MenuScript>().obsticleSkins[GameObject.Find("Canvas").GetComponent<MenuScript>().obsticleSkinSelected];
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
    private void Explode(){
        //explosionParticle.Play();
    }
=======
<<<<<<< Updated upstream
=======
    private void Explode(){
        //explosionParticle.Play();
    }
    
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> Stashed changes
}
