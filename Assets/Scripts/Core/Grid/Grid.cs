using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    internal int Width { get; private set; }
    internal int Height { get; private set; }
    internal int[,] Cells;

    /// <summary>
    /// Init a grid with width and height parametres
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    internal Grid(int width, int height)
    {
        Width = width;
        Height = height;
        Cells = new int[Width, Height];
    }
}