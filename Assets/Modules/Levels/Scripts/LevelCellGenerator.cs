using System.Collections.Generic;
using UnityEngine;

public class LevelCellGenerator : MonoBehaviour
{
    public Transform holder;

    [Header("Properties")]
    public CellLevel cellPrefab;
    public List<CellLevel> cellsOnScene;

    public void Generate()
    {
        var levels = LevelsHolderManager.Instance.GetAll();
        cellsOnScene = new List<CellLevel>();

        foreach (var data in levels)
        {
            var newCell = Instantiate(cellPrefab, holder);
            cellsOnScene.Add(newCell);
        }
    }
}
