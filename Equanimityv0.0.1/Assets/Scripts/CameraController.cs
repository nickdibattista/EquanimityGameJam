using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Camera cam;
    public float horizontalMargin = 0.6f;
    public float verticalMargin = 0.6f;
    public float depth = -10;
    Vector3 target;
    Vector3 lastPosition;
    public float smoothTime = 0.25f;
    Vector3 currentVelocity;
    private void LateUpdate()
    {
        SetTarget();
        MoveCamera();
    }
    void SetTarget()
    {
        Vector3 movementDelta = player.position - lastPosition;
        Vector3 screenPos = cam.WorldToScreenPoint(player.position);
        Vector3 bottomLeft = cam.ViewportToScreenPoint(new Vector3(horizontalMargin,verticalMargin,0));
        Vector3 topRight = cam.ViewportToScreenPoint(new Vector3(1-horizontalMargin, 1-verticalMargin, 0));
        if (screenPos.x < bottomLeft.x || screenPos.x > topRight.x)
        {
            target.x += movementDelta.x;
        }
        if (screenPos.y < bottomLeft.y || screenPos.y > topRight.y)
        {
            target.y += movementDelta.y;
        }
        target.z = depth;
        lastPosition = player.position;
    }
    void MoveCamera()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target, ref currentVelocity, smoothTime);
    }
    

    void Start()
    {
        // player = GameObject.Find("Player").GetComponent<Transform>();
        // cam = GameObject.Find("MainCamera").GetComponent<Camera>();
    }
    

    public void SetPlayer(GameObject player)
    {
        this.player = player.transform;
    }
    
}

