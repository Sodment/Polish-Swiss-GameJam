using System.Collections.Generic;
using UnityEngine;

public class BuildTowers : MonoBehaviour
{
    public List<Vector3Int> takenTiles = new List<Vector3Int>();
    [SerializeField] private SelectedTile selectedTile;
    [SerializeField] private GameObject Buttons;
    public List<GameObject> towers;


    private void Update()
    {
        {
            if(Input.GetMouseButtonDown(0))
            {
                Vector3Int select = selectedTile.GetSelectedTile();
                Vector3 tileCenter = new Vector3(select.x + 0.5f, select.y + 0.5f);
                Buttons.transform.position = Camera.main.WorldToScreenPoint(tileCenter);
            }
        }
    }

    public void HideButtons()
    {
        Buttons.transform.position = Camera.main.WorldToScreenPoint(new Vector3(-8000.0f, -8000.0f, 0));
    }

    public void BuildTower(int index)
    {
        Vector3Int selected = selectedTile.GetSelectedTile();
        Debug.Log(selected.ToString());
        if(takenTiles.Contains(selected))
        {
            Debug.Log("Its TAKEN");
        }
        else
        {
            Instantiate(towers[index], new Vector3(selected.x+0.5f, selected.y+0.5f, 0), Quaternion.identity);
            takenTiles.Add(selected);
        }
    }
}
