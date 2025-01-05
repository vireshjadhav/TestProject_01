using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBall_Patroling : MonoBehaviour
{
    // variable to rotate
    public float rotationAngle = 90f;

    // variables to move 
    public Vector3 pointA, pointB;
    private Vector3 targetPoint;
    public float patrolSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = pointA;
        targetPoint = pointB;
    }

    // Update is called once per frame
    void Update()
    {
        RotateSpikeBall();
        PatrolSpikeBall();
    }
    
    private void RotateSpikeBall() => transform.Rotate(Vector3.forward, rotationAngle * Time.deltaTime);

    private void PatrolSpikeBall()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, patrolSpeed * Time.deltaTime);
        if (transform.position == targetPoint)
        {
            targetPoint = (targetPoint == pointA) ? pointB : pointA;
        }
    }
}
