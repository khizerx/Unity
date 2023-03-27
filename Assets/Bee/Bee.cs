using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : StateMachine
{
    public float speed = 12;
    public float energy = 2;
    public float maxEnergy = 3;
    public float maxPayload = 2;
    public float currentPayload = 0;

   [HideInInspector] public Transform _hive;

    void Start()
    {
        SetState(new SearchingState(this));
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(6f);
        SetState(new FleeingState(this, null));
    }
    public void SetHive(Transform hive)
    {
        _hive = hive;
    }
    public void Move(Vector3 PosToMoveTo, float useEnergy)
    {


        transform.position = Vector2.MoveTowards(transform.position, PosToMoveTo, speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, 1);

        energy -= useEnergy * Time.deltaTime;

    //    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.FromToRotation(transform.position, PosToMoveTo - transform.position), 7 * Time.deltaTime);

    }

    private void FixedUpdate()
    {
        BeeState.LogicUpdate();
    }

   



}
