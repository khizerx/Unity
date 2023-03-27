using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BirdState : MonoBehaviour
{
    protected readonly Bird _bird;

    public BirdState(Bird bird)
    {
        _bird = bird;
    }
    public virtual void Enter()
    {
    }
    public virtual void LogicUpdate()
    {
    }
    public virtual void Exit()
    {
    }
    public virtual IEnumerator Flying()
    {
        yield break;
    }
    public virtual IEnumerator Chasing()
    {
        yield break;
    }
    public virtual IEnumerator Eating()
    {
        yield break;
    }
    public virtual IEnumerator Resting()
    {
        yield break;
    }

}
