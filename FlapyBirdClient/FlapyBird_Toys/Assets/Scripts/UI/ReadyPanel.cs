using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyPanel : BasePanel
{
    public override void OnEnter()
    {
        GameMananager.Instance.Init();
    }

    public void OnStartHandle()
    {
        UIManager.Instance.PopPanel(UIType.ReadyPanel);
        GameMananager.Instance.StartGame();
    }
}
