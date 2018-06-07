using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMananager : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            NextMovePosition.x = _bird.transform.localPosition.x;
            NextMovePosition.y= _bird.transform.localPosition.y+ 1f;
            IsKeyDown = true;
        }
        if(IsKeyDown)
        {
            _bird.transform.localPosition = Vector3.Lerp(_bird.transform.localPosition, NextMovePosition, speed);
            _bird.transform.GetComponent<Rigidbody2D>().position = _bird.transform.localPosition;
        }
    }
    private bool IsKeyDown = false;
    private Vector3 NextMovePosition = Vector3.zero;
    private const float speed = 0.1f;
    [SerializeField]
    private GameObject _bird;
}
