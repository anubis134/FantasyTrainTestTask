using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SplineComputer))]
public class SplineGenerator : MonoBehaviour
{
    private SplineComputer _splineComputer;
    private SplineMesh _splineMesh;
    private void Awake()
    {
        _splineComputer = GetComponent<SplineComputer>();
        _splineMesh = GetComponent<SplineMesh>();
        WayGenerator.OnWayUnitCreated += GenerateSplineWay;
    }

    private void OnDestroy()
    {
        WayGenerator.OnWayUnitCreated -= GenerateSplineWay;
    }

    private void GenerateSplineWay(List<WayUnit> wayUnits)
    {
        List<SplinePoint> splinePoints = new List<SplinePoint>();
        foreach (var wayUnit in wayUnits)
        {
            foreach (var wayPoint in wayUnit.WayPoints)
            {
              
                SplinePoint splinePoint = new SplinePoint();
                splinePoint.size = 1F;
                splinePoint.position = wayPoint.transform.position;
                splinePoints.Add(splinePoint);
            }
        }
        _splineMesh.GetChannel(0).count = splinePoints.Count;
        _splineComputer.SetPoints(splinePoints.ToArray());
        _splineComputer.Close();
    }
}
