using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    public Dictionary<string /* name */, UIBase> uiDic = new Dictionary<string, UIBase>();

    public new void Awake()
    {
        base.Awake();
    }
    public Transform uiRoot => GetUIRoot();

    public Transform GetUIRoot()
    {
        Transform uiRoot = GameObject.Find("UIRoot").transform;
        if (uiRoot == null)
        {
            uiRoot = new GameObject("UIRoot").transform;
        }
        return uiRoot;
    }

    public UIBase GetUI<T>(string uiname) where T : UIBase
    {
        if (!uiDic.TryGetValue(uiname, out UIBase ui))
        {
            UIBase prefab = Resources.Load<UIBase>("UI/" + uiname);
            if (prefab == null)
            {
                Debug.LogError("UI Prefab is null");
                return null;
            }
            GameObject gameObject = Instantiate(prefab.gameObject, uiRoot);
            gameObject.name = uiname;
            ui = gameObject.GetComponent<T>() ?? gameObject.AddComponent<T>();
            uiDic.Add(uiname, ui);
        }

        return ui;
    }

    public UIBase GetUI<T>() where T : UIBase
    {
        return GetUI<T>(typeof(T).Name);
    }

    public void HideUI(string uiname)
    {
        if (uiDic.TryGetValue(uiname, out UIBase ui))
        {
            ui.Hide();
        }
    }

    public void ShowUI<T>(string uiname) where T : UIBase
    {
        if (!uiDic.TryGetValue(uiname, out UIBase ui))
        {
            UIBase prefab = Resources.Load<UIBase>("UI/" + uiname);
            if (prefab == null)
            {
                Debug.LogError("UI Prefab is null");
                return;
            }
            GameObject gameObject = Instantiate(prefab.gameObject, uiRoot);
            gameObject.name = uiname;
            ui = gameObject.GetComponent<T>() ?? gameObject.AddComponent<T>();
            uiDic.Add(uiname, ui);
        }
        ui.Show();
    }

    public void ShowUI<T>() where T : UIBase
    {
        ShowUI<T>(typeof(T).Name);
    }


}
