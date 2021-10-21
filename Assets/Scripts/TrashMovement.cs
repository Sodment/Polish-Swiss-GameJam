using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private List<Vector2> path;
    [SerializeField] private float swapingPointDistance = 0.2f;
    [SerializeField] private float threshold = 0.1f;
    [SerializeField] private float deathSpeed = 3f;
    private bool isMoving = false;
    private int nextPointIndex = 0;
    private void Start()
    {
		getPath();
        beginMovement();
    }
    private void Update()
    {
        if(isMoving)
        {
            move();
        }
    }
    private void beginMovement()
    {
        nextPointIndex = 0;
        transform.position = path[nextPointIndex];
        isMoving = true;
        nextPointIndex++;
    }
    private void move()
    {
        Vector2 movingDirection = new Vector2(path[nextPointIndex].x - transform.position.x, path[nextPointIndex].y - transform.position.y).normalized;
        Vector2 newPosition = movingDirection * moveSpeed * Time.deltaTime;
        transform.position += new Vector3(newPosition.x, newPosition.y, 0f);
        if(Vector2.Distance(transform.position, path[nextPointIndex]) < swapingPointDistance)
        {
            if(nextPointIndex<path.Count-1)
            {
                nextPointIndex++;
            }
            else
            {
                isMoving = false;
                Debug.Log("Movement finished");
            }
        }
    }
    public void stopMovement()
    {
        isMoving = false;
    }
	private void getPath()
	{
		PathGenerator pathGenerator = FindObjectOfType<PathGenerator>();
		path = new List<Vector2>();
		foreach(Vector3Int vec in pathGenerator.Path)
		{
			path.Add(new Vector2(vec.x + 0.5f, vec.y + 0.5f));
		}
	}
    public void lastMovement(Transform destination)
    {
        if(isMoving)
        {
            Debug.LogWarning("trash is still alive");
            stopMovement();
        }
        StartCoroutine(lastMove(destination));
    }
    private IEnumerator lastMove(Transform destination)
    {
        while(Vector2.Distance(destination.position, transform.position) > threshold)
        {
            Vector3 dir = new Vector3(destination.position.x - transform.position.x, destination.position.y - transform.position.y, 0f);
            transform.position += dir * deathSpeed * Time.deltaTime;
            transform.localScale = new Vector3(transform.localScale.x * 0.97f, transform.localScale.y * 0.97f, transform.localScale.z * 0.97f) ;
            yield return null;
        }
        gameObject.SetActive(false);
    }
}
