using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashTest : AbilityTest
{
    [SerializeField] private float dashForce;
    [SerializeField] private float dashDuration;
    private float movementX;
    private float movementY;
    private float movementZ;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            StartCoroutine(Cast());
        }
    }

    public override IEnumerator Cast()
    {
        float targetAngle = Mathf.Atan2(movementX, movementY) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
        transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
        Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        rb.AddForce(Camera.main.transform.forward * dashForce,ForceMode.VelocityChange);

        yield return new WaitForSeconds(dashDuration);

        rb.velocity = Vector3.zero;
    }
}
