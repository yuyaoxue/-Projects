using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InGamePanel : BasePanel
{
    private void OnEnable()
    {
        SetCount();
    }

    private void Update()
    {
        if (GameMananager.Instance.scoreMgr.CurrentScore > count)
        {
            SetCount();
        }
    }
    private void SetCount()
    {
        count = GameMananager.Instance.scoreMgr.CurrentScore;
        _countText.text = count.ToString();
    }

    private int count = 0;
    [SerializeField]
    private Text _countText;
}
