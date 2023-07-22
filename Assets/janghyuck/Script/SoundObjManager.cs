using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundObjManager : MonoBehaviour
{
    public static SoundObjManager Instance { get; private set; }

    public AudioSource musicsource;

    private void Awake()
    {
        var objs = FindObjectsOfType<SoundObjManager>();
        if (objs.Length == 1)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetMusicVolume(float volume)
    {
        musicsource.volume = volume;
    }

}
