using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider staminaBar;
    public bool playerIsOnTheGround = true;


    private int maxStamina = 100;
    private int currentStamina;
    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;

    public static StaminaBar instance;
    public PlayerController player;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
    }

    void FixedUpdate()
    {
        if(currentStamina > 1)
        {
            if(Input.GetKeyDown(KeyCode.JoystickButton2) && playerIsOnTheGround)
            {
                UseStamina(33);

            } 
            
            player.dashForce = 25;
            player.dashDuration = 0.2f;
            //player.Jump = 6;
            //player.speed = 8;


        }
        else if (currentStamina <= 32)
        {
            player.DashParticle.Stop();
            player.DashSound.Stop();  
            player.dashForce = 0;
            player.dashDuration = 0;
            //player.Jump = 6;
            //player.speed = 8;

        }
    }

    public void UseStamina(int amount)
    {
        if(currentStamina - amount >=0)
        {
            currentStamina -= amount;
            staminaBar.value = currentStamina;

            if (regen != null)
                StopCoroutine(regen);

            regen = StartCoroutine(RegenStamina());
        }
        else
        {
            Debug.Log("not enough stamina");
        }
    }

    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(5);

        while(currentStamina < maxStamina)
        {
            currentStamina += maxStamina / 3;
            staminaBar.value = currentStamina;
            yield return regenTick;
        }
        regen = null;
    }
private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {          

            playerIsOnTheGround = true;


        }    
    }
 
}
