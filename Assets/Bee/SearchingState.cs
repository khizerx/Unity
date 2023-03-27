using System.Collections;
using System.Collections.Generic;
using UnityEngine;
class SearchingState : BeeState
{
    public SearchingState(Bee _bee) : base(_bee)
    {
    }

    
    Vector3 _point;
    List<GameObject> flowers = new List<GameObject>();

    float detectionRange = 4;


    public override void Enter()
    {
        _bee.GetComponent<SpriteRenderer>().color = Color.gray;
        if (_bee.currentPayload < _bee.maxPayload)
        {

            _point = _bee.transform.position + new Vector3(Random.Range(-3, 4), Random.Range(-3, 4), 0);
            
            flowers = SimulationArea.flowersObj;

            Debug.Log("started");
        }
        else
        {
            _bee.SetState(new FleeingState(_bee, null));
        }
    }  

    public Transform FlowerInRange()
    {
        List<Transform> _flowersInRange = new List<Transform>();

        foreach (GameObject b in flowers)
        {
            if (Vector2.Distance(_bee.transform.position, b.transform.position) < detectionRange)
            {
                _flowersInRange.Add(b.transform);
            }
        }

        if (_flowersInRange.Count == 0)
        {
            return null;
        }


        float minDist = Mathf.Infinity;
        Transform tMin = null;

        foreach (Transform t in _flowersInRange)
        {
            float dist = Vector2.Distance(t.position, _bee.transform.position);
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }

        return tMin;
    }

    public override void LogicUpdate()
    {
        if(_bee.energy < (_bee.maxEnergy / 1/2))
        {
            _point = _bee._hive.position;
            _bee.Move(_point, 0f);
            if (Vector3.Distance(_bee.transform.position, _point) < 0.1f)
            {
                _bee.SetState(new AtHiveState(_bee));
                
            }
        }






        if (FlowerInRange() != null)
        {
            _bee.Move(FlowerInRange().position, 0.1f);
            if (Vector2.Distance(_bee.transform.position, FlowerInRange().position) < 0.1f)
            {
                GameObject flower = FlowerInRange().gameObject;
                SimulationArea.flowersObj.Remove(flower);
                Destroy(flower);
                _bee.SetState(new GatheringState(_bee));
            }

        }
        else
        {
            //if outside of simulation area
            if (!SimulationArea.mapBounds.Contains(_point))
            {
                _point = _bee.transform.position + new Vector3(Random.Range(-3, 4), Random.Range(-3, 4), 0);
            }

            if (Vector3.Distance(_bee.transform.position, _point) < 0.1f)
            {
                _point = _bee.transform.position + new Vector3(Random.Range(-3, 4), Random.Range(-3, 4), 0);
              
            }

            _bee.Move(_point, 0.1f);
   
        }
    
    
    }

    public override void Exit()
    {
        Debug.Log("Exited searching");
    }

}