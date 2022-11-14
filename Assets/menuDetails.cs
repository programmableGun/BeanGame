using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuDetails : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward);
    }

    private void FixedUpdate()
    {
        gameObject.transform.eulerAngles += new Vector3(0.01f, 0.3f, .6f);
    }
}
