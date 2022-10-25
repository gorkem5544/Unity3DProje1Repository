using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    PlayerController _playerController;
    Rigidbody _rigidbody;
    public Rotator(PlayerController playerController)
    {
        _playerController = playerController;
        _rigidbody = playerController.GetComponent<Rigidbody>();
    }


    public void Tick(float direction)
    {
        if (direction == 0)
        {
            if (_rigidbody.freezeRotation)
            {
                _rigidbody.freezeRotation = false;
            }
            return;
        }
        if (!_rigidbody.freezeRotation)
        {
            _rigidbody.freezeRotation = true;

        }
        _rigidbody.transform.Rotate(Vector3.back * Time.deltaTime * direction * _playerController.rotational_speed);
    }
}
