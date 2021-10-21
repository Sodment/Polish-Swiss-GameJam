using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PathGeneratorCreateNewPath : MonoBehaviour
{
    private Grid grid;
    [SerializeField] Tilemap tilemap;
    public List<Tile> path_pieces;
    int max_up = -6, max_down = 6, max_right = 12;
    Vector3Int pos = new Vector3Int(-11, 0, 0);

    List<Vector3Int> path = new List<Vector3Int>();
    enum Direction
    {
        horizontal,
        vertical,
        turn_down,
        turn_up,
        turn_up_right,
        turn_down_right,
    }
    void Start()
    {

        grid = gameObject.GetComponent<Grid>();
        int r = 0, k;
        while (pos.x < max_right)
        {
            r = Random.Range(1, 4);
            if (pos.x + r < max_right)
            {

                for (int i = 0; i < r; i++)
                {
                    tilemap.SetTile(pos, path_pieces[0]);
                    path.Add(pos);
                    pos.x += 1;
                }
                pos.x += r - 1;
            }
            else
            {
                break;
            }
            k = pos.y;

            if (pos.x < max_right - 1)
            {
                int signed = 0;
                while (!(k + pos.y > max_up && k + pos.y < max_down - 1))
                {
                    signed = Random.Range(0, 1);
                    k = Random.Range(1, max_down);
                    if (signed == 1)
                    {
                        k = -k;
                    }
                }


                if (k >= 0)
                {
                    tilemap.SetTile(pos, path_pieces[2]);
                    pos.y += 1;
                    for (int i = 1; i < k; i++)
                    {
                        tilemap.SetTile(pos, path_pieces[1]);
                        path.Add(pos);
                        pos.y += 1;
                    }
                    tilemap.SetTile(pos, path_pieces[5]);

                }
                else
                {
                    tilemap.SetTile(pos, path_pieces[3]);
                    pos.y -= 1;
                    for (int i = 1; i < k; i++)
                    {
                        //Debug.Log("dupa");
                        tilemap.SetTile(pos, path_pieces[1]);
                        path.Add(pos);
                        pos.y -= 1;
                    }
                    tilemap.SetTile(pos, path_pieces[4]);
                }
                pos.x += 1;

            }
        }
    }
}