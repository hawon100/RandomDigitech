using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Effect : MonoBehaviour
{
    public Slider EffectSlider;
    private void Start()
    {
        EffectSlider.value = SoundObjManager.Instance.effectvolume;
    }
}
