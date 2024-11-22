using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSetting : LensakiMonoBehaviour
{
    [SerializeField] protected AudioMixer audioMixer;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAudioMixer();
    }

    protected virtual void LoadAudioMixer()
    {
        if (this.audioMixer != null) return;
        string resPath = "Music/";
        string nameSprite = "AudioMixer";
        AudioMixer[] audioMixer = Resources.LoadAll<AudioMixer>(resPath);
        foreach (var item in audioMixer)
        {
            if (item.name == nameSprite) this.audioMixer = item;
        }
        Debug.LogWarning(transform.name + ": LoadAudioMixer " + resPath, gameObject);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("Music", Mathf.Log10(volume)*20);
    }

    public float GetMusicVolume()
    {
        float volume = 1;
            audioMixer.GetFloat("Music",out volume);
        return volume;
    }
    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
    }
    public float GetSFXVolume()
    {
        float volume = 1;
        audioMixer.GetFloat("SFX", out volume);
        return volume;
    }
    public void SetALLVolume(float volume)
    {
        audioMixer.SetFloat("All", Mathf.Log10(volume) * 20);
    }
    public float GetALLVolume()
    {
        float volume = 1;
        audioMixer.GetFloat("All", out volume);
        return volume;
    }
}
