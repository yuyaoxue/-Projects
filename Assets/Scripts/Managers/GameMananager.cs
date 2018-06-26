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
        scoreMgr = new ScoreManager();
    }
   
    private void Start()
    {
        _birdSpawn.Init();
        _backManager.Init();

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
        scoreMgr.InitScores();
        _birdSpawn.Init();
        _Pipe.Init();
        _ground.Init();
        _backManager.Init();
        InitState();
        SetBird();
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
        UIManager.Instance.PopPanel(UIType.InGamePanel);
        yield return new WaitForSeconds(1);
        UIManager.Instance.PushPanel(UIType.GameOverPanel);
    }
    private void InitState()
    {
        IsGameOver = false;
    }

    public void SetBird()
    {
        _bird = _birdSpawn.currentBird;
    }

    public void SetScore(int score)
    {
        scoreMgr.CurrentScore = score;
    }

    private bool _isStart = false;
    private Bird _bird;
    [SerializeField]
    private PipeMove _Pipe;
    [SerializeField]
    private GroundMove _ground;
    [SerializeField]
    private BirdSpawn _birdSpawn;
    [SerializeField]
    private BackGroundManager _backManager;
    public ScoreManager scoreMgr;
}
