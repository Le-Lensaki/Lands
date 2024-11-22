using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : Singleton<BoatController>
{
    protected BoatAnimation anim;

    protected bool boatIsStop;

    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadComponent(ref anim);
    }
    #endregion

    public void RunBoat()
    {
        anim.PlayAnimationRunBoat();
    }
    public void StopBoat()
    {
        anim.PlayAnimationBoatIdle();
    }

    public void AnchorBoat()
    {
        anim.PlayAnimationStopBoatIdle();
    }    
}
