using UnityEngine;

public class TileVisual : MonoBehaviour
{
    private Tile tile;

    public GameObject body;
    public GameObject boughtIndicator;

    void Awake()
    {
        tile = GetComponent<Tile>();
    }

    public void Refresh()
    {
        switch (tile.state)
        {
            case TileState.Active:
                body.SetActive(true);
                boughtIndicator.SetActive(false);
                break;
            case TileState.Disabled:
                body.SetActive(false);
                boughtIndicator.SetActive(false);
                break;
            case TileState.Bought:
                body.SetActive(false);
                boughtIndicator.SetActive(true);
                break;
        }
    }
}