using System.Collections.Generic;
using UnityEngine;

public class ActiveOnGameState : MonoBehaviour
{
    public bool isAlwaysActive = false;
    public List<GameStateData> activeAt;

    void Start()
    {
        if (GameStateManager.Instance)
            GameStateManager.Instance.onStateChange += OnChangeState;

        RefreshState();
    }

    void OnDestroy()
    {
        if (GameStateManager.Instance)
            GameStateManager.Instance.onStateChange -= OnChangeState;
    }

    public void OnChangeState(GameStateData state)
    {
        RefreshState();
    }

    public void RefreshState()
    {
        if (GameStateManager.Instance)
        {
            var state = GameStateManager.Instance.current;
            var isActive = isAlwaysActive ? true : activeAt.Contains(state);

            gameObject.SetActive(isActive);
        }
    }
}
