using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemiesManager : Static<EnemiesManager>
{
    public List<EnemyData> data = new List<EnemyData>();

    protected override void Awake()
    {
        base.Awake();
    }

    public void Prepare()
    {
        data = Resources.LoadAll<ScriptableObject>("Enemies").OfType<EnemyData>().ToList();
    }
}
