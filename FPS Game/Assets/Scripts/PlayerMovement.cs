using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    /// The motor that drives the player
    public CharacterController controller; 

    //The speed at which the player moves
    public float speed = 12f;
    //Gravity, the force that makes the player move down when in free fall = 9.81;
    public float gravity = -9.81f;

    //Refrence to the GroundCheck object
    public Transform groundCheck;

    //Radius of sphere for GroundCheck
    public float groundDistance = 0.4f;

    //Allows us to control what objects the groundCheck can interact with
    public LayerMask groundMask;

    //A boolean to check if we are grounded
    bool isGrounded;

    //The player's current velocity
    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Creates a sphere, that if it collides with anything that is in our groundMask to true
        isGrounded = Physics.CheckSpehere(groundCheck.position, groundDistance, groundMask);

        //If we are toutching the ground and our y velocity is stationary
        if (isGrounded && velocity.y < 0)
        {
            //Velocity = -2f
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Essentially an arrow that points in the direction we wish to move and transforms them in the given direction
        Vector3 move = transform.right * x + transform.forward * z;

        //Creates movement
        controller.Move(move * speed * Time.deltaTime);

        //Apply gravity to the player's velocity
        velocity.y += gravity * Time.deltaTime;

        //Enables player movement
        controller.Move(velocity * Time.deltaTime);
    }
}
