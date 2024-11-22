using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [Header("Audio Source")]
    [SerializeField] protected AudioSource musicSource;
    [SerializeField] protected AudioSource SFXSource;

    [Header("File music")]
    [SerializeField] protected AudioClip startGame;
    [SerializeField] protected AudioClip background;
    [SerializeField] protected AudioClip hoe;
    [SerializeField] protected AudioClip cut;
    [SerializeField] protected AudioClip hitRock;
    [SerializeField] protected AudioClip chop;
    [SerializeField] protected AudioClip spray;
    [SerializeField] protected AudioClip seed;
    [SerializeField] protected AudioClip openChest;
    [SerializeField] protected AudioClip closeChest;
    [SerializeField] protected AudioClip collect;
    [SerializeField] protected AudioClip click;
    [SerializeField] protected AudioClip drag;
    [SerializeField] protected AudioClip drop;
    [SerializeField] protected AudioClip save;
    [SerializeField] protected AudioClip toolSwap;

    [SerializeField] protected VolumeSetting volumeSetting;
    public VolumeSetting VolumeSetting => volumeSetting;

    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMusicSource();
        this.LoadSFXSource();
        this.LoadVolumeSetting();

        LoadAudioClip(ref startGame, "StartGame");
        LoadAudioClip(ref background, "background");
        LoadAudioClip(ref hoe, "Hoe");
        LoadAudioClip(ref cut, "Cut");
        LoadAudioClip(ref hitRock, "HitRock");
        LoadAudioClip(ref chop, "Chop");
        LoadAudioClip(ref spray, "Spray");
        LoadAudioClip(ref seed, "Seed");
        LoadAudioClip(ref openChest, "OpenChest");
        LoadAudioClip(ref closeChest, "CloseChest");
        LoadAudioClip(ref collect, "Collect");
        LoadAudioClip(ref click, "Click");
        LoadAudioClip(ref drag, "Drag");
        LoadAudioClip(ref drop, "Drop");
        LoadAudioClip(ref save, "Save");
        LoadAudioClip(ref toolSwap, "ToolSwap");
    }
    
    protected virtual void LoadMusicSource()
    {
        if (musicSource != null) return;
        musicSource = transform.Find("Music").GetComponent<AudioSource>();

        Debug.Log(transform.name+ ": LoadMusicSource", gameObject);
    }
    protected virtual void LoadSFXSource()
    {
        if (SFXSource != null) return;
        SFXSource = transform.Find("SFX").GetComponent<AudioSource>();

        Debug.Log(transform.name + ": LoadSFXSource", gameObject);
    }
    protected virtual void LoadVolumeSetting()
    {
        if (volumeSetting != null) return;
        volumeSetting = transform.GetComponent<VolumeSetting>();

        Debug.Log(transform.name + ": LoadVolumeSetting", gameObject);
    }

    protected virtual void LoadAudioClip(ref AudioClip audioClip,  string nameFile)
    {
        if (audioClip != null) return;
        string resPath = "Music/";
        string nameSprite = nameFile;
        AudioClip[] audioClips = Resources.LoadAll<AudioClip>(resPath);
        foreach (var item in audioClips)
        {
            if (item.name == nameSprite) audioClip = item;
        }
        Debug.Log(transform.name + ": LoadAudioClip" + nameFile, gameObject);
    }

    #endregion

    public void LoadSaveVolume(float allvolume,float musicVolume,float sfxVolume)
    {
        volumeSetting.SetALLVolume(allvolume);
        volumeSetting.SetALLVolume(musicVolume);
        volumeSetting.SetALLVolume(sfxVolume);
    }


    public void PlayMusic(AudioClipName audioClipName)
    {
        switch (audioClipName)
        {
            case AudioClipName.background:
                musicSource.clip = background;
                musicSource.Play();
                break;
            case AudioClipName.startGame:
                musicSource.clip = startGame;
                musicSource.Play();
                break;
        }
    }
    public void PlaySFX(AudioClipName audioClipName)
    {
        switch (audioClipName)
        {
            case AudioClipName.background:
                SFXSource.PlayOneShot(background);
                break;
            case AudioClipName.startGame:
                SFXSource.PlayOneShot(startGame);
                break;
            case AudioClipName.hoe:
                SFXSource.PlayOneShot(hoe);
                break;
            case AudioClipName.chop:
                SFXSource.PlayOneShot(chop);
                break;
            case AudioClipName.spray:
                SFXSource.PlayOneShot(spray);
                break;
            case AudioClipName.seed:
                SFXSource.PlayOneShot(seed);
                break;
            case AudioClipName.openChest:
                SFXSource.PlayOneShot(openChest);
                break;
            case AudioClipName.closeChest:
                SFXSource.PlayOneShot(closeChest);
                break;
            case AudioClipName.collect:
                SFXSource.PlayOneShot(collect);
                break;
            case AudioClipName.click:
                SFXSource.PlayOneShot(click);
                break;
            case AudioClipName.drag:
                SFXSource.PlayOneShot(drag);
                break;
            case AudioClipName.drop:
                SFXSource.PlayOneShot(drop);
                break;
            case AudioClipName.save:
                SFXSource.PlayOneShot(save);
                break;
            case AudioClipName.hitRock:
                SFXSource.PlayOneShot(hitRock);
                break;
            case AudioClipName.toolSwap:
                SFXSource.PlayOneShot(toolSwap);
                break;
            case AudioClipName.cut:
                SFXSource.PlayOneShot(cut);
                break;
        }
    }
}

public enum AudioClipName
{
    background = 0,
    startGame =1,
    
    hoe = 2,
    chop =3,
    spray= 4,
    seed =5,
    openChest =6,
    closeChest = 7,
    collect = 8,
    click = 9,
    drag = 10,
    drop = 11,
    save = 12,
    hitRock = 13,
    toolSwap = 14,
    cut = 15,
}
