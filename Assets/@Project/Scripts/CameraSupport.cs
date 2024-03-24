using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSupport : MonoBehaviour
{
    private Camera mTheCamera;
    private Bounds mWorldBound; 

    public enum WorldBoundStatus
    {
        Outside = 0,
        CollideLeft = 1,
        CollideRight = 2,
        CollideTop = 4,
        CollideBottom = 8,
        Inside = 16
    };

    void Awake()
    {
        mTheCamera = gameObject.GetComponent<Camera>();
        mWorldBound = new Bounds();
        float maxY = mTheCamera.orthographicSize;
        float maxX = mTheCamera.orthographicSize * mTheCamera.aspect;
        float sizeX = 2 * maxX;
        float sizeY = 2 * maxY;
        Vector3 c = mTheCamera.transform.position;
        c.z = 0.0f;
        mWorldBound.center = c;
        mWorldBound.size = new Vector3(sizeX, sizeY, 0f);
    }

    private bool BoundsIntersectInXY(Bounds b1, Bounds b2)
    {
        return (b1.min.x < b2.max.x) && (b1.max.x > b2.min.x) &&  
               (b1.min.y < b2.max.y) && (b1.max.y > b2.min.y);
    }

    public Bounds GetWorldBound() { return mWorldBound; }

    public WorldBoundStatus CollideWorldBound(Bounds objBound, float region = 1f)
    {
        WorldBoundStatus status = WorldBoundStatus.Outside;
        Bounds b = new Bounds(transform.position, region * mWorldBound.size);

        if (BoundsIntersectInXY(b, objBound))
        {
            if (objBound.max.x > b.max.x)
                status |= WorldBoundStatus.CollideRight;
            if (objBound.min.x < b.min.x)
                status |= WorldBoundStatus.CollideLeft;
            if (objBound.max.y > b.max.y)
                status |= WorldBoundStatus.CollideTop;
            if (objBound.min.y < b.min.y)
                status |= WorldBoundStatus.CollideBottom;
            if (status == WorldBoundStatus.Outside)
                status = WorldBoundStatus.Inside;  
        }
        return status;
    }
}