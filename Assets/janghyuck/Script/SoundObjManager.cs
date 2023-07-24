using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundObjManager : MonoBehaviour
{
    public static SoundObjManager Instance { get; private set; }
    public AudioSource musicsource;
    public float musicvolume = 1;
    public float effectvolume = 1;

    private void Awake()
    {
        musicsource.volume = musicvolume;
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
}
