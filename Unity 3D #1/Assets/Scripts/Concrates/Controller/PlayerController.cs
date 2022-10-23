using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PcInputs _pcInputs;
    Mover _mover;
    Rotator _rotator;

    [SerializeField] float _forceSpeed, _rotatoSpeed;

    public float forceSpeed => _forceSpeed;
    public float rotatoSpeed => _rotatoSpeed;


    bool _isForce;
    float _rotatorInputs;
    private void Awake()
    {
        _pcInputs = new PcInputs();
        _mover = new Mover(this);
        _rotator = new Rotator(this);
    }
    private void Update()
    {
        if (_pcInputs.foceButtonDown)
        {
            _isForce = true;
        }
        else
        {
            _isForce = false;
        }
        _rotatorInputs = _pcInputs.LeftRight;

    }
    private void FixedUpdate()
    {
        if (_isForce)
        {
            _mover.Tick();

        }
        _rotator.Tick(_rotatorInputs);
    }
}
