using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{      
    [SerializeField] private float _forceMultiplier;  
    [SerializeField] private float _horizontalSpeedMultiplier;
    [SerializeField] private float _rightSpeedInput;

    [SerializeField] private int _wheelsOnGround=0;

    [SerializeField] private GameObject _centerOfMass;

    [SerializeField] private List<WheelCollider> _wheelColliderList;

    private Rigidbody _playerRB;

    private void Start()
    {
        _playerRB = GetComponent<Rigidbody>();
        _playerRB.centerOfMass = _centerOfMass.transform.position;
    }

    private void FixedUpdate()
    {
        _rightSpeedInput = Input.GetAxis("Horizontal");
        if (IsWheelsOnTheGround())
        {
            
            _playerRB.AddRelativeForce(Vector3.forward * _forceMultiplier);
            transform.Rotate(Vector3.up * _rightSpeedInput * _horizontalSpeedMultiplier * Time.deltaTime);
        }
    } 
    
    private bool IsWheelsOnTheGround()
    {
        _wheelsOnGround = 0;
        foreach(var wheelCollider in _wheelColliderList)
        {
            if (wheelCollider.isGrounded)
                _wheelsOnGround++;
        }

        if (_wheelsOnGround == 4)
            return true;
        else
            return false;
    }

}
