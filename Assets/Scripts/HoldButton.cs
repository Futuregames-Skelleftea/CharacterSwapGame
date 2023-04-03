using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class HoldButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public UnityEvent onUp;
    public UnityEvent onDown;
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Button is down");

        onDown.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Button is up");

        onUp.Invoke();
    }
}
