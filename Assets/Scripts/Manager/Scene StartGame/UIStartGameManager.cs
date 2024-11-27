using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIStartGameManager : Singleton<UIStartGameManager>
{
    [SerializeField] private GameObject uIFileSave;
    [SerializeField] private GameObject uISetting;

    protected override void Start()
    {
        base.Start();
        AudioManager.Instance.PlayMusic(AudioClipName.startGame);
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIFileSave();
        this.LoadUISetting();

    }
    protected virtual void LoadUIFileSave()
    {
        if (uIFileSave != null) return;
        this.uIFileSave = GameObject.Find("UIFileSave");
        Debug.Log(transform.name + ": LoadUIFileSave", gameObject);
    }
    protected virtual void LoadUISetting()
    {
        if (uISetting != null) return;
        this.uISetting = GameObject.Find("UISetting");
        Debug.Log(transform.name + ": LoadUISetting", gameObject);
    }


    public virtual void OpenUIFileSave()
    {
        uIFileSave.SetActive(true);
        uIFileSave.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), 1f, false).SetEase(Ease.InOutBack).OnComplete(() =>
        {

        });
    }

    public virtual void CloseUIFileSave()
    {
        uIFileSave.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, -1000f), 0.3f, false).SetEase(Ease.OutBack).OnComplete(() =>
        {
            uIFileSave.SetActive(false);
        });
    }

    public virtual void OpenUISetting()
    {
        uISetting.SetActive(true);
        uISetting.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), 1f, false).SetEase(Ease.InOutBack).OnComplete(() =>
        {

        });
    }

    public virtual void CloseUISetting()
    {

        uISetting.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, -1000f), 0.3f, false).SetEase(Ease.OutBack).OnComplete(() =>
        {
            uISetting.SetActive(false);
        });
    }

}
