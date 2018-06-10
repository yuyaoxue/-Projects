using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMove : MonoBehaviour
{
   

    void Awake()
    {
        _Rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
       
    }
    void FixedUpdate()
    {
        if (GameMananager.Instance.IsStart)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
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
        else
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
        }
    }
    public void Init()
    {
        this.gameObject.transform.localPosition = Vector3.one;
        _Speed = 1f;
        boo = true;
    }

    public void StartGame()
    {
        _Rigidbody2D.gravityScale = 1;
        _animator.enabled = true;
    }

    public void GameOver()
    {
        _Rigidbody2D.gravityScale = 0;
        _animator.enabled = false;
    }

    private Rigidbody2D _Rigidbody2D;
    private Animator _animator;
    private float _Speed;
    private bool boo;
}
