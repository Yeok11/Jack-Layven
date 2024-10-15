using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class obj : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    protected Image img;
    public bool isUse = false;
    public virtual void ClickEvent()
    {
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        if (img == null) img = GetComponent<Image>();

        img.color = new Color(img.color.r, img.color.g, img.color.b, 0.15f);
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        img.color = new Color(img.color.r, img.color.g, img.color.b, 0);
    }
}
