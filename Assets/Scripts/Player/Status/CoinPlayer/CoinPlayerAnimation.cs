using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinPlayerAnimation : LensakiMonoBehaviour
{

    [SerializeField] protected TMP_Text textCoin;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadTextCoin();

    }

    #region LoadComponents
   
    protected virtual void LoadTextCoin()
    {
        if (textCoin != null) return;

        textCoin = transform.GetChild(1).GetComponent<TMP_Text>();
        Debug.Log(transform.name + ": LoadTextCoin", gameObject);
    }
    #endregion


    public virtual void UpdateCoinPlayer(int coin)
    {
        textCoin.text = coin.ToString();
    }

}
