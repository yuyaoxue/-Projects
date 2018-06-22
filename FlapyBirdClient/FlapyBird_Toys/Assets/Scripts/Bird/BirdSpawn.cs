using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawn : MonoBehaviour {

	// Use this for initialization
	void Start () {
        groundCount = _birds.Length;
    }

    public void Init()
    {
        RandowmBackGround();
    }
    private void RandowmBackGround()
    {
        int index = Random.Range(0, groundCount);
        Debug.LogError("bird index:"+index);
        for (int i = 0; i < groundCount; i++)
        {
            _birds[i].gameObject.SetActive(false);
        }
        _birds[index].gameObject.SetActive(true);
        currentBird = _birds[index];
        currentBird.Init();
    }
    public Bird currentBird;
    private int groundCount;
    [SerializeField]
    private Bird[] _birds;
}
