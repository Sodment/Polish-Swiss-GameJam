using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildTile : MonoBehaviour
{
    private Grid grid;
    [SerializeField] private Tilemap HighlightTilemap = null;
    [SerializeField] private Tilemap TowersTilemap = null;
    [SerializeField] private Tile SelectedTile;
    [SerializeField] private Tile hoverTile = null;
    public List<Tile> TowersList;

    private Vector3Int previousMousePos = new Vector3Int();
    // Start is called before the first frame update
    void Start()
    {
        grid = gameObject.GetComponent<Grid>();
    }

    private void Update()
    {
        Vector3Int mousePos = GetMousePosition();
        if (!mousePos.Equals(previousMousePos))
        {
            TowersTilemap.SetTile(previousMousePos, null);
            HighlightTower(mousePos, hoverTile);
            previousMousePos = mousePos;
        }

        if(Input.GetMouseButton(0))
        {
            BuildTower(mousePos, SelectedTile);
        }
    }


    void HighlightTower(Vector3Int tilePos, Tile highlightTile)
    {
        HighlightTilemap.SetTile(tilePos, highlightTile);
    }

    void BuildTower(Vector3Int tilePos, Tile buildTile)
    {
        TowersTilemap.SetTile(tilePos, buildTile);
    }


    Vector3Int GetMousePosition()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return grid.WorldToCell(mouseWorldPos);
    }

}
