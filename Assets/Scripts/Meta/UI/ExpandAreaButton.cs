using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExpandAreaButton : ButtonHandler
{
    [SerializeField]
    private Seller _seller = new Seller();
    [SerializeField]
    private TMP_Text _expandAreaText;

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        TrySell();
    }

    private void TrySell()
    {
        if (Services.Singletone.Economy.Cash >= _seller.CurrentPrice)
        {
            _seller.UpdatePrice();
            UpdateText();
            int targetCashValue = Services.Singletone.Economy.Cash - _seller.CurrentPrice;
            Services.Singletone.Economy.SetCashValue(targetCashValue);
            Services.Singletone.WayGenerator.CreateWayUnit();
        }
    }

    private void UpdateText() 
    {
        _expandAreaText.text = $"{_seller.CurrentPrice}";
    }
}
