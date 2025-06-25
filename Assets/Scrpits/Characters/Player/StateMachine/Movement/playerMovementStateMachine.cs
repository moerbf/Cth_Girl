using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementStateMachine : StateMachine 
{
    public PlayerIdlingState IdlingState { get; }

    public PlayerIdlingState WalkingState { get; }

    public PlayerIdlingState RunningState { get; }

    public PlayerIdlingState SprintingState { get; }

    public PlayerMovementStateMachine()
    {
        IdlingState = new PlayerIdlingState();

        WalkingState = new PlayerWalkingState();
        RunningState = new PlayerRunningState();
        SprintingState = new PlayerSprintingState();



    }
}
