using UnityEngine;
using UnityEngine.Tilemaps;

public class SelectedTile : MonoBehaviour
{
    private Grid grid;
    [SerializeField] private Tilemap highlightTilemap = null;
    [SerializeField] private Tile highlightTile = null;
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
            highlightTilemap.SetTile(previousMousePos, null);
            highlightTilemap.SetTile(mousePos, highlightTile);
            previousMousePos = mousePos;
        }

        if (Input.GetMouseButtonDown(0))
        {
            SelectedPosition = mousePos;
            Debug.Log("Selected Pos:" + SelectedPosition.ToString());
        }
    }

    Vector3Int GetMousePosition()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return grid.WorldToCell(mouseWorldPos);
    }

}
