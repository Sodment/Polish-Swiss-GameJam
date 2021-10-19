using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildTile : MonoBehaviour
{
    private Grid grid;
    [SerializeField] private Tilemap HighlightTilemap = null;
    [SerializeField] private Tile hoverTile = null;
    public Vector3Int SelectedPosition;
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
            HighlightTilemap.SetTile(previousMousePos, null);
            HighlightTower(mousePos, hoverTile);
            previousMousePos = mousePos;
        }

        if(Input.GetMouseButtonDown(0))
        {
            SelectedPosition = mousePos;
            Debug.Log("Selected Pos:" + SelectedPosition.ToString());
        }
    }


    void HighlightTower(Vector3Int tilePos, Tile highlightTile)
    {
        HighlightTilemap.SetTile(tilePos, highlightTile);
    }

    Vector3Int GetMousePosition()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return grid.WorldToCell(mouseWorldPos);
    }

}
