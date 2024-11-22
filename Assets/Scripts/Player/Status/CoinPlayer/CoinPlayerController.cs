using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPlayerController : Singleton<CoinPlayerController>
{
    protected CoinPlayerAnimation anim;

    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCoinPlayerAnimation();
    }

    protected virtual void LoadCoinPlayerAnimation()
    {
        if (anim != null) return;

        anim = gameObject.GetComponent<CoinPlayerAnimation>();
        Debug.Log(transform.name + " : LoadCoinPlayerAnimation", gameObject);

    }
    #endregion

    public virtual void UpdateCoin(int coin)
    {
        anim.UpdateCoinPlayer(coin);
    }
}
