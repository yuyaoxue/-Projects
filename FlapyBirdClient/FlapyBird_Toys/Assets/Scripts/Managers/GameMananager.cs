using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMananager : MonoBehaviour
{
    public static GameMananager Instance;
    public bool IsGameOver = false;

    private void Awake()
    {
        Instance = this;
        IsStart = false;
       
    }

    public bool IsStart
    {
        get { return _isStart; }
        private set
        {
            _isStart = value;
        }
    }

    public void Init()
    {
        _bird.Init();
        _ground.Init();
        _Pipe.Init();
        InitState();
    }

    public void StartGame()
    {
        IsStart = true;
        _bird.StartGame();
        _Pipe.StartGame();
        _ground.StartGame();

    }

    public void GameOver()
    {
        IsStart = false;
        _bird.GameOver();
        _Pipe.GameOver();
        _ground.GameOver();
        StartCoroutine(OpenGameOverPanel());
    }

    IEnumerator OpenGameOverPanel()
    {
        yield return new WaitForSeconds(1);
        UIManager.Instance.PushPanel(UIType.GameOverPanel);
    }
    private void InitState()
    {
        IsGameOver = false;
    }
    private bool _isStart = false;
    [SerializeField]
    private BirdMove _bird;
    [SerializeField]
    private PipeMove _Pipe;
    [SerializeField]
    private GroundMove _ground;
}
