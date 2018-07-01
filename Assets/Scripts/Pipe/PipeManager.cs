using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeManager : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
       

    }

    public void Init()
    {
        bolliders = transform.GetComponentsInChildren<BoxCollider2D>();
    }

    public void StartGame()
    {
        OnEnableBoxCollider();
    }
    public void GameOver()
    {
        UnEnableBoxCollider();
    }
    public void Clear()
    {
        bolliders = null;
    }

    private void OnEnableBoxCollider()
    {
        for(int i = 0;i< bolliders.Length;i++)
        {
            bolliders[i].enabled = true;
        }
    }
	
    private void UnEnableBoxCollider()
    {
        for (int i = 0; i < bolliders.Length; i++)
        {
            bolliders[i].enabled = false;
        }
    }

   

    private BoxCollider2D[] bolliders;
}
