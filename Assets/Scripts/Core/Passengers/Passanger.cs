using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passanger : MonoBehaviour, IInteractable
{
    [SerializeField]
    private float _passengerMovementSpeed;
    private Animator _passengerAnimator;
    #region PassangerStates
    private PassengerIdleState _passengerIdleState;
    private PassangerRunState _passengerRunState;
    private StateMachine _passengerStateMachine;
    #endregion
    internal Action<Passanger> OnPassengerDestroy;
    private bool _isRunning { get; set; } = false;

    private void Awake()
    {
        _passengerAnimator = GetComponent<Animator>();
        _passengerIdleState = new PassengerIdleState(this.transform, _passengerAnimator);
        _passengerRunState = new PassangerRunState(this.transform, _passengerAnimator, _passengerMovementSpeed);
        _passengerStateMachine = new StateMachine();
        _passengerStateMachine.Initialize(_passengerIdleState);
    }

    private void Update()
    {
        if (!_isRunning) return;

        _passengerRunState.Update();
    }

    internal void SetPassengerState(PassengerStates passengerState) 
    {
        switch (passengerState) 
        {
            case PassengerStates.Idle:
                _passengerStateMachine.ChangeState(_passengerIdleState);
                _isRunning = false;
                print("Idle state");
                break;

            case PassengerStates.Run:
                _passengerStateMachine.ChangeState(_passengerRunState);
                _isRunning = true;
                print("Run state");
                break;
        }
    }

    public void Interact(Passanger passenger)
    {
        OnPassengerDestroy?.Invoke(this);
    }

    internal enum PassengerStates 
    {
      Idle,
      Run
    }
}
