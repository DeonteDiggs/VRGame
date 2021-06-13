using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using Mirror;
public class CharacterActions : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Set Main Camera Object")]
    GameObject _head;

    [Space] [SerializeField]
    [Tooltip("Set move speed")]
    float _moveSpeed = 0;

    [SerializeField]
    [Tooltip("Set jump force")]
    float _jumpForce = 0;

    [SerializeField]
    [Tooltip("Set collision layers for this capsule cast for jumping")]
    LayerMask _groundDetectionLayer;

    [Tooltip("Set the inventory for this player")]
    public InventoryObject PlayerInventory;

    protected static Rigidbody _rigidbody_;
    private CapsuleCollider _collider;

    //InputAction variables
    protected CharacterInputActions _characterInputActions;
    
    protected virtual void Awake()
    {
        _rigidbody_ = GetComponent<Rigidbody>();
        _collider = GetComponent<CapsuleCollider>();

        _characterInputActions = new CharacterInputActions();
        _characterInputActions.XRIRightHand.Jump.performed += ctx => Jump();
        // _characterInputActions.XRIRightHand.TerminalActivation.performed += ctx =>
        // { 
        //     //if()
        //         //TerminalActivationListener();
        
        // }; 
    }


    private void OnEnable()
    {
        _characterInputActions.Enable();
    }
    private void OnDisable()
    {
        _characterInputActions.Disable();
    }
    protected virtual void Update()
    {
        
            Move();
    }

    private void OnApplicationQuit()
    {
        PlayerInventory.container.items = new Slot[24];
    }

    protected virtual void Move()
    {
        Vector2 _position = _characterInputActions.XRILeftHand.Move.ReadValue<Vector2>();

        if( _head != null)
        {
            Vector3 _direction = new Vector3(_position.x , 0 , _position.y);

            Vector3 _headRotation = new Vector3(0 , _head.transform.eulerAngles.y , 0);

            _direction = Quaternion.Euler(_headRotation) * _direction;

            Vector3 _movement = _direction * _moveSpeed * Time.deltaTime;

            transform.position += _movement;
        }
    }

    private void Jump()
    {
        if(GroundCheck())
            _rigidbody_.AddForce(_jumpForce * Vector3.up);  
    }

    private bool GroundCheck()
    {
        return Physics.CheckCapsule(_collider.bounds.center,
            new Vector3(_collider.bounds.center.x, _collider.bounds.min.y, _collider.bounds.center.z), _collider.radius * 0.9f, _groundDetectionLayer);
    }

    private void TerminalActivationListener(bool isPressed)
    {
        print("Terminal Activated");
    }

}
