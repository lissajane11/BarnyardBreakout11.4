using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform target;
    Vector3 velocity = Vector3.zero;
    [Range(0, 1)]
    public float smoothTime;

    public Vector3 positionOffset;

    [Header("Axis Limitation")]
    public Vector2 xLimit; // x axis limitation
    public Vector2 yLimit; // y axis limitation

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        // Calculate the target position with the offset
        Vector3 targetPosition = target.position + positionOffset;

        // Clamp the target position to the defined limits
        float clampedX = Mathf.Clamp(targetPosition.x, xLimit.x, xLimit.y);
        float clampedY = Mathf.Clamp(targetPosition.y, yLimit.x, yLimit.y);

        // Set the target position for the camera with clamped values and a fixed Z value
        targetPosition = new Vector3(clampedX, clampedY, -10f);  // Assuming camera's Z position is fixed at -10

        // Smoothly move the camera towards the target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}