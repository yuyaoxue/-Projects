using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager
{
    private  const string AudioPath = "Sounds/";
    private const string UIPath = "UI/";
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
        Object obj = Resources.Load(UIPath + panelName);
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

    public AudioClip LoadAudio(string name)
    {
        AudioClip clip = null;
        clip = Resources.Load<AudioClip>(AudioPath + name);
        if(clip==null)
        {
            Debug.LogError("audio not found name :"+name);
        }
        return clip;
    }
  
}
