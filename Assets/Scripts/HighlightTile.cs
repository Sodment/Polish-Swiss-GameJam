using UnityEngine;
using UnityEngine.Tilemaps;

public class HighlightTile : MonoBehaviour
{
    public bool ShowHighligther;

    [SerializeField] private Tilemap highlightTilemap = null;
    [SerializeField] private Tile highlightTile = null;

    private Grid grid;
    private Vector3Int previousMousePos = new Vector3Int();

    private void Start()
    {
        grid = gameObject.GetComponent<Grid>();
    }

    private void Update()
    {
        Vector3Int mousePos = GetMousePosition();
        if (!mousePos.Equals(previousMousePos) && !ShowHighligther)
        {
            highlightTilemap.SetTile(previousMousePos, null);
            highlightTilemap.SetTile(mousePos, highlightTile);
            previousMousePos = mousePos;
        }

        if (Input.GetMouseButtonDown(0))
            ShowHighligther = !ShowHighligther;
        else if (Input.GetMouseButtonUp(1) || Input.GetKeyDown(KeyCode.Escape))
            ShowHighligther = false;
    }

    private Vector3Int GetMousePosition()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;
        return grid.WorldToCell(mouseWorldPos);
    }
}