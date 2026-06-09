/*AliceVinnik*/

using UnityEngine;
using System.Linq;

public static class MissionsBootstrapper
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        var settings = Resources.Load<MissionsBootstrapSettings>("MissionsBootstrapSettings");
        if (settings == null || settings.prefabs == null)
        {
            Debug.LogError("[Core: Bootstrapper] Bootstrap settings not found.");
            return;
        }

        foreach (var prefab in settings.prefabs)
        {
            var obj = Object.Instantiate(prefab);

            var missionManager = obj.GetComponent<MissionsManager>();

            if (missionManager) missionManager.isAutoCompleate = settings.isAutoCompleate;
        }
    }
}