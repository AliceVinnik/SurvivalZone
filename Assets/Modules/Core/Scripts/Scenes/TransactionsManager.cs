/*AliceVinnik*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransactionsManager : Singleton<TransactionsManager>
{
    [Header("Transactions")]
    public GameObject canvasTransaction;
    [Space()]
    public AnimationClip animationHide;
    public AnimationClip animationShow;

    [Header("Scenarios")]
    public bool showAtStartScene = true;

    #region Standart system methods

    protected override void Awake()
    {
        base.Awake();

        if (showAtStartScene)
            TransactionSceneOn();
    }

    #endregion

    #region Work with animations

    public void TransactionSceneOn()
    {
        SetCanvas(animationShow);
    }

    public void TransactionSceneOff()
    {
        SetCanvas(animationHide);
    }

    private void SetCanvas(AnimationClip animation)
    {
        var canvas = Instantiate(canvasTransaction);
        canvas.transform.Find("Tint").GetComponent<Animation>().clip = animation;
        canvas.transform.Find("Tint").GetComponent<Animation>().Play(animation.name);
    }

    #endregion
}