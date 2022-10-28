using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassangerRunState : State
{
    private Transform _passengerTransform;
    private Animator _passengerAnimator;
    private float _passengerMovementSpeed;

    internal PassangerRunState(Transform passengerTransform, Animator passengerAnimator, float passengerMovementSpeed = 1F)
    {
        _passengerTransform = passengerTransform;
        _passengerAnimator = passengerAnimator;
        _passengerMovementSpeed = passengerMovementSpeed;
    }

    public override void Enter()
    {
        base.Enter();
        _passengerAnimator.SetBool("Run", true);
        _passengerAnimator.SetBool("Idle", false);
    }

    public override void Update()
    {
        base.Update();
        _passengerTransform.position += _passengerTransform.TransformDirection(Vector3.forward * _passengerMovementSpeed) * Time.deltaTime;
    }

    public override void Exit()
    {
        base.Exit();
        _passengerAnimator.SetBool("Run", false);
        _passengerAnimator.SetBool("Idle", true);
    }
}
