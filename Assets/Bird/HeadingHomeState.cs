using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class HeadingHomeState : BirdState
{

    public HeadingHomeState(Bird _bird) : base(_bird)
    {
    }


    public override void Enter()
    {
        _bird.GetComponent<SpriteRenderer>().color = Color.gray;
    }

    public override void LogicUpdate()
    {
        _bird.Move(_bird.nest.position, 0.8f);
        if ((Vector3.Distance(_bird.transform.position, _bird.nest.position) < 0.1f))
        {
            _bird.SetState(new RestingState(_bird));
        }
    }

}

