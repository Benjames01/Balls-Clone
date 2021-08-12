using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPreview : MonoBehaviour
{
    LineRenderer lineRenderer;
    Vector3 dragStartPoint;

    void Awake() {
       lineRenderer = GetComponent<LineRenderer>(); 
    }

    public void SetStartPoint(Vector3 worldPosition)
    {
        dragStartPoint = worldPosition;
        lineRenderer.SetPosition(0, dragStartPoint);
    }

        public void SetEndPoint(Vector3 worldPosition)
    {
        Vector3 positionOffset = worldPosition - dragStartPoint;
        Vector3 endPosition = transform.position + positionOffset;

        lineRenderer.SetPosition(1, endPosition);
    }
}
