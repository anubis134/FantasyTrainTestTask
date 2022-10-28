using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Economy : MonoBehaviour
{
    [Header("Economy Settings")]
    [SerializeField]
    private int Cost = 2;
    [SerializeField]
    private TMP_Text _cashValueText;
    private int _cash;

    /// <summary>
    /// property contain a cash value
    /// </summary>
    internal int Cash 
    {
        get => _cash;
        private set 
        {
            _cash = value >= 0 ? value : 0;
            UpdateCashValueText();
        }
    }

    /// <summary>
    /// Set the Cash value from targetCashValue
    /// </summary>
    /// <param name="targetCashValue"></param>
    internal void SetCashValue(int targetCashValue) 
    {
        Cash = targetCashValue;
    }

    /// <summary>
    /// Addable cash depend from vagonLevel. It's calculates as vagonLevel * Cost
    /// </summary>
    /// <param name="vagonLevel"></param>
    internal void AddCash(int vagonLevel) 
    {
        Cash = Cash + (vagonLevel * Cost);
    }

    private void UpdateCashValueText() 
    {
        _cashValueText.text = $"{Cash}";
    }

}
