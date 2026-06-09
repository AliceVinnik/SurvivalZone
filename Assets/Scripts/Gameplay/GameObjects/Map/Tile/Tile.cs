using System;
using System.Collections.Generic;
using UnityEngine;

public enum TileState
{
    Disabled, Active, Bought
}

[System.Serializable]
public class Tile : MonoBehaviour
{
    [Header("Components")]
    public Transform buildingPosition;
    private TileVisual tileVisual;

    [Header("Values")]
    public TileState state = TileState.Disabled;
    public List<Tile> neighbours;

    [Space]
    public Building building;

    void Awake()
    {
        tileVisual = GetComponent<TileVisual>();
    }

    void Start()
    {
        Refresh();
        FindNeighbours();
    }

    public void Place(Building building)
    {
        if (this.building == building)
        {
            building.RefreshPosition();
        }
        else if (this.building == null)
        {
            this.building = building;
            this.building.Place(this);
            building.RefreshPosition();
        }
        else if (this.building.IsCanCombine(building))
        {
            this.building.Combine(building);
            building.Remove();
        }
        else
        {
            building.RefreshPosition();
        }
    }

    public void Remove(Building building)
    {
        this.building = null;
    }

    #region State

    public void Refresh()
    {
        tileVisual.Refresh();
    }

    public void Activate(bool initial = false)
    {
        state = TileState.Active;
        if (!initial)
            Map.Instance?.ActivateTile(this);
        Refresh();
    }

    public bool IsEmpty() => building == null;

    public void SetBought(bool on)
    {
        if (state == TileState.Active) return;

        state = on ? TileState.Bought : TileState.Disabled;
        Refresh();
    }

    #endregion

    #region Neighbours

    public void FindNeighbours()
    {
        neighbours = new List<Tile>();
        Vector3[] offsets = new Vector3[] { new Vector3(1, 0, 0), new Vector3(-1, 0, 0), new Vector3(0, 0, 1), new Vector3(0, 0, -1) };

        foreach (Vector3 offset in offsets)
        {
            Vector3 checkPos = transform.position + offset;
            Collider[] hits = Physics.OverlapSphere(checkPos, 0.4f, LayerMask.GetMask("Tile"));

            foreach (Collider hit in hits)
            {
                Tile neighbour = hit.GetComponent<Tile>();
                if (neighbour != null && neighbour != this)
                {
                    neighbours.Add(neighbour);
                }
            }
        }
    }

    public List<Tile> GetDisabledNeighbours()
    {
        var result = new List<Tile>();

        foreach (var tile in neighbours)
            if (tile.state == TileState.Disabled)
                result.Add(tile);

        return result;
    }

    #endregion
}