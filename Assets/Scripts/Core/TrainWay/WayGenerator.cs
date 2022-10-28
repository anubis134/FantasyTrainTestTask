using Dreamteck.Splines;
using System;
using System.Collections.Generic;
using UnityEngine;

public class WayGenerator : MonoBehaviour
{
    [Header("Way Generator Settings")]
    [Space]
    [SerializeField]
    private float _radiusAtCenter;
    [SerializeField]
    private int _pointsCount;
    [SerializeField]
    private int _wayUnitsOffset;
    [SerializeField]
    private float _startRotationOfWayUnit = -90F;
    [SerializeField]
    private WayUnit wayUnitPrefab;
    private List<WayUnit> _wayUnits { get; set; } = new List<WayUnit>();
    internal static Action<List<WayUnit>> OnWayUnitCreated;


    private void Start()
    {
        CreateWayUnit();
    }

    internal void CreateWayUnit()
    {
        WayUnit wayUnit = Instantiate(wayUnitPrefab);
        wayUnit.GenerateWayUnit(_radiusAtCenter, _pointsCount, wayUnit.transform);
        wayUnit.transform.rotation = Quaternion.Euler(0F, _startRotationOfWayUnit, 0F);
        if (_wayUnits.Count > 0)
        {
            wayUnit.transform.position = _wayUnits[_wayUnits.Count - 1].transform.position - new Vector3(0F, _wayUnitsOffset, 0F);
        }
        _wayUnits.Add(wayUnit);
        OnWayUnitCreated?.Invoke(_wayUnits);
    }


}
