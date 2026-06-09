/*AliceVinnik*/

using UnityEngine;
using System.Linq;

public static class LevelsBootstrapper
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        var settings = Resources.Load<LevelsBootstrapSettings>("LevelsBootstrapSettings");
        if (settings == null || settings.prefabs == null)
        {
            Debug.LogError("[Core: Bootstrapper] Bootstrap settings not found.");
            return;
        }

        foreach (var prefab in settings.prefabs)
        {
            var obj = Object.Instantiate(prefab);
        }
    }
}