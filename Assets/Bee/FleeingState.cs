using System.Collections;
using System.Collections.Generic;
using UnityEngine;



class FleeingState : BeeState
{
    public FleeingState(Bee _bee,Transform chaser) : base(_bee)
    {
    }
    Vector3 _point;
 
    public override void Enter()
    {
        _bee.GetComponent<SpriteRenderer>().color = Color.red;
        _point =_bee._hive.position;   
    }

    public override void LogicUpdate()
    {
     
        _bee.Move(_point, 0.3f);
       

        if (Vector3.Distance(_bee.transform.position, _point) < 0.1f)
        {
            _bee.SetState(new AtHiveState(_bee));
        }
    }
   
}

