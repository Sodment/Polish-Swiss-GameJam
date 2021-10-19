using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private List<Vector2> path;
    [SerializeField] private float swapingPointDistance = 0.2f;
    private bool isMoving = false;
    private int nextPointIndex = 0;
    private void Start()
    {
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
}
