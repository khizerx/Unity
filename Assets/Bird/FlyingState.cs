using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class FlyingState : BirdState
{
    private Transform[] waypoints;
    private Vector3 velocity;
    private int waypointCount = 0;

    public FlyingState(Bird _bird) : base(_bird)
    {  
    }
    public override void Enter()
    {
        _bird.isChasing = false;
        if (_bird._energy < _bird._maxEnergy * 1 / 2)
        {
            _bird.SetState(new HeadingHomeState(_bird));
            return;
        }

        waypoints = new Transform[_bird.path.childCount];
        for(int i = 0; i < _bird.path.childCount; i++)
        {
            waypoints[i] = _bird.path.GetChild(i);
        }
        _bird.GetComponent<SpriteRenderer>().color = Color.red;
    }


    public override void LogicUpdate()
    {
        if (waypoints != null)
        {

            _bird.Move(waypoints[waypointCount].position, 0.4f);

            if ((Vector3.Distance(_bird.transform.position, waypoints[waypointCount].position) < 0.1))
            {
                waypointCount++;
                if (waypointCount == waypoints.Length - 1)
                {
                    waypointCount = 0;
                }
            }
        }
    }
    public override void Exit()
    {       
    }

}

