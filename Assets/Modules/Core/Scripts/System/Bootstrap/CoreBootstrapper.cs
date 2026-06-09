/*AliceVinnik*/

using UnityEngine;

public static class CoreBootstrapper
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        var settings = Resources.Load<CoreBootstrapSettings>("CoreBootstrapSettings");
        if (settings == null || settings.prefabs == null)
        {
            Debug.LogError("[Core: Bootstrapper] Bootstrap settings not found.");
            return;
        }

        foreach (var prefab in settings.prefabs)
        {
            var obj = Object.Instantiate(prefab);

            var soundManager = obj.GetComponent<SoundManager>();
            var distributorManager = obj.GetComponent<DistributorManager>();

            if (distributorManager) distributorManager.type = settings.distributorType;
        }
    }
}