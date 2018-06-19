using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMSystem{
    private List<FSMState> states;
    private StateID currentStateID;
    public StateID CurrentStateID { get { return currentStateID; } }
    private FSMState currentState;
    public FSMState CurrentState { get { return currentState; } }

    public FSMSystem()
    {
        states = new List<FSMState>();
    }

    public void AddState(FSMState s)
    {
        if(s==null)
        {
            return;
        }

        if(states.Count==0)
        {
            states.Add(s);
            currentState = s;
            currentStateID = s.ID;
            return;
        }

        foreach(FSMState state in states)
        {
            if(state.ID == s.ID)
            {
                Debug.LogError("state is exist");
            }
        }

        states.Add(s);
    }

    public void DeleteState(StateID id)
    {
        if (id == StateID.NullStateID)
        {
            Debug.LogError("id is NullStateID");
            return;
        }

        // Search the List and delete the state if it's inside it  
        foreach (FSMState state in states)
        {
            if (state.ID == id)
            {
                states.Remove(state);
                return;
            }
        }
    }

    public void PerformTransition(Transition trans)
    {
        if (trans == Transition.NullTransition)
        {
            Debug.LogError("trans is NullTransition");
            return;
        }

        StateID id = currentState.GetOutputState(trans);
        if (id == StateID.NullStateID)
        {
            Debug.LogError("id is nullStateID");
            return;
        }

        currentStateID = id;
        foreach (FSMState state in states)
        {
            if (state.ID == currentStateID)
            {
                currentState.DoBeforeLeaving();

                currentState = state;

                currentState.DoBeforeEntering();
                break;
            }
        }
    }
}

public enum Transition
{
    NullTransition = 0,
    InStart,
    InReady,
    PlayGame,
    GoDie
}
public enum StateID{
    NullStateID,
    Start,
    Ready,
    InGame,
    GameOver
}