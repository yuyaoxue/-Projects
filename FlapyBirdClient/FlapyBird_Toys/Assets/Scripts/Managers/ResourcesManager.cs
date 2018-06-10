using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager
{
    private static ResourcesManager _instance;
    public static ResourcesManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ResourcesManager();
            }
            return _instance;
        }
    }

    public GameObject LoadPanel(string panelName)
    {
        GameObject GO = null;
        Object obj = Resources.Load("UI/"+panelName);
        if(obj!=null)
        {
            GO = obj as GameObject;
           
        }
        return GO;
    }

    public GameObject Load(string name)
    {
        return null;
    }
  
}
