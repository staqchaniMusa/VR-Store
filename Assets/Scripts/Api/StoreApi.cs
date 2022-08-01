using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System;

public class StoreApi : MonoBehaviour
{
    //
    // Summary:
    //     The string "GET", commonly used as the verb for an HTTP GET request.
    public const string kHttpVerbGET = "GET";
    //
    // Summary:
    //     The string "HEAD", commonly used as the verb for an HTTP HEAD request.
    public const string kHttpVerbHEAD = "HEAD";
    //
    // Summary:
    //     The string "POST", commonly used as the verb for an HTTP POST request.
    public const string kHttpVerbPOST = "POST";
    //
    // Summary:
    //     The string "PUT", commonly used as the verb for an HTTP PUT request.
    public const string kHttpVerbPUT = "PUT";
    //
    // Summary:
    //     The string "CREATE", commonly used as the verb for an HTTP CREATE request.
    public const string kHttpVerbCREATE = "CREATE";
    //
    // Summary:
    //     The string "DELETE", commonly used as the verb for an HTTP DELETE request.
    public const string kHttpVerbDELETE = "DELETE";


    // Base Url
    public static readonly string BaseURL = "https://meta.biafosoft.com/";

    // this method will concate base url with suburl
    public static string GetUrl(string url) => BaseURL + url;
    
   /// <summary>
   /// This method is generic method which can be used to read, write , update and delete Server data
   /// </summary>
   /// <typeparam name="T">Response Model Class</typeparam>
   /// <param name="url">Sub Url</param>
   /// <param name="method">CRUD methods</param>
   /// <param name="callback">will return response with data in given response class</param>
   /// <returns> Generic data which user want to expect </returns>
    public static IEnumerator GetServerData<T>(string url, Action<T> callback)
    {
       
        using (UnityWebRequest web = UnityWebRequest.Get(GetUrl(url)))
        {
           
            yield return web.SendWebRequest();
            Debug.Log(web.downloadHandler.text);
            if (web.result == UnityWebRequest.Result.Success)
            {
                
                T data = JsonConvert.DeserializeObject<T>(web.downloadHandler.text);
                callback?.Invoke(data);
            }
            else
            {
                
                callback(default(T));
            }
        }
    }

    public static IEnumerator PostServerData<T>(string url, Action<T> callback)
    {

        using (UnityWebRequest web = UnityWebRequest.Post(GetUrl(url),kHttpVerbPOST))
        {

            yield return web.SendWebRequest();
            Debug.Log(web.downloadHandler.text);
            if (web.result == UnityWebRequest.Result.Success)
            {

                T data = JsonConvert.DeserializeObject<T>(web.downloadHandler.text);
                callback?.Invoke(data);
            }
            else
            {

                callback(default(T));
            }
        }
    }

    public static IEnumerator UpdateServerData<T>(string url, Action<T> callback)
    {

        using (UnityWebRequest web = UnityWebRequest.Put(GetUrl(url),kHttpVerbPUT))
        {

            yield return web.SendWebRequest();
            Debug.Log(web.downloadHandler.text);
            if (web.result == UnityWebRequest.Result.Success)
            {

                T data = JsonConvert.DeserializeObject<T>(web.downloadHandler.text);
                callback?.Invoke(data);
            }
            else
            {

                callback(default(T));
            }
        }
    }

    public static IEnumerator RemoveServerData<T>(string url, Action<T> callback)
    {

        using (UnityWebRequest web = UnityWebRequest.Delete(GetUrl(url)))
        {

            yield return web.SendWebRequest();
            Debug.Log(web.downloadHandler.text);
            if (web.result == UnityWebRequest.Result.Success)
            {

                T data = JsonConvert.DeserializeObject<T>(web.downloadHandler.text);
                callback?.Invoke(data);
            }
            else
            {

                callback(default(T));
            }
        }
    }

}
