using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
public class StoreManager : MonoBehaviour
{
    public Transform ActivePlayer;
    public Transform Canvas;
    public static StoreManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else DestroyImmediate(gameObject);
    }

    private void Update()
    {
        if(InputBridge.Instance.AButtonDown || InputBridge.Instance.XButtonDown)
        {
            if (Canvas.gameObject.activeInHierarchy)
            {
                Canvas.gameObject.SetActive(false);
            }else
            {
                Canvas.gameObject.SetActive(true);
                Canvas.transform.position = ActivePlayer.transform.position + ActivePlayer.transform.forward * 1f;
            }
        }
    }
}
