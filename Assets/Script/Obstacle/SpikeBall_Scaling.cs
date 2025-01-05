using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBall_Scaling : MonoBehaviour
{
    // variables for rotate
    public float rotationAngle = 90f;

    // variables for scale
    public float scaleSpeed = 1f;
    public float minScale = 0.5f;
    public float maxScale = 1.5f;
    private float currentScale;
    private float scaleFactor = 1f;

    // varibale for delay
    public float delayScale = 2f;
    private float timer = 0f;
    private bool isWaiting = false;

    // Start is called before the first frame update
    void Start()
    {
        currentScale = minScale;
        ApplyCurrentScale();
    }

    // Update is called once per frame
    void Update()
    {
        RotateSpikeBall();
        if (isWaiting)
            HandleWaiting();
        else
            ScaleSpikeBall();
    }

    private void RotateSpikeBall() => transform.Rotate(Vector3.forward, rotationAngle * Time.deltaTime);

    private void ApplyCurrentScale() => transform.localScale = new Vector3(currentScale, currentScale, 1);

    private void HandleWaiting()
    {
        timer += Time.deltaTime;
        if (timer >= delayScale)
        {
            isWaiting = false ;
            timer = 0f ;
        }

        ApplyCurrentScale();
    }

    private void ScaleSpikeBall()
    {
        currentScale += scaleFactor * scaleSpeed * Time.deltaTime;
        currentScale = Mathf.Clamp(currentScale, minScale, maxScale);
        if (currentScale >= maxScale || currentScale <= minScale)
        {
            scaleFactor = -scaleFactor;
            isWaiting = true ;
        }
    }
}
