using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMove : MonoBehaviour
{
    private Rigidbody2D _Rigidbody2D;
    private float _Speed;
    private bool boo;

    void Start()
    {
        _Rigidbody2D = GetComponent<Rigidbody2D>();
        _Speed = 1f;
        boo = true;
    }
    void FixedUpdate()
    {
        if (Time.frameCount % 10 == 0)
        {
            if (boo)
            {
                _Rigidbody2D.velocity = Vector2.up * 0.05f;
                boo = false;
            }
            else
            {
                _Rigidbody2D.velocity = Vector2.down * 0.05f;
                boo = true;
            }
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            GameMananager.Instance.isStart = true;
            _Rigidbody2D.gravityScale = 1;
            _Speed += 1;
            _Rigidbody2D.velocity = Vector2.up * _Speed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            _Speed += 1;
            _Rigidbody2D.velocity = Vector2.down * _Speed;
        }
        _Speed = 1;
    }
}
