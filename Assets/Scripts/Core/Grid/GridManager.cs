using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GridManager : MonoBehaviour
{
    [SerializeField]
    private Cell _cellPrefab;
    internal Grid Grid;
    internal List<Cell> CellsList = new List<Cell>();
    [Header("Grid Settings")]
    [Space]
    [SerializeField]
    [Range(1, 30)]
    private int _gridWidth = 1;
    [SerializeField]
    [Range(1, 30)]
    private int _gridHeight = 1;
    [SerializeField]
    [Range(0f, 5f)]
    private float _cellOffsetWidth = 0f;
    [SerializeField]
    [Range(0f, 5f)]
    private float _cellOffsetHeight = 0f;



    private void Awake()
    {
        Grid = new Grid(_gridWidth, _gridHeight);
        CreateCells(Grid);
    }

    private void CreateCells(Grid grid)
    {
        for (int i = 0; i < Grid.Width; i++)
        {
            for (int j = 0; j < Grid.Height; j++)
            {
                Cell cell = Instantiate(_cellPrefab);
                cell.transform.parent = this.transform;
                cell.transform.localPosition = new Vector3(i * _cellOffsetHeight, 0F, j * _cellOffsetWidth);
                CellsList.Add(cell);
            }
        }
    }

   
}
