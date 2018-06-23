using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyPanel : BasePanel
{
    public override void OnEnter()
    {
        base.OnEnter();
        GameMananager.Instance.Init();
    }

    public void OnStartHandle()
    {
        AudioManager.Instance.PlayAudioEffect(AudioType.Swooshing);
        UIManager.Instance.PopPanel(UIType.ReadyPanel);
        GameMananager.Instance.StartGame();
        UIManager.Instance.PushPanel(UIType.InGamePanel);
    }
}
