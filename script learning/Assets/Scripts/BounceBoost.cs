using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBoost : MonoBehaviour
{
    [Range(100, 10000)]
    public float bouncehight;

    private void OnCollisionEnter(Collision Collision)
    {
        GameObject bouncer = Collision.gameObject;
        Rigidbody rb = bouncer.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * bouncehight);
    }
}
