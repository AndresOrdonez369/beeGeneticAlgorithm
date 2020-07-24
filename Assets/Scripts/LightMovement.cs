using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMovement : MonoBehaviour
{
    [SerializeField]
    private List<Vector2> path;

    private Vector2 nextWayPoint;
    public Vector2 startPosition;

    [SerializeField]
    public float speed, range;
    public bool isMoving;

    private int step;

    private void Awake()
    {
        path = new List<Vector2>();
    }

    public void StartMoving()
    {

        transform.position = startPosition;
        step = -1;
        SetNextWaypoint();
        isMoving = true;
    }

    private void FixedUpdate()
    {
        if (isMoving)
            MoveTowardsNextWaypoint();
    }


    private void MoveTowardsNextWaypoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, nextWayPoint, Time.fixedDeltaTime * speed);
        
        if ((Vector2)transform.position == nextWayPoint) 
        {
            SetNextWaypoint();
        }
    }
    private void SetNextWaypoint()
    {
        step++;
        if (step < path.Count)
            nextWayPoint = path[step];
        else
            nextWayPoint = CreateWayPoint(transform.position, range);
    }
    private Vector2 CreateWayPoint(Vector2 origin, float range)
    {
        Vector2 newWaypoint = Random.insideUnitCircle * range + origin;
        path.Add(newWaypoint);  
        return newWaypoint;
    }
    public  List<Vector2> GetPath()
    {
        return path;
    }
    public void OverridePath(List<Vector2> newPath)
    {
        path = new List<Vector2>(newPath); //copy values we received
    }
   
  
}
