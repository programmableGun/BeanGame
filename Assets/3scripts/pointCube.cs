using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointCube : MonoBehaviour
{

    //scripts
    public scoreManager scrManager;
    public AudioManager audioManager;
    
    
    // physcial things
    public Renderer rend;
    public GameObject destoryedVersion;

    // numerical data
    
    private int type;
    private float rotationSpeed;

    private void Start()
    {

        type = Random.Range(0, 4);
        rotationSpeed = Random.Range(-0.1f, 0.1f);

        audioManager = GameObject.FindGameObjectWithTag("mainScript").GetComponent<AudioManager>();
        scrManager = GameObject.FindGameObjectWithTag("mainScript").GetComponent<scoreManager>();
        
        gameObject.transform.Translate(new Vector3(
            Random.Range(-2,2), Random.Range(0, 5), Random.Range(-1, -1)));

        //Skins.isPointCubeCollision;
       // GetComponent<MeshRenderer>().materials[0] = GameObject.Find("Canvas").GetComponent<MenuScript>().pointCubeSkin[GameObject.Find("Canvas").GetComponent<MenuScript>().pointCubeSelected];
       // GetComponent<MeshFilter>().mesh = GameObject.Find("Canvas").GetComponent<MenuScript>().pointCubeMesh[GameObject.Find("Canvas").GetComponent<MenuScript>().pointCubeSelected];

    }

    private void Update()
    {
        if (type == 1)
        {
            this.gameObject.transform.Rotate(new Vector3(rotationSpeed, 0f, 0f));
        }
        if (type == 2)
        {
            this.gameObject.transform.Rotate(new Vector3(rotationSpeed, rotationSpeed, 0f));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("bean"))
        {
            //combo increase
            scrManager.combo++;
            scrManager.updateComboText();
            scrManager.addScore(150);
            comboSoundEffect();
            
            //set jump to true
            other.gameObject.GetComponent<movement>().canJump = true;
            other.gameObject.GetComponent<movement>().bloom.DoBloom(true);


            //make collidble bits of bean can if enabled
            Debug.Log("bean collided");
            
            Instantiate(destoryedVersion, transform.position, transform.rotation);
            
            Destroy(this.gameObject);


        }
    }
    private void comboSoundEffect()
    {
        if (scrManager.combo == 1) { audioManager.pointScored.pitch = audioManager.comboSfxPitch[0]; audioManager.pointScored.Play(); }
        else if (scrManager.combo == 2) { audioManager.pointScored.pitch = audioManager.comboSfxPitch[1]; audioManager.pointScored.Play(); }
        else if (scrManager.combo == 3) { audioManager.pointScored.pitch = audioManager.comboSfxPitch[2]; audioManager.pointScored.Play(); }
        else if (scrManager.combo == 4) { audioManager.pointScored.pitch = audioManager.comboSfxPitch[3]; audioManager.pointScored.Play(); }
        else if (scrManager.combo >= 5) { audioManager.pointScored.pitch = audioManager.comboSfxPitch[4]; audioManager.pointScored.Play(); }


    }
}
