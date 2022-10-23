using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    PlayerController _playerController;
    Rigidbody _rigidbody;


    public Mover(PlayerController player)
    {
        _playerController = player;
        _rigidbody = player.GetComponent<Rigidbody>();
    }

    public void Tick()
    {
        _rigidbody.AddRelativeForce(Vector2.up * Time.deltaTime * 60);
    }
}
