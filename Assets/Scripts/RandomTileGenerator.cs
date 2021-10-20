using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RandomTileGenerator : MonoBehaviour
{
    private Grid grid;
    [SerializeField] Tilemap tilemap;
    public List<Tile> grass_pieces;
    // Start is called before the first frame update
    void Start()
    {
        grid = gameObject.GetComponent<Grid>();
        for(int i=-10; i<10;i++)
        {
            for(int j=-6; j<6; j++)
            {
                Vector3Int pos = new Vector3Int(i,j,0);
                int r = Random.Range(0, grass_pieces.Count-1);
                tilemap.SetTile(pos, grass_pieces[r]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
