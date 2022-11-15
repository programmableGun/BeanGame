using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Camera mainCamera;
    public Animator animator;
    public Material skyboxMat;
    public Transform playerTransform;
    public float offset = 10f;
    public float skyboxRotationSpeed = 1.5f;
    public GameObject beanBoss;
    // Start is called before the first frame update
    void Start()
    {
        beanBoss = GameObject.FindGameObjectWithTag("Boss");
    }

    // Update is called once per frame
    void Update()
    {
        //RenderSettings.skybox.SetFloat("_Rotation",Time.time*skyboxRotationSpeed);
        
        animator.SetFloat("speed", playerTransform.GetComponent<movement>().getVelocity());
        CameraLogic();
        
        
    }

    void CameraLogic() {

     // if there is no boss than set camera mode for the runner scene
     gameObject.transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + offset, playerTransform.position.z - offset);
     gameObject.transform.eulerAngles = new Vector3(20f, 0f, 0f);
    }
}
