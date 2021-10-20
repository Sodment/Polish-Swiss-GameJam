using UnityEngine;

public class SelectedTile : MonoBehaviour
{
    private Grid grid;
    private Vector3Int SelectedPosition;
    private bool isSelected = false;
    // Start is called before the first frame update
    void Start()
    {
        grid = gameObject.GetComponent<Grid>();
    }

    private void Update()
    {
        Vector3Int mousePosistion = GetMousePosition();
        if (Input.GetMouseButtonDown(0))
        {
            isSelected = !isSelected;
            if(isSelected)
            {
                SelectedPosition = mousePosistion;
                Debug.Log("Selected Pos:" + SelectedPosition.ToString() + isSelected.ToString());
            }
        }
    }

    Vector3Int GetMousePosition()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0.25f;
        return grid.WorldToCell(mouseWorldPos);
    }

    public Vector3Int GetSelectedTile()
    {
        return SelectedPosition;
    }

}
