using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PathGenerator : MonoBehaviour
{
	public Tilemap RoadTilemap;
	public Vector3Int StartingTile;
	public List<Vector3Int> Path;
	private void Start()
	{
		GeneratePath(StartingTile);
	}
	private void GeneratePath(Vector3Int startingTile)
	{
		List<Vector3Int> visisted = new List<Vector3Int>();
		Vector3Int nowVisiting = startingTile;
		
		if(RoadTilemap.GetTile(nowVisiting) != null)
		{
			int found = 1;
			Vector3Int stash;
			while(found > 0)
			{
				visisted.Add(nowVisiting);
				found = 0;
				Vector3Int nextVisiting = new Vector3Int();
				stash = new Vector3Int(nowVisiting.x + 1, nowVisiting.y, 0);
				if (!visisted.Contains(stash) && RoadTilemap.GetTile(stash)!=null)
				{
					found++;
					nextVisiting = stash;
				}
				stash = new Vector3Int(nowVisiting.x - 1, nowVisiting.y, 0);
				if (!visisted.Contains(stash) && RoadTilemap.GetTile(stash) != null)
				{
					found++;
					nextVisiting = stash;
				}
				stash = new Vector3Int(nowVisiting.x, nowVisiting.y - 1, 0);
				if (!visisted.Contains(stash) && RoadTilemap.GetTile(stash) != null)
				{
					found++;
					nextVisiting = stash;
				}
				stash = new Vector3Int(nowVisiting.x, nowVisiting.y + 1, 0);
				if (!visisted.Contains(stash) && RoadTilemap.GetTile(stash) != null)
				{
					found++;
					nextVisiting = stash;
				}
				nowVisiting = nextVisiting;
				if (found>1)
				{
					Debug.LogError("Incorrect Path!");
					break;
				}
			}
			Path = visisted;
		}
	}
}
