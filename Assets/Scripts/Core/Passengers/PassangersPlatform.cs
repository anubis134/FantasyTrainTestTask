using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassangersPlatform : MonoBehaviour
{
    [Header("Passengers platform settings")]
    [SerializeField]
    private Passanger _passangerPrefab;
    [SerializeField]
    [Range(1, 72)]
    private int _passengerCapacity;
    [SerializeField]
    private Vector3 _rayOffset;
    [SerializeField]
    private float _rayDistance;
    [SerializeField]
    private List<Passanger> _passangers = new List<Passanger>();
    private GridManager _gridManager;

    private void Start()
    {
        _gridManager = GetComponentInChildren<GridManager>();
        AddPassangers(_passengerCapacity);
    }

    private void Update()
    {
        DetectVagonInteraction();
    }

    private void DetectVagonInteraction() 
    {
        RaycastHit hit;
        Vector3 rayPosition = transform.position + transform.TransformDirection(_rayOffset);

        if (Physics.Raycast(rayPosition, transform.TransformDirection(Vector3.right), out hit, _rayDistance, 1))
        {
            if (hit.collider.TryGetComponent(out VagonController vagonController))
            {
                foreach (var passenger in _passangers)
                {
                    passenger.SetPassengerState(Passanger.PassengerStates.Run);
                }
                Debug.DrawRay(rayPosition, transform.TransformDirection(Vector3.right) * _rayDistance, Color.yellow);
            }           
        }
        else
        {
            foreach (var passenger in _passangers)
            {
                passenger.SetPassengerState(Passanger.PassengerStates.Idle);
            }
            Debug.DrawRay(rayPosition, transform.TransformDirection(Vector3.right) * _rayDistance, Color.white);
        }
    }

    internal void AddPassangers(int passengersCount)
    {
        int spawnedPassengersCount = 0;
        while (spawnedPassengersCount < passengersCount || _passangers.Count < _passengerCapacity) 
        {
            int randomCell = Random.Range(0, _gridManager.CellsList.Count);
          
            if (!_gridManager.CellsList[randomCell].IsBusy)
            {
                spawnedPassengersCount++;
                AddPassanger(_gridManager.CellsList[randomCell]);
            }

        }
    }

    private void AddPassanger(Cell gridCell)
    {
        Passanger passanger = Instantiate(_passangerPrefab);
        passanger.transform.position = gridCell.transform.position;
        _passangers.Add(passanger);
        passanger.transform.parent = gridCell.transform;
        passanger.transform.rotation = gridCell.transform.rotation;
        gridCell.IsBusy = true;
        passanger.OnPassengerDestroy += SubscribeOnPassenger;
    }

    private void SubscribeOnPassenger(Passanger passenger) 
    {
        passenger.OnPassengerDestroy -= SubscribeOnPassenger;
        Cell cell = _gridManager.CellsList[Random.Range(_gridManager.CellsList.Count - _gridManager.Grid.Width, _gridManager.CellsList.Count)];
        AddPassanger(cell);
        _passangers.Remove(passenger);
        Destroy(passenger.gameObject);
    }
}
