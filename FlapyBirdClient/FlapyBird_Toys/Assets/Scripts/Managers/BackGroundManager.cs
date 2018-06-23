using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
        groundCount = grounds.Length;
    }
    public void Init()
    {
        RandowmBackGround();
    }
    private void RandowmBackGround()
    {
        int index = Random.Range(0, groundCount);
        //Debug.LogError("ground index:" + index);

        for (int i = 0; i < groundCount; i++)
        {
            grounds[i].SetActive(false);
        }
        grounds[index].SetActive(true);
    }

    private int groundCount;
    [SerializeField]
    private GameObject[] grounds;
}
