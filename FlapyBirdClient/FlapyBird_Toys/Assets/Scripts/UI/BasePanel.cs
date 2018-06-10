using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel : MonoBehaviour
{


    public void Reset()
    {
        this.gameObject.SetActive(false);
    }
    public virtual void OnExit()
    {
        this.gameObject.SetActive(false);
    }

    public virtual void OnEnter()
    {
        this.gameObject.SetActive(true);

    }

    public virtual void OnPause()
    {
        //  this.gameObject.SetActive(false);
    }
}
