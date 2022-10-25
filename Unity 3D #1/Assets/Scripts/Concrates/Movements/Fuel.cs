using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    [SerializeField] float _maxFuel = 100f;
    [SerializeField] float _currentFuel;
    [SerializeField] ParticleSystem _particleSystem;

    public bool Min => _currentFuel < 0.2f;
    private void Awake()
    {
        _currentFuel = _maxFuel;


    }


    public void fuelIncrase(float increase)
    {
        _currentFuel += increase;
        _currentFuel = Mathf.Min(_currentFuel, _maxFuel);
        if (_particleSystem.isPlaying)
        {
            _particleSystem.Stop();
        }
    }


    public void fuelDecrase(float decrease)
    {
        _currentFuel -= decrease;
        _currentFuel = Mathf.Max(_currentFuel, 0f);
        if (!_particleSystem.isPlaying)
        {
            _particleSystem.Play();
        }
    }
}
