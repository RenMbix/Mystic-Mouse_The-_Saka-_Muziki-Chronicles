using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCharacterController : MonoBehaviour
{

    // expose new layer mask to prevent  gracity application on capsule even when on ground

    [SerializeField] LayerMask groundLayers;


    //run speed

    [SerializeField] private float runSpeed = 8.0f;

    //Jump height Variable

    [SerializeField] private float jumpHeight = 2.0f;

    //adding gravity manually

    private float gravity = - 50.0f;

    //creating character controller variable

    private CharacterController characterController;

    //Velocity variable

    private Vector3 velocity;

    //Bool Check for ground

    private bool isGrounded;

    // Adding movement

    private float horizontalInput;

    //Jump height Variable

    

  
    

    // Start is called before the first frame update
    void Start()
    {

        //Referrence to the Character Controller

        characterController = GetComponent<CharacterController>();



    }

    // Update is called once per frame
    void Update()
    {
        //movement  rate

        horizontalInput = 1;

        //Face the Hero in Forward Direction

        transform.right = new Vector3(horizontalInput, 0, Mathf.Abs(horizontalInput) - 1);

        //isGrounded - Check if the feet are touching the ground layer, layer mask

        isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundLayers, QueryTriggerInteraction.Ignore);


        //only add gravity if the Hero is not grounded

        if(isGrounded && velocity.y < 0)
        {
            velocity.y=0;
        }
        else
        {
            //add gravity to the velocity variable on every frame
            velocity.y += gravity * Time.deltaTime;
        }

        // We will also move the  Character Controller Horizontaly

        characterController.Move(new Vector3(horizontalInput * runSpeed, 0, 0) * Time.deltaTime);


        //Hero Jumping 

        if(isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        //Vertical Velocity
        characterController.Move (velocity * Time.deltaTime);
        
    }
}
