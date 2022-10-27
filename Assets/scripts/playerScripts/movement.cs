using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public Rigidbody rb; //= GameObject.Find("bean").gameObject.GetComponent<Rigidbody>();
    public float forceAmt = 300f;
    public float jumpMultiplyer = 1f;
    private float velocity = 0f;
    public bool canJump = true;

    public GameObject winScreen;
    public AudioManager audioManager;

    public bloom bloom;
    

    public scoreManager scrManager;
    public ScriptManger scriptManger;

    public bool controlsEnabled = true;
    public bool nextLevelLocked = true;

    //this is starting to become speghetti code and i want to fix it
    public void onKeypressMove() {  // basic movement with a rigidbody
        if (controlsEnabled)
        {
            if (Input.GetKey(KeyCode.UpArrow) && canJump)
            {

                setVelocity(forceAmt * jumpMultiplyer, 2);
                audioManager.playerJump.Play();
                canJump = false;
                bloom.DoBloom(false);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {

                rb.AddForce(new Vector3(0f, -forceAmt, 0f));


            }
            if (Input.GetKey(KeyCode.W))
            {
                rb.AddForce(new Vector3(0f, 0f, forceAmt));

            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.AddForce(new Vector3(0f, 0f, -forceAmt));
            }
            if (Input.GetKey(KeyCode.A))
            {
                rb.AddForce(new Vector3(-forceAmt, 0f, 0f));
            }
            if (Input.GetKey(KeyCode.D))
            {
                rb.AddForce(new Vector3(forceAmt, 0f, 0f));
            }
        }
        else {
            if (Input.GetKey(KeyCode.R) && nextLevelLocked)
            { //press r to respawn
                controlsEnabled = true;
                resetPosition();
                GetComponent<player>().deadScreen.SetActive(false);
                GetComponent<player>().particle.Stop();
                scrManager.resetCombo();
            }
            
        }
    }

    public void setVelocity(float val,int index) {
        this.velocity = val;
        if (index == 1) { rb.velocity = new Vector3(velocity, rb.velocity.y, rb.velocity.z); }
        if (index == 2) { rb.velocity = new Vector3(rb.velocity.x, velocity, rb.velocity.z); }
        if (index == 3) { rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, velocity); }

    }
    public void resetPosition() {
        rb.gameObject.transform.position = new Vector3(0f, 10f, 0f);
        setVelocity(0, 3);
        setVelocity(0, 2);
        setVelocity(0, 1);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("ground")) {
            canJump = true;
            bloom.DoBloom(true);
            scrManager.resetCombo();
        }
        if (collision.gameObject.tag.Equals("endingBlock")) {
            nextLevelLocked = false;
            winScreen.SetActive(true);
            scriptManger.nextLevel();
        }            
            


    }
    public void CheckHasFallinToDeath()
    {
        if (gameObject.transform.position.y < -15) {
            resetPosition();
            //aaaaaaaaaaaaaaaaaaaaaaahhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh

        }
    }



}
