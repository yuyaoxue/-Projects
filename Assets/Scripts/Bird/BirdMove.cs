using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMove : MonoBehaviour
{
   

    void Awake()
    {
        _Rigidbody2D = GetComponent<Rigidbody2D>();
        _Animator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        if (GameMananager.Instance.IsStart)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                DownHandle();
            }
            UpHandle();
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


    public void DownHandle()
    {
        _Speed += 1;
        if (_Speed >= birdFlyMaximum_Y)
        {
            _Speed = 0;
        }
        _Rigidbody2D.velocity = Vector2.up * _Speed;
        AudioManager.Instance.PlayAudioEffect(AudioType.Wing);
    }

    public void UpHandle()
    {
        _Speed = 1;
    }
    private Rigidbody2D _Rigidbody2D;
    private Animator _Animator;
    private float _Speed;
    private bool IsFall;

    private const float birdFlyMaximum_Y = 2.4f;
}
