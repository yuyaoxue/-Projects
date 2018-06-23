using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public static UIManager Instance;

    private void Awake()
    {
        Instance = this;
        Init();
    }
    private Transform canvasTransform;
    private Transform CanvasTransform
    {
        get
        {
            if (canvasTransform == null)
            {
                canvasTransform = GameObject.Find("Canvas").transform;
            }
            return canvasTransform;
        }
    }

    private static Dictionary<UIType, BasePanel> UIDict;
    private static Dictionary<UIType, BasePanel> panelDict;

    // Use this for initialization
    private void Init()
    {
        UIDict = new Dictionary<UIType, BasePanel>();
        panelDict = new Dictionary<UIType, BasePanel>();
        PushPanel(UIType.StartPanel);
    }

    public BasePanel PushPanel(UIType type)
    {
        if (panelDict == null)
            panelDict = new Dictionary<UIType, BasePanel>();

        BasePanel panel = null;
        if(panelDict.ContainsKey(type))
        {
            panel = panelDict[type];
        }
        else
        {
            panel = GetPanel(type, type.ToString());
            panelDict.Add(type, panel);
        }
        panel.OnEnter();
        return panel;
    }
    public void PopPanel(UIType type)
    {
        if (panelDict == null)
            panelDict = new Dictionary<UIType, BasePanel>();
        if (panelDict.ContainsKey(type))
        {
            panelDict[type].OnExit();
        }
    }

    private BasePanel GetPanel(UIType type, string panelName)
    {
        BasePanel panel = null;
        if (UIDict.ContainsKey(type))
        {
            panel = UIDict[type];
        }
        else
        {
            GameObject obj = GameObject.Instantiate(ResourcesManager.Instance.LoadPanel(panelName));
            panel = obj.GetComponent<BasePanel>();
          //  panel.Reset();
            obj.transform.SetParent(CanvasTransform);
            obj.transform.localScale = Vector3.one;
            obj.transform.localPosition = Vector3.zero;
            UIDict.Add(type, panel);
        }
        return panel;
    }

    public void Clear()
    {
        UIDict.Clear();
        panelDict.Clear();
    }
}

public enum UIType
{
    None,
    GameOverPanel,
    ReadyPanel,
    StartPanel,
    InGamePanel,
}
