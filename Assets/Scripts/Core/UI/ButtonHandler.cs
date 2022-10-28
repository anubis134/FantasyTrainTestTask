using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class ButtonHandler : MonoBehaviour, IPointerClickHandler
{
    internal static Action<ButtonHandler> OnButtonClick;

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        OnButtonClick?.Invoke(this);
    }
}
