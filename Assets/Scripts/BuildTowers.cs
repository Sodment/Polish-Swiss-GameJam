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
            Instantiate(tower, selected, Quaternion.identity);
            takenTiles.Add(selected);
        }
    }
}
