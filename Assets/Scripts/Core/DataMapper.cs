using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataMapper : MonoBehaviour
{
    public GameObject CardPrefab;
    public Transform Content;
    public string url;
    // Start is called before the first frame update
    void Start()
    {
        
        GetData();
    }

    void GetData()
    {
        StartCoroutine(StoreApi.GetServerData<Data<ItemInfo>>(url, (res) =>
        {
            if(res != null)
            foreach (var data in res.body.data)
            {
                GameObject go = Instantiate(CardPrefab, Content);
                go.GetComponent<Card>().SetData(data);
                go.SetActive(true);
            }
        }));
    }
}
