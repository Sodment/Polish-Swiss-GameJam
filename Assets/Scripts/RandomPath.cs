using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPath : MonoBehaviour
{
    public List<Vector3Int> path;

    private int[,] pathMatrix = new int[24,14];

    // Start is called before the first frame update
    void Start()
    {
        
    }


    void FillMatrix()
    {
        for(int i=0; i < 24; i++)
        {
            for (int j = 0; j < 14; j++)
            {
                pathMatrix[i,j] = 0;
            }
        }
    }

    void FindRandomStartingPoint()
    {
        int x = Mathf.FloorToInt(Random.Range(-12.0f, 12.0f));
        int y = Mathf.FloorToInt(Random.Range(-7.0f, 7.0f));
    }
}
