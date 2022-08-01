using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class AddressableDataLoader
{
    public static void InstantiatePrefab(string address, Transform point, Vector3 offset, Action<bool> Callback)
    {
        Addressables.InstantiateAsync(address).Completed += (result) =>
        {
            if (result.Status == UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded)
            {
                result.Result.gameObject.transform.position = point.TransformPoint(offset);
                result.Result.gameObject.transform.rotation = point.rotation;
                Callback(true);
            }
            else Callback(false);
        };
    }
}
