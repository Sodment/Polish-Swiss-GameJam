using System.Collections.Generic;
using UnityEngine;

public class BuildTowers : MonoBehaviour
{
    public List<Vector3Int> takenTiles = new List<Vector3Int>();
    [SerializeField] private SelectedTile selectedTile;

    public void BuildTower(GameObject tower)
    {
        Vector3Int selected = selectedTile.GetSelectedTile();
        Debug.Log(selected.ToString());
        if(takenTiles.Contains(selected))
        {
            Debug.Log("Its TAKEN");
        }
        else
        {
            Instantiate(tower, new Vector3(selected.x+0.5f, selected.y+0.5f, 0), Quaternion.identity);
            takenTiles.Add(selected);
        }
    }
}
