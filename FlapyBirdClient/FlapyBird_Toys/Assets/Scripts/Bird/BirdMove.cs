using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMove : MonoBehaviour
{
   

    void Awake()
    {
        _Rigidbody2D = GetComponent<Rigidbody2D>();
        _Animator = GetComponent<Animator>();
        _Collision = GetComponent<BirdCollision>();
    }
    void FixedUpdate()
    {
        if (GameMananager.Instance.IsStart)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                _Speed += 1;
                _Rigidbody2D.velocity = Vector2.up * _Speed;
                AudioManager.Instance.PlayAudioEffect(AudioType.Wing);
            }
            _Speed = 1;
        }
        else
        {
            if (Time.frameCount % 10 == 0)
            {
                if (IsFall)
                {
                    _Rigidbody2D.velocity = Vector2.up * 0.05f;
                    IsFall = false;
                }
                else
                {
                    _Rigidbody2D.velocity = Vector2.down * 0.05f;
                    IsFall = true;
                }
            }
        }
    }
    public void Init()
    {
        this.gameObject.transform.localPosition = Vector3.zero;
        _Speed = 1f;
        IsFall = true;
    }

    public void StartGame()
    {
        _Rigidbody2D.gravityScale = 1;
        _Animator.enabled = true;
    }

    public void GameOver()
    {
        _Rigidbody2D.gravityScale = 0;
        _Animator.enabled = false;
    }
    private BirdCollision _Collision;
    private Rigidbody2D _Rigidbody2D;
    private Animator _Animator;
    private float _Speed;
    private bool IsFall;
}
