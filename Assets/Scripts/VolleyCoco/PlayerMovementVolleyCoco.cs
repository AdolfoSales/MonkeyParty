using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovementVolleyCoco : MonoBehaviour
{

    private CharacterController characterController;

    [SerializeField] float _speed;


    [SerializeField] float jumpSpeed;

    [SerializeField] float gravity;

    
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        

        if(characterController.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                move.y = jumpSpeed;
                
            }
        }

        move.y += gravity * Time.deltaTime;
        characterController.Move(move * Time.deltaTime * _speed);

    }
}
