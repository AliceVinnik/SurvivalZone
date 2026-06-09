/*AliceVinnik*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : Singleton<ScenesManager>
{
    public float delay = 0.85f;

    protected override void Awake()
    {
        base.Awake();
    }

    public string GetPreviousScene()
    {
        return Save.GetString("previousScene", "GameScene");
    }

    #region Change Scenes

    public void ChangeScene(string name)
    {
        Save.SetString("previousScene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(name);
    }

    public void ChangeSceneTransaction(string name)
    {
        TransactionsManager.Instance?.TransactionSceneOff();
        StartCoroutine(RunSceneWithDelay(name));
    }

    private IEnumerator RunSceneWithDelay(string name)
    {
        yield return new WaitForSeconds(delay);
        ChangeScene(name);
    }

    public void BackToPreviousScene()
    {
        ChangeScene(GetPreviousScene());
    }

    public void BackToPreviousSceneWithDelay()
    {
        ChangeSceneTransaction(GetPreviousScene());
    }

    #endregion
}