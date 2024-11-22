using Assets.Scripts.Item.IDItem;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : Singleton<PlayerController>
{
    [SerializeField] protected Rigidbody2D rb2d;

    [SerializeField] protected PlayerStatus status;

    [SerializeField] protected PlayerAnimation anim;

    [SerializeField] protected PlayerQuest quest;

    [SerializeField] protected DamgeSender damgeSender;

    [SerializeField] Vector2 velocityWalk = new Vector2(0f, 0f);

    [SerializeField] float speed = 2f;

    private List<Collider2D> collidersInRange = new List<Collider2D>();

    [SerializeField] protected PlayableDirector playableDirector;

    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();

        LoadComponent(ref anim);
        LoadComponent(ref status);
        LoadComponent(ref quest);
        LoadComponent(ref damgeSender);
        LoadComponent(ref rb2d);
    }
    #endregion

    protected override void Start()
    {
        base.Start();
        this.LoadingMainGame();
    }
    protected void LoadingMainGame()
    {
        if (!SaveManager.Instance.LoadSaveData())
        {
            SpawnerManager.Instance.GetSpawner<ObjectDropItemSpawner>().DropNewGame();
            anim.SetLastVector(new Vector2(0, 1));
            playableDirector.Play();
        }
        HPPlayerController.Instance.UpdateHP(status.HurryStat, status.MaxHurryStat);
        CoinPlayerController.Instance.UpdateCoin(GetMoney());
        quest.InitializeListQuest();
    }

    private void FixedUpdate()
    {
        Walk();
        ChangeSpeed();
        Action();
    }

    #region Player Movement
    void Walk()
    {
        //Da fix di cheo di chuyen nhanh hon
        this.velocityWalk = InputManager.Instance.InputVector;
        velocityWalk.Normalize();

        anim.ChangeAnimationPlayer(velocityWalk, speed);

        this.rb2d.MovePosition(this.rb2d.position + this.velocityWalk * speed * Time.fixedDeltaTime);
    }
    void ChangeSpeed()
    {
        if (InputManager.Instance.SpeedUp)
        {
            speed = 5f;
        }
        else
        {
            speed = 2f;
        }
    }
    #endregion

    

    protected void Action()
    {
        if(status.StandInFarm != null)
        {
            if (InputManager.Instance.Action)
            {
                if (status.StandInFarm.GetComponent<PlantGrownController>().Harvest()) return;
            }
        }    


        if (status.IdItemHold == IDItem.NoItem) return;

        switch(IDItemParser.GetTagNameByID(status.IdItemHold))
        {
            case TagName.Tool:
                ActionWithTool();
                break;
            case TagName.Seed:
                SowSeed();
                break;
            case TagName.Fruit:
                EatFruit();
                break;
        }

    }
    void ActionWithTool()
    {
        anim.Action(status.IdItemHold, InputManager.Instance.Action);
    }

    void SowSeed()
    {
        if (status.CanSow == null) return;
        if (!InputManager.Instance.Action) return;
        if (!status.CanSow.GetComponent<ICanSowSeed>().CanSowSeed()) return;
        Item item = InventoryController.Instance.GetItemInInventoryWithIdItem(status.IdItemHold).item;
        if (status.CanSow.GetComponent<ICanSowSeed>().SowSeed(item.SeedPlant))
        {
            
            if(InventoryController.Instance.RemoveItem(item, 1))
            {
                status.MinusHurryStat(1);
                AudioManager.Instance.PlaySFX(AudioClipName.seed);     
            }
            if(InventoryController.Instance.GetItemInInventoryWithIdItem(item.GetId).IsEmpty)
            {
                UIManagerSceneMainGame.Instance.ClearItemSlotHold(item.GetId);
                status.SetIdItemHold(IDItem.NoItem);
            }
        }
    }
    public void EatFruit()
    {
        if(!InputManager.Instance.Action) return;
        if (status.IdItemHold == IDItem.NoItem) return;
        Item item = InventoryController.Instance.GetItemInInventoryWithIdItem(status.IdItemHold).item;
       

        if (InventoryController.Instance.RemoveItem(item, 1))
        {
            PlusHP(item.FoodStat);
        }
        if (InventoryController.Instance.GetItemInInventoryWithIdItem(item.GetId).IsEmpty)
        {
            UIManagerSceneMainGame.Instance.ClearItemSlotHold(item.GetId);
            status.SetIdItemHold(IDItem.NoItem);

        }
    }
    
    public void PlusHP(int amount)
    {
        status.PlusHurryStat(amount);
    }    

    public virtual void TalkNormal()
    {
        if (status.CanTalk == null) return;

        status.CanTalk.gameObject.GetComponent<ITalk>().TalkNormal();
        TalkDialogController.Instance.DisableDialog();
    }

    public virtual void TalkQuest()
    {
        if (status.CanTalk == null) return;

        status.CanTalk.gameObject.GetComponent<ITalk>().TalkQuest();
        TalkDialogController.Instance.DisableDialog();
    }


    public virtual void Interact()
    {
        if (status.CanInteract == null) return;

        status.CanInteract.gameObject.GetComponent<IInteractable>().Interact();
        InteractDialogController.Instance.DisableDialog();
    }

    public Collision2D GetCanInteract()
    {
        return status.CanInteract;
    }

    public void AcceptQuest()
    {
        quest.AcceptQuest();
        UIMissionController.Instance.Initialize(quest.GetCurrentQuestStatus());
        quest.CheckStepGoal();
    }

    

    public void SetInteractGoal(IDNPC iDNPC)
    {
        StepGoalStatus stepGoal = quest.GetStepGoal();
        if (stepGoal is InteractGoalStatus interactGoal)
        {
            if (iDNPC == interactGoal.interactGoal.idNPCInteractGoal) interactGoal.Interact();
        }
        quest.CheckCompletedStepQuest();
    }
    public void PlayerSetItemUse(IDKeyNumber iDKey)
    {
        List<GameObject> slotHold = UIManagerSceneMainGame.Instance.SlotsHoldItemUI;

        foreach (GameObject holding in slotHold)
        {
            if (holding.GetComponent<SlotHold>().KeyNumber == iDKey)
            {
                status.ChangeItem(holding.GetComponent<ItemSlot>().IDItemSlot, holding);
                continue;
            }
            holding.GetComponent<HighLightChosenHold>().HighLightUsing(false);
        }
    }

    public void PlayerSelectedSlot(string chosenSlot)
    {
        List<GameObject> slots = UIManagerSceneMainGame.Instance.SlotItem;

        foreach (GameObject slot in slots)
        {
            if (slot.GetComponent<HighLightChosen>().name == chosenSlot)
            {
                slot.GetComponent<HighLightChosen>().HighLightUsing(true);
                continue;
            }
            slot.GetComponent<HighLightChosen>().HighLightUsing(false);
        }
    }

    public void PlayerDeselectedSlot()
    {
        List<GameObject> slots = UIManagerSceneMainGame.Instance.SlotItem;

        foreach (GameObject slot in slots)
        {
            slot.GetComponent<HighLightChosen>().HighLightUsing(false);
        }
    }


    


    #region Enter2d
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            AddNPCCanTalk(collision);
            AddObjectInteractable(collision);
            AddObjectActionable(collision);
        }
    }
    protected void AddNPCCanTalk(Collision2D collision)
    {
        if (collision.transform.GetComponent<ITalk>() != null)
        {
            status.SetCanTalk(collision);
            TalkDialogController.Instance.EnableDialog();
        }
    }
    protected void AddObjectInteractable(Collision2D collision)
    {
        if (collision.transform.GetComponent<IInteractable>() != null)
        {
            status.SetCanInteract(collision);
            InteractDialogController.Instance.EnableDialog();
            collision.transform.GetComponent<IInteractable>().HighLight();
        }
    }
    protected virtual void AddObjectActionable(Collision2D collision)
    {
        if (collision.transform.GetComponent<IActionable>() != null)
        {
            status.SetCanAction(collision);
            status.CanAction.transform.GetComponent<IHighLight>().HighLight();
        }
    }
    #endregion

    #region Exit2d
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision != null)
        {
            ResetCollision(collision);
        }
    }

    void ResetCollision(Collision2D collision)
    {
        status.ResetProperties();
        InteractDialogController.Instance.DisableDialog();
        TalkDialogController.Instance.DisableDialog();


        if(collision.transform.GetComponent<IInteractable>() != null)
        {
            collision.transform.GetComponent<IInteractable>().UnHighLight();
        }
        if (collision.transform.GetComponent<IHighLight>() != null)
        {
            collision.transform.GetComponent<IHighLight>().UnHighLight();
        }
    }
    #endregion

    

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider != null)
        {
            CanSowSeed(collider);
            LootItem(collider);
            StandInFarm(collider);
            FadeOutEffect(collider);

        }
    }

    protected virtual void LootItem(Collider2D collider)
    {
        ItemPickable pickable = collider.GetComponent<ItemPickable>();
        if (pickable != null)
        {
            pickable.LootItem();
            quest.UpdateCurrentAmountLootItemGoal(pickable.GetItem.GetId);
            quest.CheckCompletedStepQuest();
            SpawnerManager.Instance.GetSpawner<TextLootSpawner>().Loot(pickable.GetItem,transform.position);
            SpawnerManager.Instance.GetSpawner<ObjectDropItemSpawner>().Despawn(collider.transform);
            AudioManager.Instance.PlaySFX(AudioClipName.hoe);
        }
    }

    protected virtual void FadeOutEffect(Collider2D collider)
    {
        if (collider.GetComponent<Fade>() != null)
        {
            collider.GetComponent<Fade>().mySpriteRenderer = collider.gameObject.GetComponent<SpriteRenderer>();
            collider.GetComponent<Fade>().FadeOut();
            return;
        }

        if (collider.GetComponent<FadeRoof>() != null)
        {
            collider.GetComponent<FadeRoof>().tilemap = collider.gameObject.GetComponent<Tilemap>();
            collider.GetComponent<FadeRoof>().FadeOut();
            return;
        }

       
    }    

    protected virtual void CanSowSeed(Collider2D collider)
    {
        if(collider.GetComponent<ICanSowSeed>() == null) return;

        if (!collidersInRange.Contains(collider))
        {
            collidersInRange.Add(collider);
        }
        UpdateCanSowSeed();
    }
    
    protected virtual void StandInFarm(Collider2D collider)
    {
        if (collider.GetComponent<PlantGrownController>() == null) return;
        status.SetStandInFarm(collider);
    }    

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider != null)
        {
            FadeInEffect(collider);
            if(collidersInRange.Contains(collider))
            {
                collidersInRange.Remove(collider);
                UpdateCanSowSeed();
            }
            ResetStandInFarm(collider);
        }
    }

    void FadeInEffect(Collider2D collider)
    {
        if (collider.GetComponent<Fade>() != null)
        {
            collider.GetComponent<Fade>().mySpriteRenderer = collider.gameObject.GetComponent<SpriteRenderer>();
            collider.GetComponent<Fade>().FadeIn();
            return;
        }
        if (collider.GetComponent<FadeRoof>() != null)
        {
            collider.GetComponent<FadeRoof>().tilemap = collider.gameObject.GetComponent<Tilemap>();
            collider.GetComponent<FadeRoof>().FadeIn();
            return;
        }

    }

    
    private void UpdateCanSowSeed()
    {
        if (collidersInRange.Count == 0)
        {
            status.ResetProperties();
            return;
        }

        Collider2D closestCollider = null;
        float closestDistance = float.MaxValue;

        foreach (var collider in collidersInRange)
        {
            float distance = Vector2.Distance(transform.position, collider.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestCollider = collider;
            }
        }

        if (closestCollider != null)
        {
            status.SetCanSow(closestCollider);
        }
    }
    void ResetStandInFarm(Collider2D collider)
    {
        if (collider.GetComponent<PlantGrownController>() == null) return;
        status.SetStandInFarm(null);
    }

    #region GetSetStatus
    public IDDialogue GetIDDialogueAcceptQuest()
    {
        return quest.GetIDDialogueAcceptQuest();
    }


    public IDDialogue GetIDDialogueGoalCurrent()
    {
        return quest.IDDialogueGoalCurrent();
    }

    public int GetCurrentHurryStat()
    {
        return status.HurryStat;
    }
    public int GetMaxHurryStat()
    {
        return status.MaxHurryStat;
    }

    public int GetCurrentQuest()
    {
        return quest.CurrentQuest;
    }
    public int GetMoney()
    {
        return status.Money;
    }

    public void UpdateMoney(int money)
    {
        status.UpdateMoney(money);
    }

    public void SetStatusPlayer(Vector3 posPlayer,int CurrentHurryStat, int maxHurryStat,int money,int currentQuest)
    {
        transform.position = posPlayer;
        status.SetStatusPlayer(CurrentHurryStat, maxHurryStat, money);
        quest.SetCurrentQuest(currentQuest);
    }

    public void ResetHPWhenSleep()
    {
        status.ResetHP();
    }
    #endregion



    #region EventAnimation

    protected void EventAnimationChop()
    {
        if (status.IdItemHold != IDItem.Axe) return;
        if (status.CanAction == null) return;
        if (status.CanAction.gameObject.GetComponent<ObjectController>().IDItemAction != IDItem.Axe) return;
       
        status.CanAction.gameObject.GetComponent<ObjectController>().Action();
        damgeSender.Send(status.CanAction.transform);
        status.MinusHurryStat(1);
        AudioManager.Instance.PlaySFX(AudioClipName.chop);
    }

    protected void EventAnimationHoe()
    {
        if (status.IdItemHold != IDItem.Hoe) return;
        if (status.CanAction != null) 
        {
            if (status.CanAction.gameObject.GetComponent<ObjectController>().IDItemAction == IDItem.Hoe)
            {
                status.CanAction.gameObject.GetComponent<ObjectController>().Action();
                damgeSender.Send(status.CanAction.transform);
                status.MinusHurryStat(1);
                AudioManager.Instance.PlaySFX(AudioClipName.cut);
                return;
            }
        }
        else
        {
            Vector2 posHoe = CreatePositionHoe();

            Tilemap tileActive = MapManager.Instance.GetTileMapInPositionPlayer(posHoe);
            if (tileActive != null)
            {
                MapManager.Instance.HoeGround(tileActive, posHoe);
                status.MinusHurryStat(1);
            }
        }
        AudioManager.Instance.PlaySFX(AudioClipName.hoe);
    }

    protected Vector2 CreatePositionHoe()
    {
        Vector2 posHoe = new Vector2();
        if (anim.LastVector.x < 0)
        {
            posHoe.x = transform.position.x + anim.LastVector.x + 0.5f;
            posHoe.y = transform.position.y + anim.LastVector.y - 0.5f;
        }
        else if (anim.LastVector.x > 0)
        {
            posHoe.x = transform.position.x + anim.LastVector.x - 0.5f;
            posHoe.y = transform.position.y + anim.LastVector.y - 0.5f;
        }
        if (anim.LastVector.y < 0)
        {
            posHoe.x = transform.position.x + anim.LastVector.x + 0.5f;
            posHoe.y = transform.position.y + anim.LastVector.y + 0.5f;
        }
        else if (anim.LastVector.y > 0)
        {
            posHoe.x = transform.position.x + anim.LastVector.x + 0.5f;
            posHoe.y = transform.position.y + anim.LastVector.y - 0.5f;

        }
        return posHoe;
    }    


    protected void EventAnimationSpray()
    {
        //if (status.IdItemHold != IDItem.Watering) return;
        //if (status.CanAction == null) return;


        //WaterSprayController.Instance.Spray(anim.LastVector);
        //status.MinusHurryStat(1);
        //HPPlayerController.Instance.UpdateHP(status.HurryStat, status.MaxHurryStat);
        ////WaterSprayController.Instance.Action.Spray(PlayerController.Instance.Movement.LastVector);
        //Vector3Int tilePos = MapManager.Instance.GetVector3IntTileInPositionPlayer(transform.position);

        //Tilemap tileActive = MapManager.Instance.GetTileMapInPositionPlayer(transform.position);

        //if (tileActive == null) return;
        //if (tileActive.name == "Land")
        //{
           // MapManager.Instance.SprayGround(tilePos);
        //}


        //PlayerController.Instance.Status.MinusHurryStat(1);

    }
    #endregion


}
