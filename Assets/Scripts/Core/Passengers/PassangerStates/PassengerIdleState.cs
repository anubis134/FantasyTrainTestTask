using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerIdleState : State
{
    private Transform _passengerTransform;
    private Animator _passengerAnimator;

    internal PassengerIdleState(Transform passengerTransform, Animator passengerAnimator)
    {
        _passengerTransform = passengerTransform;
        _passengerAnimator = passengerAnimator;
    }

    public override void Enter()
    {
        base.Enter();
        _passengerAnimator.SetTrigger("Idle");
        _passengerAnimator.SetBool("Run", false);
        _passengerAnimator.SetBool("Idle", true);
    }

    public override void Exit()
    {
        base.Exit();
        _passengerAnimator.SetBool("Run", true);
        _passengerAnimator.SetBool("Idle", false);
    }
}
