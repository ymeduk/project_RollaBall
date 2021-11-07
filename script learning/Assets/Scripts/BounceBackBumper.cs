using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBackBumper : MonoBehaviour
{
    [SerializeField] string playerTag;
    [SerializeField] float bounceforce;
    public Animator anim;

    private void OnCollisionEnter(Collision collision)

{
    if(collision.transform.tag == playerTag)
    {
        Rigidbody otherRB = collision.rigidbody;
        otherRB.AddExplosionForce(bounceforce, collision.contacts[0].point, 5);
        anim.Play("bump");
    }
}
}
