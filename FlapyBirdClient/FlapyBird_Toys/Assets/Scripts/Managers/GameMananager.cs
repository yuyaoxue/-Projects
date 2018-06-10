using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMananager : MonoBehaviour
{
    public static GameMananager Instance;
    private void Awake()
    {
        Instance = this;
        IsStart = false;
       
    }

    public bool IsStart
    {
        get { return isStart; }
        private set
        {
            isStart = value;
        }
    }

    public void Init()
    {
        _bird.Init();
        _ground.Init();
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

    private bool isStart = false;
    [SerializeField]
    private BirdMove _bird;
    [SerializeField]
    private PipeMove _Pipe;
    [SerializeField]
    private GroundMove _ground;
}
