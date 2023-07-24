using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager _Instance { get; private set; }

    private void Start()
    {
        _Instance = this;
    }

    public void SFXPlay(string name, AudioClip clip)
    {
        GameObject go = new GameObject(name + "sound");
        AudioSource audioSource = go.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.Play();

        Destroy(go, clip.length);
    }
}
