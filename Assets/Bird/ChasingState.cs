using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class ChasingState : BirdState
{
    Bee _chasedBee;
    public ChasingState(Bird _bird, Bee _bee) : base(_bird)
    {
        _chasedBee = _bee;
    }
    public override void Enter()
    {
        if (_bird._energy < _bird._maxEnergy * 1 / 3)
        {
            _bird.SetState(new HeadingHomeState(_bird));
            return;
        }
        _bird.isChasing = true;
        _bird.GetComponent<SpriteRenderer>().color = Color.green;
    }

    public override void LogicUpdate()
    {
        if (_bird._energy < _bird._maxEnergy * 1 / 3)
        {
            _bird.SetState(new HeadingHomeState(_bird));
        }

        


        //if bee has hide in hive
        if ((Vector3.Distance(_bird.transform.position, _chasedBee.transform.position) < ChaseController._instance.detectionRange) && GameLogic._instance.bees.Contains(_chasedBee.gameObject) && _chasedBee != null)
        {
            _bird.Move(_chasedBee.transform.position, 0.8f);
            if ((Vector3.Distance(_bird.transform.position, _chasedBee.transform.position) < 0.3f))
            {
                GameLogic._instance.bees.Remove(_chasedBee.gameObject);
                ChaseController._instance.Killed(_bird, _chasedBee);
                Destroy(_chasedBee.gameObject);
                _bird.SetState(new EatingState(_bird));
            }
        }
        else
        {
            ChaseController._instance.Escaped(_bird, _chasedBee);
            _bird.SetState(new FlyingState(_bird));
   
        }



   
    
    }

    public override void Exit()
    {
        _bird.isChasing = false;
    }


}


