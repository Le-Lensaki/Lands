using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : LensakiMonoBehaviour
{
    [SerializeField] protected IDGround ground;
    public IDGround CurrentIDGround => ground;

    [SerializeField] protected ListSpriteGroundDataSO listSpriteGroundDataSO;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadListTileDatasSO();
    }

    #region LoadComponents
    protected virtual void LoadListTileDatasSO()
    {
        if (this.listSpriteGroundDataSO != null) return;
        string resPath = "Ground/" + "ListGroundData";
        this.listSpriteGroundDataSO = Resources.Load<ListSpriteGroundDataSO>(resPath);
        Debug.LogWarning(transform.name + ": LoadListTileDatasSO " + resPath, gameObject);
    }
    #endregion

    private void Update()
    {
        this.ChangeSpriteGround();
    }
    protected virtual void ChangeSpriteGround()
    {
        switch(ground)
        {
            case IDGround.NoSeed:
                transform.GetComponent<SpriteRenderer>().sprite = listSpriteGroundDataSO.listSpriteGroundDataSO[0];
                break;
            case IDGround.NoSeedIsSprayed:
                transform.GetComponent<SpriteRenderer>().sprite = listSpriteGroundDataSO.listSpriteGroundDataSO[1];
                break;
            case IDGround.HasSeedNoSprayed:
                transform.GetComponent<SpriteRenderer>().sprite = listSpriteGroundDataSO.listSpriteGroundDataSO[2];
                break;
            case IDGround.HasSeedIsSprayed:
                transform.GetComponent<SpriteRenderer>().sprite = listSpriteGroundDataSO.listSpriteGroundDataSO[3];
                break;
        }
               
    }

    public virtual void ChangeGround(IDGround ground)
    {
        this.ground = ground;

    }
}
