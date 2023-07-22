using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundObjManager : MonoBehaviour
{
    public static SoundObjManager instance {  get; private set; }

    public GameObject soundManager;
    public GameObject audioSource;

    void Awake() 
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
