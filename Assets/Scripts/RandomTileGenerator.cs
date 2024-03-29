using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RandomTileGenerator : MonoBehaviour
{
    private Grid grid;
    [SerializeField] Tilemap tilemap;
    public List<Tile> grass_pieces;

    void Start()
    {
        grid = gameObject.GetComponent<Grid>();

        for(int i=-15; i<15;i++)
        {
            for(int j=-10; j<10; j++)
            {
                Vector3Int pos = new Vector3Int(i,j,0);
                int r = Random.Range(0, grass_pieces.Count);
                tilemap.SetTile(pos, grass_pieces[r]);
            }
        }
    }

    void Update()
    {
        
    }
}
