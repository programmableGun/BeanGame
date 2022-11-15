using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanBoss : MonoBehaviour
{
    public Rigidbody rb;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("beanMissile")) {
            rb.AddForce((Vector3.forward+Vector3.up) * collision.gameObject.GetComponent<beanMissile>().explosionForce, ForceMode.Impulse);
        }
    }
}
