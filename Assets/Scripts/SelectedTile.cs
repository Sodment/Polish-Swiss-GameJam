using UnityEngine;
using UnityEngine.Tilemaps;

public class SelectedTile : MonoBehaviour
{
    private Grid grid;
    public Vector3Int SelectedPosition;
    // Start is called before the first frame update
    void Start()
    {
        grid = gameObject.GetComponent<Grid>();
    }

    private void Update()
    {
        Vector3Int mousePos = GetMousePosition();

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
