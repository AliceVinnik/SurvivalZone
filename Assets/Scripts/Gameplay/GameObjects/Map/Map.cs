using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Map : Static<Map>
{
    public List<Tile> active = new List<Tile>();
    public List<Tile> all = new List<Tile>();

    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        FindAllTiles();
        PrepareStartTiles();
    }

    #region Work with tiles

    public bool IsEmptyTile() => active.Any(tile => tile.IsEmpty());

    public Tile GetRandomEmpty()
    {
        List<Tile> emptyTiles = active.FindAll(tile => tile.IsEmpty());

        if (emptyTiles.Count == 0) return null;
        return emptyTiles[Random.Range(0, emptyTiles.Count)];
    }

    #endregion

    #region Increase Map Logic

    public List<Tile> GetDisabledNeighbours()
    {
        var tiles = new List<Tile>();

        foreach (var tile in active)
            tiles.AddRange(tile.GetDisabledNeighbours());

        tiles = tiles.Distinct().ToList();
        return tiles;
    }

    public void DeactivateBoughtTiles()
    {
        foreach (var tile in all)
            tile.SetBought(false);
    }

    public void ActivateTile(Tile tile)
    {
        active.Add(tile);
    }

    #endregion

    #region Tile Init

    public void PrepareStartTiles()
    {
        foreach (var tile in active)
            tile.Activate(true);
    }

    public void FindAllTiles() => FindAllTilesInChilds(transform);

    private void FindAllTilesInChilds(Transform obj)
    {
        foreach (Transform child in obj)
        {
            var tile = child.GetComponent<Tile>();
            if (tile == null)
                FindAllTilesInChilds(child);
            else
                all.Add(tile);
        }
    }

    #endregion
}
