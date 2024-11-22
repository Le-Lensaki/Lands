using Assets.Scripts.Item.IDItem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : LensakiMonoBehaviour, IHpBarInterface
{
    [Header ("Status Player")]
    protected int currentHurryStat;
    public int HurryStat { get { return currentHurryStat; } }

    protected int maxHurryStat;
    public int MaxHurryStat { get { return maxHurryStat; } }

    protected int money;
    public int Money { get { return money; } }

    [SerializeField] protected IDDialogue idDialogueGoalNext;
    public IDDialogue IDDialogueGoalNext { get { return idDialogueGoalNext; } }

    [SerializeField] protected IDItem idItemHold;
    public IDItem IdItemHold { get { return idItemHold; } }

    protected Collider2D canSowSeed;
    public Collider2D CanSow { get { return canSowSeed; } }

    protected Collider2D standInFarm;
    public Collider2D StandInFarm { get { return standInFarm; } }

    protected Collision2D canInteract;
    public Collision2D CanInteract { get { return canInteract; } }

    protected Collision2D canTalk;
    public Collision2D CanTalk { get { return canTalk; } }

    protected Collision2D canAction;
    public Collision2D CanAction { get { return canAction; } }

    protected bool isStandLadder;
    public bool IsStandLadder { get { return isStandLadder; } }

    protected override void Awake()
    {
        base.Awake();
        CreateAttributePlayer();
    }

    protected override void Start()
    {
        base.Start();
       
    }

    public void ResetHP()
    {
        currentHurryStat = maxHurryStat;
        HPPlayerController.Instance.UpdateHP(HurryStat, MaxHurryStat);
    }

    void CreateAttributePlayer()
    {
        currentHurryStat = 50;
        maxHurryStat = 50;
        money = 0;
    }

    public void SetStatusPlayer(int CurrentHurryStat, int maxHurryStat, int money)
    {
        
        this.currentHurryStat = CurrentHurryStat;
        this.maxHurryStat = maxHurryStat;
        this.money = money;
    }


    public void ChangeItem(IDItem idItem,GameObject holding)
    {
        if (idItem == IDItem.NoItem)
        {
            this.idItemHold = idItem;
            holding.GetComponent<HighLightChosenHold>().HighLightUsing(false);
            return;
        }
        if (idItem == this.idItemHold)
        {
            this.idItemHold = IDItem.NoItem;
            holding.GetComponent<HighLightChosenHold>().HighLightUsing(false);
            return;
        }
        this.idItemHold = idItem;
        AudioManager.Instance.PlaySFX(AudioClipName.toolSwap);
        holding.GetComponent<HighLightChosenHold>().HighLightUsing(true);
    }
    public void SetIdItemHold(IDItem idItem)
    {
        this.idItemHold = idItem;
    }


    public void SetCanSow(Collider2D col)
    {
        ResetProperties();
        canSowSeed = col;
    }

    public void SetStandInFarm(Collider2D col)
    {
        standInFarm = col;
    }    

    public void SetCanTalk(Collision2D collision)
    {
        ResetProperties();
        canTalk = collision;
    }
    public void SetCanInteract(Collision2D collision)
    {
        ResetProperties();
        canInteract = collision;
    }

    public void SetCanAction(Collision2D collision)
    {
        ResetProperties();
        canAction = collision;
    }

    public void ChangeIsStandLadder(bool stand)
    {
        isStandLadder = stand;
    }

    public void ResetProperties()
    {
        canTalk = null;
        canInteract = null;
        canSowSeed = null;
        canAction = null;
    }    

    public void UpdateIDDialogueGoalNext(IDDialogue idDialogue)
    {
        idDialogueGoalNext = idDialogue;
    }    

    public void MinusHurryStat(int hurry)
    {
        currentHurryStat -= hurry;
        HPPlayerController.Instance.UpdateHP(HurryStat, MaxHurryStat);
    }
    public void PlusHurryStat(int foodStat)
    {
        currentHurryStat += foodStat;
        HPPlayerController.Instance.UpdateHP(HurryStat, MaxHurryStat);
    }

    public void UpdateMoney(int money)
    {
        this.money += money;
        CoinPlayerController.Instance.UpdateCoin(this.money);
    }

    public virtual void Dead()
    {
        Debug.Log("Dead");
    }

    public int HP()
    {
        return currentHurryStat;
    }


}
