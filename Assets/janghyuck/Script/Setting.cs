using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public Slider MusicSlider;
    private void Start()
    {
        MusicSlider.value = SoundObjManager.Instance.musicvolume;
    }

    public void SetMusicVolume(float volume)
    {
        SoundObjManager.Instance.musicsource.volume = volume;
        SoundObjManager.Instance.musicvolume = volume;
    }
}
