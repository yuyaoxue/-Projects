using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FSMState
{
    protected Dictionary<Transition, StateID> maps = new Dictionary<Transition, StateID>();
    protected StateID StateID;
    public StateID ID { get { return StateID; } }
    public void AddTransition(Transition trans,StateID id)
    {
        if(trans==Transition.NullTransition)
        {
          //  Debug.LogError("trans state is NullTranssition");
            return;
        }

        if(id == StateID.NullStateID)
        {
         //   Debug.LogError("id is NullStateID");
            return;
        }

        if(maps.ContainsKey(trans))
        {
          //  Debug.LogError("states already  has "+ trans);
            return;
        }

        maps.Add(trans,id);
    }

    public StateID GetOutputState(Transition trans)
    {
        if(maps.ContainsKey(trans))
        {
            return maps[trans];
        }
        return StateID.NullStateID;
    }


    public virtual void DoBeforeEntering() { }
    public virtual void DoBeforeLeaving() { }
    public abstract void Reason();
    public abstract void Act();



}
