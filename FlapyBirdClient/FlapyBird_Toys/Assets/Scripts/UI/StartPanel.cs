using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : BasePanel
{
    public void OnReadyHandle()
    {
        UIManager.Instance.PopPanel(UIType.StartPanel);
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
