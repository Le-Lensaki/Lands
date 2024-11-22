using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueStatus : LensakiMonoBehaviour
{
    [SerializeField] protected Image avatarActorBox;
    [SerializeField] protected TMP_Text textDialouge;
    [SerializeField] protected TMP_Text nameActor;

    [SerializeField] protected Dialogue currentDialogue;
    int currentTextLine;

    [Range(0f, 1f)]
    [SerializeField] protected float visibleTextPercent;
    [SerializeField] protected float timePerLetter = 0.05f;
    float totalTimeToType, currentTime;
    string lineToShow;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAvatarActor();
        this.LoadTextDialouge();
        this.LoadNameActor();
    }

    #region LoadComponents
    protected virtual void LoadAvatarActor()
    {
        if (avatarActorBox != null) return;
        
        avatarActorBox = this.transform.GetChild(0).GetChild(0).GetComponent<Image>();

        Debug.Log(transform.name + ": LoadAvatarActorBox " , gameObject);
    }
    protected virtual void LoadTextDialouge()
    {
        if (textDialouge != null) return;

        textDialouge = this.transform.GetChild(1).GetComponent<TMP_Text>();

        Debug.Log(transform.name + ": LoadTextDialouge ", gameObject);
    }

    protected virtual void LoadNameActor()
    {
        if (nameActor != null) return;

        nameActor = this.transform.GetChild(2).GetComponent<TMP_Text>();

        Debug.Log(transform.name + ": LoadNameActor ", gameObject);
    }

    #endregion

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!transform.gameObject.activeSelf) return;
            if (!ChoiceDialogController.Instance.gameObject.activeSelf)
            {
                if (visibleTextPercent < 1f)
                {
                    visibleTextPercent = 1f;
                    UpdateText();
                }
                else
                {
                    PushText();
                }
            }
        }

        if (visibleTextPercent < 1f)
        {
            TypeOutText();
        }
    }
    protected void TypeOutText()
    {
        if(visibleTextPercent >= 1f) { return; }
        currentTime += Time.deltaTime;
        visibleTextPercent = currentTime / totalTimeToType;
        visibleTextPercent = Mathf.Clamp(visibleTextPercent, 0f,1f);
        UpdateText();
    }

    void UpdateText()
    {
        
        int letterCount = (int)(lineToShow.Length * visibleTextPercent);
        textDialouge.text = lineToShow.Substring(0, letterCount);
        
    }

    public void PushText()
    {
        if(currentTextLine >= currentDialogue.content.Count)
        {
            
            Conclude();
            UpdateText();

        }
        else
        {
            CycleLine();
        }
    }
    void Conclude()
    {
        Show(false);
        ChoiceDialogController.Instance.DisableDialog();
    }

    void CycleLine()
    {
        UpdateAvatarActor();
        lineToShow = currentDialogue.content[currentTextLine].content;
        totalTimeToType = lineToShow.Length * timePerLetter;
        currentTime = 0f;
        visibleTextPercent = 0f;
        textDialouge.text = "";
        ChoiceDialogController.Instance.EnableDialog(currentDialogue.content[currentTextLine].choice);
        currentTextLine += 1;

    }

    public void SetDialogue(Dialogue dialogue)
    {
        Show(true);
       
        currentDialogue = dialogue;
        currentTextLine = 0;
        CycleLine();
    }

    void UpdateAvatarActor()
    {
        avatarActorBox.sprite = currentDialogue.content[currentTextLine].actor.avatar;
        nameActor.text = currentDialogue.content[currentTextLine].actor.name;
    }

    protected void Show(bool show)
    {
        this.gameObject.SetActive(show);
        
    }

}
