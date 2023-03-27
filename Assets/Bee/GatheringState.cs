using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class GatheringState : BeeState
{
    float t;
    public GatheringState(Bee _bee) : base(_bee)
    {
    }

    public override void Enter()
    {
        _bee.GetComponent<SpriteRenderer>().color = Color.yellow;
    }

    public override void LogicUpdate()
    {
        t += Time.deltaTime;
        if (t >= 2f)
        {
            t = 0;
            try    // if bee was captured during gahering
            {
                _bee.currentPayload += 1;
                _bee.SetState(new SearchingState(_bee));
            }
            catch { }
        }
      
    }

    public override void Exit()
    {
        
    }

}