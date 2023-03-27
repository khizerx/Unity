using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class AtHiveState : BeeState
{
    public AtHiveState(Bee _bee) : base(_bee)
    {
    }
    public override void Enter()
    {
        
        _bee.GetComponent<SpriteRenderer>().color = Color.green;
        GameLogic._instance.bees.Remove(_bee.gameObject);
        if(_bee.currentPayload > 0 && !ChaseController._instance.IsAnyBirdInRange(_bee))
        {
            _bee.SetState(new DancingState(_bee));
        }

      
    }
    public override void LogicUpdate()
    {
        if (_bee.energy <= _bee.maxEnergy)
        {
            _bee.energy += Time.deltaTime * 0.2f;
        }
        else
        {
            if (!ChaseController._instance.IsAnyBirdInRange(_bee))
            {

                _bee.SetState(new SearchingState(_bee));
            }
        }
        
        



        if(Vector3.Distance(_bee.transform.position,_bee._hive.position) > 0.1f)
        {
            _bee.Move(_bee._hive.position, 0f);
        }

    }

    public override void Exit()
    {    
        GameLogic._instance.bees.Add(_bee.gameObject);      
    }

}