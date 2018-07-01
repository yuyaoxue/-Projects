using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOverPanel : BasePanel {

    public override void OnEnter()
    {
        base.OnEnter();
    }
    private void OnEnable()
    {
        SetScore();
    }
    private void SetScore()
    {
        _highestText.text = GameMananager.Instance.scoreMgr.BestScore.ToString();
        _lastText.text = GameMananager.Instance.scoreMgr.LastScore.ToString();
        newIcon.gameObject.SetActive(GameMananager.Instance.scoreMgr.IsNewBestScore);
        SetMedal();
    }

    private void SetMedal()
    {
        int score = GameMananager.Instance.scoreMgr.LastScore;
        int stage = score / stageUnit;
        int len = _medals.Length;
        if (stage> len)
        {
            stage = len;
        }
        for(int i = 0;i< len; i++)
        {
            _medals[i].gameObject.SetActive(false);
        }
        if(stage>=1)
          _medals[stage - 1].gameObject.SetActive(true);
    }
    public void OnStartHandle()
    {
        GameMananager.Instance.Ready();
        UIManager.Instance.PopPanel(UIType.GameOverPanel);
        UIManager.Instance.PushPanel(UIType.ReadyPanel);

    }
    public void OnRankHandle()
    {
        Application.Quit();
    }

    [SerializeField]
    private Button _btnStart;
    [SerializeField]
    private Button _rank;

    [SerializeField]
    private Text _highestText;
    [SerializeField]
    private Text _lastText;
    [SerializeField]
    private Image newIcon;
    [SerializeField]
    private Image[] _medals;
    private int stageUnit = 10;

}
