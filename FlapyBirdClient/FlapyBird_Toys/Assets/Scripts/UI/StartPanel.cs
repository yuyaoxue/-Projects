using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : BasePanel
{
    public void OnReadyHandle()
    {
        AudioManager.Instance.PlayAudioEffect(AudioType.Swooshing);
        UIManager.Instance.PopPanel(UIType.StartPanel);
        UIManager.Instance.PushPanel(UIType.ReadyPanel);
    }
    public void OnRankHandle()
    {
        AudioManager.Instance.PlayAudioEffect(AudioType.Swooshing);
        Application.Quit();
    }

    [SerializeField]
    private Button BtnStart;
    [SerializeField]
    private Button Rank;
}
