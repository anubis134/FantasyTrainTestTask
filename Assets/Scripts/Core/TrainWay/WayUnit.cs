using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayUnit : MonoBehaviour
{
    internal List<WayPoint> WayPoints { get; private set; } = new List<WayPoint>();
    [SerializeField]
    private WayPoint _wayPointPrefab;


    /// <summary>
    /// Generate a road(way unit). The size of way unit depend from radiusAtCenter and pointsCount
    /// </summary>
    /// <param name="radiusAtCenter"></param>
    /// <param name="pointsCount"></param>
    internal void GenerateWayUnit(float radiusAtCenter, int pointsCount, Transform parentTransform)
    {
        for (int i = 0; i < pointsCount; i++)
        {
            float angle = i * Mathf.PI * 2 / pointsCount;
            float x = Mathf.Cos(angle) * radiusAtCenter;
            float z = Mathf.Sin(angle) * radiusAtCenter;
            Vector3 pos = transform.position + new Vector3(x, 0, z);
            float angleDegrees = -angle * Mathf.Rad2Deg;
            Quaternion rot = Quaternion.Euler(0, angleDegrees, 0);
            WayPoint wayPoint = Instantiate(_wayPointPrefab, pos, rot);
            WayPoints.Add(wayPoint);
            wayPoint.transform.parent = parentTransform;
        }
    }

    private void OnDrawGizmos()
    {
        foreach (var point in WayPoints)
        {
            Gizmos.DrawCube(point.transform.position, Vector3.one * 0.3F);
        }
    }
}

