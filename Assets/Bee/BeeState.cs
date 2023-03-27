using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BeeState : MonoBehaviour
{
    protected readonly Bee _bee;

    public BeeState(Bee bee)
    {
        _bee = bee;
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
  

}

