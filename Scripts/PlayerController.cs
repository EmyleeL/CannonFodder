using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController Controller;

    public float playerSpeed;

    public float sprintSpeed;

    private Vector3 Velocity;

    public float Gravity;

    public float PJump;


    [SerializeField] private AudioSource stepAudio;

    // Start is called before the first frame update
    void Start()
    {
        // giving "controller" value as charactercontroller
       Controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // gravity control
        if (Controller.isGrounded && Velocity.y < 0)
        {

            Velocity.y = 0;

        }

        // to define a speed and direction that player moves, based on input

        float H = Input.GetAxisRaw("Horizontal");

        float V = Input.GetAxisRaw("Vertical");

        //Sprint

        if (Input.GetButtonDown("Sprint"))
        {
            playerSpeed += sprintSpeed;
        }

        if (Input.GetButtonUp("Sprint"))
        {
            playerSpeed -= sprintSpeed;
        }

        // jump
        if (Controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            Velocity.y += PJump;
        }

        Velocity.y += Gravity * Time.deltaTime;

        Vector3 Movement = (transform.right * H + transform.forward * V).normalized * playerSpeed;

        //Stepping audio
        if (Movement.magnitude > 0 && !stepAudio.isPlaying)
        {
            stepAudio.Play();
        }
        if (Movement.magnitude == 0 || Controller.isGrounded == false)
        {
            stepAudio.Stop();
        }

        Movement.y = Velocity.y;

        //keeps movement scaled independant of framerate
        Controller.Move(Movement * Time.deltaTime);

    }

}
