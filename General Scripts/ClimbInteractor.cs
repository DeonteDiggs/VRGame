using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;




public class ClimbInteractor : CharacterActions
{

    public static ActionBasedController controller;

    protected override void Awake()
    {
        base.Awake();

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (controller)
        {
            Climb();
        }
        else
        {
            _rigidbody_.useGravity = true;
        }
            
    }

    protected override void Move()
    {
        base.Move();
        Climb();
    }
    private void Climb()
    {
        if (controller)
        {
            if (controller.name == "LeftHand Controller")
            {
                print("LEFT HAND");

                _rigidbody_.useGravity = false;

                Vector3 _velocity = _characterInputActions.XRILeftHand.DeviceVelocity.ReadValue<Vector3>();

                transform.position += transform.rotation * -_velocity * Time.fixedDeltaTime;

            }
            else if (controller.name == "RightHand Controller")
            {
                print("RIGHT HAND");
                _rigidbody_.useGravity = false;

                Vector3 _velocity = _characterInputActions.XRIRightHand.DeviceVelocity.ReadValue<Vector3>();

                print(_velocity);

                transform.position += transform.rotation * -_velocity * Time.fixedDeltaTime;
            }
        }
        else
        {
            _rigidbody_.useGravity = true;
        }

    }
}
