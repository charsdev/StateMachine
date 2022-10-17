using UnityEngine;
using Chars.StateMachine;
using System;

/// <summary>
/// This is a Test for the state machine class, is very simplistic use,
/// i dont really need to use for create a semaphore, but is simple to understand how to use it
/// </summary>
public class Lakitu : MonoBehaviour
{
    private readonly StateMachine<States> _stateMachine = new StateMachine<States>();
    [HideInInspector] public SpriteRenderer SpriteRenderer;
    public Sprite[] Sprites;
    public int index;

    public void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        SetupStateMachine();
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            index = index + 1 > Enum.GetValues(typeof(States)).Length ? 0 : index + 1;
            _stateMachine.SetCurrentState(index);
        }
    }

    public enum States
    {
        RED, YELLOW, GREEN
    }

    public void SetupStateMachine()
    {
        _stateMachine.InitStateMachine();
        _stateMachine.SetStateData((int)States.RED, new RedState(this, _stateMachine));
        _stateMachine.SetStateData((int)States.YELLOW, new YellowState(this, _stateMachine));
        _stateMachine.SetStateData((int)States.GREEN, new GreenState(this, _stateMachine));
        _stateMachine.SetCurrentState((int)States.RED);
    }
}

