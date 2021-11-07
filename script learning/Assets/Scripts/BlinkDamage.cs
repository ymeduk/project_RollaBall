using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkDamage : MonoBehaviour
{
    public Renderer ModelRender1;
    public float blink;
    private float blinkTime = 0.1f;
    private float immunedTime;



    void Update()
    {
        if (immunedTime > 0)
        {
            Debug.Log("test1");

            immunedTime -= Time.deltaTime;

            blinkTime -= Time.deltaTime;

            if (blinkTime <= 0)
            {
                            Debug.Log("test2");

                ModelRender1.enabled = !ModelRender1.enabled;
                blinkTime = blink;

            }

            if(immunedTime <= 0)
            {
                            Debug.Log("test3");

                ModelRender1.enabled = true;
            }
        } 
    }

    
}
