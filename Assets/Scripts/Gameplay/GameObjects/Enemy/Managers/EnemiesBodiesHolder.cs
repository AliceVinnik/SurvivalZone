using System.Collections.Generic;
using UnityEngine;

public class EnemiesBodiesHolder : Static<EnemiesBodiesHolder>
{
    public List<Factory> factories = new List<Factory>();
    public Factory factoryPrefab;

    protected override void Awake()
    {
        base.Awake();
    }

    public void CreateFactories(List<EnemyData> datas)
    {
        foreach (var data in datas)
            if (data.body != null)
            {
                var factory = Instantiate(factoryPrefab, transform);
                factory.obj = data.body;
                factory.gameObject.name = $"FactoryEnemy_{data.body.name}";
                factory.Initialize(factory.transform);

                factories.Add(factory);
            }
    }

    public GameObject GetPrefab(GameObject body)
    {
        var factory = GetFactory(body);
        if (factory) return factory.Get();
        return null;
    }

    public void ReturnBody(GameObject body)
    {
        var factory = GetFactory(body);
        if (factory)
        {
            body.transform.parent = factory.transform;
            body.GetComponent<Pooled>().ReturnToPull();
        }
    }

    private Factory GetFactory(GameObject body)
    {
        foreach (var factory in factories)
            if (factory.obj == body)
                return factory;
        return null;
    }
}
