using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    private static readonly object _lock = new object();
    private static bool _applicationIsQuitting = false;

    public static T Instance
    {
        get
        {
            if (_applicationIsQuitting)
            {
                Debug.LogWarning($"[Singleton] Instance {typeof(T)} already destroyed");
                return null;
            }

            lock (_lock)
            {
                if (_instance == null)
                {
                    // 场景中查找现有实例
                    _instance = FindObjectOfType<T>();

                    // 无实例时自动创建
                    if (_instance == null)
                    {
                        GameObject obj = new GameObject();
                        obj.name = $"[Singleton] {typeof(T)}";
                        _instance = obj.AddComponent<T>();
                        DontDestroyOnLoad(obj); // 跨场景保留
                    }
                }
                return _instance;
            }
        }
    }

    protected virtual void Awake()
    {
        // 防止重复实例
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this as T;
        DontDestroyOnLoad(gameObject); // 确保已存在对象的持久化
    }

    protected virtual void OnApplicationQuit()
    {
        _applicationIsQuitting = true;
    }
}