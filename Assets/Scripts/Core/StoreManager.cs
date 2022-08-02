using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
public class StoreManager : MonoBehaviour
{
    public Transform ActivePlayer;
    public Transform Canvas;
    public static StoreManager Instance;
    private float yOffset;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else DestroyImmediate(gameObject);
        yOffset = Canvas.transform.position.y;
        Invoke(nameof(ResetCanvas), 2f);
    }

    private void Update()
    {
        if(InputBridge.Instance.AButtonDown || InputBridge.Instance.XButtonDown)
        {

            if (Canvas.gameObject.activeInHierarchy)
            {
               /* float dot = Vector3.Dot(ActivePlayer.transform.position, Canvas.transform.position);
                if (dot > 0.3f)
                    ResetCanvas();
                else*/
                Canvas.gameObject.SetActive(false);
            }else
            {
                ResetCanvas();
            }
        }
    }

    void ResetCanvas()
    {
        Canvas.gameObject.SetActive(true);
        Canvas.transform.position = ActivePlayer.transform.position + ActivePlayer.transform.forward * 1f + Vector3.up * yOffset;
        Canvas.transform.forward = ActivePlayer.transform.forward;
    }
}
