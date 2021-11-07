using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class PlayerController : AbilityTest
{
    //public Animator Jumping;
    [SerializeField] public float dashForce;
    [SerializeField] public float dashDuration;
    public bool playerIsOnTheGround = true;
    public float Jump = 10.0f;
    public float speed = 0;
    //public float boost;
    public float MagnitudeTrail;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI starCountText;
    public GameObject prefab;
    public GameObject winTextObject;
    public Transform ParticleEnd;
    public ParticleSystem WalkParticle;
    public ParticleSystem jumpParticle;
    public ParticleSystem DashParticle;
    //public ParticleSystem BreakParticle;
    public AudioSource WalkSound;
    public AudioSource jumpSound;
    public AudioSource DashSound;
    public AudioSource BreakingSound;
    private Rigidbody rb;
    private Transform camTransform;
    private int count;
    private float movementX;
    private float movementY;
    private float movementZ;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count =- 14;
        SetCountText();
        winTextObject.SetActive(false);
        prefab.SetActive(false);
        //Jumping = gameObject.GetComponent<Animator>();
    }

    void OnMove(InputValue input)
    {   
        WalkSound.Play();
        WalkParticle.Play();
        Vector2 movementVector = input.Get<Vector2>(); 

        movementX = movementVector.x;
         movementY = movementVector.y;
    } 
void SetCountText()
{

countText.text = "Count: " + count.ToString();
    if(count >= 0)
    {
        prefab.SetActive(true);
    }
}

void setstarCountText()
{

starCountText.text = "Star: " + count.ToString();
    if(count >= 0)
    {
        winTextObject.SetActive(true);
    }
}


    void FixedUpdate()
    {
        
        
        float movementX = Input.GetAxisRaw("Horizontal");
        float movementY = Input.GetAxisRaw("Vertical");
        
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);


         if(Input.GetKeyDown(KeyCode.JoystickButton1) && playerIsOnTheGround)
        {
            jumpSound.Play();
            jumpParticle.Play();
            //Jumping.Play("jump");
            rb.AddForce(new Vector3 (0, Jump, 0), ForceMode.Impulse);
            playerIsOnTheGround = false;
            WalkParticle.Stop();                     
        }
        

        if(Input.GetKey(KeyCode.JoystickButton6) && playerIsOnTheGround)
        {
            //jumpSound.Play();
            rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
            Debug.Log("break");      
        }

        if(Input.GetKeyDown(KeyCode.JoystickButton6) && playerIsOnTheGround)
        {
            BreakingSound.Play();
            //BreakParticle.Play();
            //playerIsOnTheGround = false;

        }
       
        if (movement.magnitude >= 0.1f)
       {
            float targetAngle = Mathf.Atan2(movementX, movementY) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
	        Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
	        rb.AddForce(moveDirection.normalized * speed);
       }

        if ( movement.magnitude >= MagnitudeTrail)
       {
            WalkSound.Play();
            WalkParticle.Play();
       }
        //Dash mouvement
        if(Input.GetKeyDown(KeyCode.JoystickButton2))
         {
            //StaminaBar .instance.UseStamina(33);
            DashParticle.Play();
            DashSound.Play();  
            float targetAngle = Mathf.Atan2(movementX, movementY) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward; 
            rb.AddForce(moveDirection.normalized * dashForce, ForceMode.VelocityChange);
            StartCoroutine(Cast());
            //playerIsOnTheGround = true;

        }
        
    }
        public override IEnumerator Cast()
       {
                    
        yield return new WaitForSeconds(dashDuration);
        rb.velocity = Vector3.zero;
        yield return new WaitForSeconds(5);

       }
   
     void OnTriggerEnter(Collider other)
    {
         if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        }

         if(other.gameObject.CompareTag("Star"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;

            setstarCountText();
        }


    }

      private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {          

            playerIsOnTheGround = true;


        }
 
 
    
    
    }

}
