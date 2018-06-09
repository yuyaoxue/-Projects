using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMananager : MonoBehaviour
{
    public static GameMananager Instance;
    private void Awake()
    {
        Instance = this;
    }
    public bool isStart = false;
    private void Start()
    {
        isStart = false;
    }



    // Use this for initialization
    [SerializeField]
    private GameObject _bird;

    [SerializeField]
    private GameObject wallPrefab;
}
