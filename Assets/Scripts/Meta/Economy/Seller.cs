using System;
using UnityEngine;

[Serializable]
public class Seller
{
    [SerializeField]
    internal int CurrentPrice;
    [SerializeField]
    internal int PriceCoefficient;

    internal void UpdatePrice() 
    {
        CurrentPrice *= PriceCoefficient;
    }
}
