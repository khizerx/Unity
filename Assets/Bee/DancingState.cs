using System.Collections;
using System.Collections.Generic;
using UnityEngine;



class DancingState : BeeState
{
    public DancingState(Bee _bee) : base(_bee)
    {
    }


    private float t;
    private float _danceSpeed = 10f;
    public override void Enter()
    {
        _bee.GetComponent<SpriteRenderer>().color = Color.blue;
        _bee.transform.position += new Vector3(Random.Range(-2, 3), Random.Range(-1, 1), 0);


    }

    public override void LogicUpdate()
    {
        t += Time.deltaTime;

        _bee.transform.position += new Vector3(0, Mathf.Sin(t * _danceSpeed) * 0.1f, 0);

        if(_bee.currentPayload <= 0)
        {
            _bee.currentPayload = 0; //normalize 
            _bee.SetState(new AtHiveState(_bee));
        }


        _bee.currentPayload -= 0.2f * Time.deltaTime;
    
    }

}

