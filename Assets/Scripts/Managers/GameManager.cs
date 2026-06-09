using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : Static<GameManager>
{
    protected override void Awake()
    {
        base.Awake();
    }

    public void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        CanvasLaunchManager.Instance.Prepare();

        StartCoroutine(Prepare());
    }

    public IEnumerator Prepare()
    {
        for (int i = 0; i < 5; i++)
            yield return null;

        GameObjectsManager.Instance.Prepare();
        EnemiesManager.Instance.Prepare();
    }

    public void GameOver()
    {
        GameStateManager.Instance.Set("gameOver");
        CanvasGameOver.Instance.Prepare();
    }

    public void CloseGameOver()
    {
        BackToMenu();
    }

    public void BackToMenu()
    {
        ScenesManager.Instance.ChangeSceneTransaction("GameScene");
    }

    public void Pause()
    {
        GameStateManager.Instance.Pause();
    }
}
