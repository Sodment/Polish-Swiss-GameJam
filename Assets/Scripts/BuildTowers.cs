using System.Collections.Generic;
using UnityEngine;

public class BuildTowers : MonoBehaviour
{
    public List<Vector3Int> takenTiles;
    private SelectedTile selectedTile;



    public void BuildTower(GameObject tower)
    {
        Vector3Int selected = selectedTile.GetSelectedTile();
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
