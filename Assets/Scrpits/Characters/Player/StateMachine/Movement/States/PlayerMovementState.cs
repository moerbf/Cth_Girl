using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementState : IState
{

    public void Enter()
    {
        Debug.Log("State" + GetType().Name);
    }

    public void Exit()
    {
        
    }

    public void HandleInput()
    {
        
    }

    public void PhysicsUpdate()
    {
       
    }

    public void Update()
    {
        
    }
}
