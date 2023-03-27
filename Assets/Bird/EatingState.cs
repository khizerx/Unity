using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EatingState : BirdState
{
    public EatingState(Bird _bird) : base(_bird)
    {
    }

    public override void Enter()
    {
        _bird.GetComponent<SpriteRenderer>().color = Color.green;
        _bird.SetEnergyToMax();
    }

    float _t;
    public override void LogicUpdate()
    {
        _t += Time.deltaTime;
        if(_t > 2f)
        {
            _bird.SetState(new FlyingState(_bird));
        }
    }



}
