using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOverPanel : BasePanel {

    public void SetScore()
    {

    }

    public void OnStartHandle()
    {
        UIManager.Instance.PopPanel(UIType.GameOverPanel);
        UIManager.Instance.PushPanel(UIType.ReadyPanel);
    }
    public void OnRankHandle()
    {
        Application.Quit();
    }

    [SerializeField]
    private Button BtnStart;
    [SerializeField]
    private Button Rank;
}
