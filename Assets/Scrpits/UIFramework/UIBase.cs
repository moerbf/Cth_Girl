using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIBase : MonoBehaviour
{
    public enum UILayer
    {
        Top,
        Middle,
        Bottom
    }

    public UILayer uiLayer;

    public virtual void Init()
    {
    }

    public virtual void Show()
    {
    }

    public virtual void Hide()
    {
    }

    public virtual void Refresh()
    {
    }

    public virtual void Destroy()
    { 
    }
}
