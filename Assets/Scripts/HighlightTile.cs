using UnityEngine;
using UnityEngine.Tilemaps;

public class HighlightTile : MonoBehaviour
{
    private Grid grid;
    [SerializeField] private Tilemap highlightTilemap = null;
    [SerializeField] private Tile highlightTile = null;
    private Vector3Int previousMousePos = new Vector3Int();
    public bool showHighligther = true;
    // Start is called before the first frame update
    void Start()
    {
        grid = gameObject.GetComponent<Grid>();
    }

    private void Update()
    {
        Vector3Int mousePos = GetMousePosition();
        if (!mousePos.Equals(previousMousePos) && !showHighligther)
        {
            highlightTilemap.SetTile(previousMousePos, null);
            highlightTilemap.SetTile(mousePos, highlightTile);
            previousMousePos = mousePos;
        }

        if (Input.GetMouseButtonDown(0))
        {
            showHighligther = !showHighligther;
        }
    }

    Vector3Int GetMousePosition()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;
        return grid.WorldToCell(mouseWorldPos);
    }
}