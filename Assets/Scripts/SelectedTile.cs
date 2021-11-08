using UnityEngine;
using UnityEngine.EventSystems;

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
        if (!EventSystem.current.IsPointerOverGameObject() && Input.GetMouseButtonUp(0))
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
        Vector3Int mousePosistion = GetMousePosition();

        if (!BuildTowers.IsOverSelectionWheel() && !BuildTowers.IsOverNextWaveButton() && !PauseGame.IsPaused)
        {
            SelectedPosition = mousePosistion;
            Debug.Log("Selected Pos:" + SelectedPosition.ToString() + isSelected.ToString());
        }

        return SelectedPosition;
    }

}
