﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        width =grounds[0].sprite.rect.width/ PixelsPerUnit;
        init();
    }

    private void init()
    {
        for (int i = 0; i < grounds.Length; i++)
        {
            grounds[i].transform.localPosition  = new Vector3(i * width,0,0);
        }
    }
    // Update is called once per frame
    void Update()
    {

        if(gameObject.transform.localPosition.x< -index * width)
        {
            SpriteRenderer temp = null;
            temp = grounds[0];
            grounds[0] = grounds[grounds.Length - 1];
            _endTran = grounds[grounds.Length - 1].transform;
            temp.transform.localPosition = new Vector3(_endTran.localPosition.x+width,0,0);
            grounds[grounds.Length - 1] = temp;
            index++;
        }
        gameObject.transform.localPosition += Vector3.left * 0.008f;
    }

    private Transform _startTran;
    private Transform _endTran;
    private float index = 1;
    private const int PixelsPerUnit = 100;
    private float width = 0;
    [SerializeField]
    private SpriteRenderer[] grounds;
}
