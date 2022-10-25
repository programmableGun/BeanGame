using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointCube : MonoBehaviour
{
    public scoreManager scrManager;

    public Renderer rend;
    public AudioManager audioManager;
    public GameObject destoryedVersion;
    private int type;
    private float rotationSpeed;

    private void Start()
    {
        type = Random.Range(0, 4);
        rotationSpeed = Random.Range(-0.1f, 0.1f);
        audioManager = GameObject.FindGameObjectWithTag("mainScript").GetComponent<AudioManager>();
        scrManager = GameObject.FindGameObjectWithTag("mainScript").GetComponent<scoreManager>();
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
            scrManager.combo++;
            scrManager.updateComboText();
            scrManager.addScore(150);
            comboSoundEffect();
            other.gameObject.GetComponent<movement>().canJump = true;
            other.gameObject.GetComponent<movement>().bloom.DoBloom(true);
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
