using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VagonController : MonoBehaviour
{
    [Header("Vagon Settings")]
    [SerializeField]
    private float _movementSpeed = 1F;
    [SerializeField]
    private float _minMovementSpeed = 3F;
    [SerializeField]
    private float _maxMovementSpeed = 3F;
    [SerializeField]
    private float _addableMovementSpeedCoefficient = 0.1F;
    [SerializeField]
    private float _normalizableMovementSpeedCoefficient = 0.03F;
    private int _vagonLevel = 1;
    private SplineFollower _splineFollower;

    private void Awake()
    {
        _splineFollower = GetComponent<SplineFollower>();
        InputHandler.OnClick += AddSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        CheckInteractionWithPassenger(other);
    }

    private void Update()
    {
        NormalizeSpeed();
    }

    private void CheckInteractionWithPassenger(Collider col) 
    {
        if (col.TryGetComponent(out IInteractable interactable))
        {
            Passanger passanger = interactable as Passanger;
            interactable.Interact(passanger);
            Services.Singletone.Economy.AddCash(_vagonLevel);
        }
    }

    private void AddSpeed() 
    {
        _movementSpeed += _addableMovementSpeedCoefficient;
        float targetSpeed = Mathf.Clamp(_movementSpeed,_minMovementSpeed, _maxMovementSpeed);
        _movementSpeed = targetSpeed;
        _splineFollower.followSpeed = _movementSpeed;
    }

    private void NormalizeSpeed() 
    {
        if (_movementSpeed > _minMovementSpeed) 
        {
            _movementSpeed -= _normalizableMovementSpeedCoefficient * Time.deltaTime;
            _splineFollower.followSpeed = _movementSpeed;
        }
    }
}
