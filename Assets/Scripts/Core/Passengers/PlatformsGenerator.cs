using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsGenerator : MonoBehaviour
{
    [Header("Platform Generator Settings")]
    [SerializeField]
    private PassangersPlatform _passangersPlatformPrefab;
    [SerializeField]
    private float _platformsOffset;

    private void Awake()
    {

        WayGenerator.OnWayUnitCreated += GeneratePlatformsForNewLevel;
    }

    private void GeneratePlatformsForNewLevel(List<WayUnit> wayUnits) 
    {
        Vector3 targetPosition = wayUnits[wayUnits.Count - 1].transform.position;

        //generate first passengerPlatform on left side of screen
        PassangersPlatform leftPassangersPlatform = Instantiate(_passangersPlatformPrefab);
        leftPassangersPlatform.transform.position = targetPosition - new Vector3(_platformsOffset, 0F, 0F);
        //generate second passengerPlatform on left side of screen
        PassangersPlatform rightPassangersPlatform = Instantiate(_passangersPlatformPrefab);
        rightPassangersPlatform.transform.position = targetPosition + new Vector3(_platformsOffset, 0F, 0F);
        rightPassangersPlatform.transform.rotation = Quaternion.Euler(0F, 180F, 0F);
    }
}
