using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundSetting : MonoBehaviour
{
    public AudioMixer audio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetMusic(float volumn)
    {
        audio.SetFloat("Music", volumn);
    }
    public void SetSFX(float volumn)
    {
        audio.SetFloat("SFX", volumn);
    }
}
