using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        _move = GetComponent<BirdMove>();
        _collision = GetComponent<BirdCollision>();
    }

    public void Init()
    {
        _move.Init();
        _collision.Init();
    }

    public void StartGame()
    {
       if(_move!=null)
        {
            _move.StartGame();
        }
    }

    public void GameOver()
    {
        if (_move != null)
        {
            _move.GameOver();
        }
    }

    private BirdMove _move;
    private BirdCollision _collision;
}
