using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PcInputs _pcInputs;
    Mover _mover;
    Rotator _rotator;
    Fuel _fuel;

    [SerializeField] float _forceSpeed, _rotatoSpeed;

    public float force_Speed => _forceSpeed;
    public float rotational_speed => _rotatoSpeed;


    bool _isForce;
    float _rotatorInputs;
    bool _canMove;
    private void Awake()
    {
        _canMove = true;
        _fuel = GetComponent<Fuel>();
        _pcInputs = new PcInputs();
        _mover = new Mover(this);
        _rotator = new Rotator(this);
    }
    private void OnEnable()
    {
        GameManager.Instance.onGameOver += HandleOnEventTriggered;
        GameManager.Instance.onMissionSucces += HandleOnEventTriggered;
    }
    private void OnDisable()
    {
        GameManager.Instance.onGameOver -= HandleOnEventTriggered;
        GameManager.Instance.onMissionSucces -= HandleOnEventTriggered;
    }




    private void Update()
    {
        if (!_canMove)
        {
            return;
        }
        if (_pcInputs.foceButtonDown && !_fuel.Min)
        {
            _isForce = true;

        }
        else
        {
            _isForce = false;
            _fuel.fuelIncrase(0.01f);
        }
        _rotatorInputs = _pcInputs.leftRight;

    }
    private void FixedUpdate()
    {
        if (_isForce)
        {
            _mover.Tick();

            _fuel.fuelDecrase(0.2f);

        }
        _rotator.Tick(_rotatorInputs);
    }



    private void HandleOnEventTriggered()
    {
        _canMove = false;
        _isForce = false;
        _rotatoSpeed = 0f;
        _fuel.fuelIncrase(0);
    }

}
