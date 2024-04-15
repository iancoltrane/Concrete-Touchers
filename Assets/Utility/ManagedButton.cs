using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ManagedButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ButtonManager.Instance.CurrentButton = _button;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (ButtonManager.Instance.CurrentButton == _button) ButtonManager.Instance.CurrentButton = null;
    }
}