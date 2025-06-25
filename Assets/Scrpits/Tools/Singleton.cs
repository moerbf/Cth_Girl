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
                    // �����в�������ʵ��
                    _instance = FindObjectOfType<T>();

                    // ��ʵ��ʱ�Զ�����
                    if (_instance == null)
                    {
                        GameObject obj = new GameObject();
                        obj.name = $"[Singleton] {typeof(T)}";
                        _instance = obj.AddComponent<T>();
                        DontDestroyOnLoad(obj); // �糡������
                    }
                }
                return _instance;
            }
        }
    }

    protected virtual void Awake()
    {
        // ��ֹ�ظ�ʵ��
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this as T;
        DontDestroyOnLoad(gameObject); // ȷ���Ѵ��ڶ���ĳ־û�
    }

    protected virtual void OnApplicationQuit()
    {
        _applicationIsQuitting = true;
    }
}