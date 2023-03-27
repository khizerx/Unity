using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : StateMachine
{
    public Transform path;
    public Transform nest;
    public float speed;

    public float _energy = 10;
    public float _maxEnergy;

    public bool isChasing = false;

    void Start()
    {
        transform.position = nest.position;

        //_maxEnergy = _energy;

        SetState(new RestingState(this));    

    }


    public void SetEnergyToMax()
    {
        _energy = _maxEnergy;
    }
    public void Move(Vector3 PosToMoveTo, float useEnergy)
    {
        transform.position = Vector2.MoveTowards(transform.position, PosToMoveTo, speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, 1);

        _energy -= useEnergy * Time.deltaTime;

       transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.FromToRotation(transform.position, PosToMoveTo - transform.position), 7 * Time.deltaTime);

    }
  
    private void FixedUpdate()
    {
        BirdState.LogicUpdate();


    }

}



   

