using UnityEngine;

public class InitialisationScene : MonoBehaviour
{
    private bool isActive = true;

    public string sceneToLaunch = "GameScene";
    public float timeToChangeScene = 5f;

    void Update()
    {
        TryToChangeScene();
    }

    public void TryToChangeScene()
    {
        if (!isActive) return;

        if (DistributorManager.Instance != null && DistributorManager.Instance.IsInitialised())
        {
            ChangeScene();
        }
        else
        {
            timeToChangeScene -= Time.deltaTime;
            if (timeToChangeScene <= 0f)
                ChangeScene();
        }
    }

    public void ChangeScene()
    {
        isActive = false;
        ScenesManager.Instance.ChangeSceneTransaction(sceneToLaunch);
    }
}
