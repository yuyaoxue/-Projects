using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager:MonoBehaviour
{
    private Dictionary<string, AudioClip> _audioDict;
    private AudioSource AudioEffectSource;

    public static AudioManager Instance;

    private void Awake()
    {
        Instance = this;
        Init();
    }
    public void PlayAudioEffect(string soundName)
    {
        PlaySound(AudioEffectSource, soundName, 0.5f);
    }

    private void PlaySound(AudioSource audioSource,string soundName,float volume,bool loop = false)
    {
        AudioClip clip = null;
        if (_audioDict.ContainsKey(soundName))
        {
            clip = _audioDict[soundName];
        }
        else
        {
            clip =  ResourcesManager.Instance.LoadAudio(soundName);
            _audioDict.Add(soundName, clip);
        }
        if (clip == null) return;
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.loop = loop;
        audioSource.Play();
    }

    public void Clear()
    {
        if(_audioDict!=null)
        {
            _audioDict.Clear();
        }
    }

    private void Init()
    {
        _audioDict = new Dictionary<string, AudioClip>();
        GameObject audioSourceGO = new GameObject("AudioSource(GameObject)");
        AudioEffectSource = audioSourceGO.AddComponent<AudioSource>();
    }
}

public class AudioType
{
    public const string Die = "sfx_die";
    public const string Wing = "sfx_wing";
    public const string Hit = "sfx_hit";
    public const string Point = "sfx_point";
    public const string Swooshing = "sfx_swooshing";
}
