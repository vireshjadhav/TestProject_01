using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBall_Rotating : MonoBehaviour
{
    public float rotationAngle = 90f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateSpikeBall();
    }

    private void RotateSpikeBall() => transform.Rotate(Vector3.forward, rotationAngle * Time.deltaTime);
}
