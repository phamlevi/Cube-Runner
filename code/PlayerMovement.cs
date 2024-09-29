using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public Rigidbody rb;
    public PlayerTrigger trigger;
    public AudioSource jumpPadS;

    public int superJpRemain;

    //Show in inspector
    [SerializeField] private Transform groundCheckTransform;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private float gravityScale;
    [SerializeField] private float forwardF = 2000f;
    [SerializeField] private float sidewaysF = 800f;
    [SerializeField] private float jumpVelopcity = 20;
    [SerializeField] private float velopcityBoost = 50;

    private float innitJumpV;
    private float horizInput;
    private bool spacePressed;
    

   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        innitJumpV = jumpVelopcity;
    }

    
    void Update()
    {
        
        //CHECK FOR HORIZONTAL INPUT
        horizInput = Input.GetAxis("Horizontal");

        //CHECK FOR JUMP
        if (Input.GetKeyDown(KeyCode.Space)) {
            spacePressed = true;
        }
    }


    private void FixedUpdate()
    {
        //SCALE GRAVITY
        rb.AddForce(Physics.gravity * gravityScale, ForceMode.Acceleration);

        //ADD FORWARD FORCE
        rb.AddForce(0, 0, forwardF * Time.deltaTime);

        
       
        ///ADD SIDEWAYS FORCE
        if (horizInput != 0) {
            Vector3 xInput = new Vector3(horizInput,0,0);
            rb.MovePosition(transform.position + xInput * sidewaysF * Time.deltaTime );
        }

        //END GAME IF JUMP OFF
        if (rb.position.y < -1f) {
            
            FindAnyObjectByType<GameManager>().EndGame();
        }

        //JUMP
        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0)
        {
            return;
        }
        if (spacePressed)
        {
            if (superJpRemain > 0)
            {
                Debug.Log("JumpPad used.");
                jumpPadS.Play();
                jumpVelopcity = velopcityBoost;
                superJpRemain--;
            }
            rb.AddForce(Vector3.up * jumpVelopcity, ForceMode.Impulse);
            jumpVelopcity = innitJumpV;
            spacePressed = false;
        }

    }


}
