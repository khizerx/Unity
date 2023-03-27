using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class RestingState : BirdState
{
    private Transform[] waypoints;
    private Vector3 velocity;

    public RestingState(Bird _bird) : base(_bird)
    {
    }
    public override void Enter()
    {
        _bird.isChasing = false;
    }
    public override void LogicUpdate()
    {
        if (_bird._energy < _bird._maxEnergy)
        {
            _bird._energy += 5 * Time.deltaTime;
        }
        else
        {
            _bird.SetState(new FlyingState(_bird));
        }
    }
    public override void Exit()
    {

    }


}

