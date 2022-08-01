using System;
using System.Collections.Generic;
using UnityEngine;

public class Data<T>
{
    public int code { get; set; }
    public string message { get; set; }
    public T body { get; set; }
}
public class ItemInfo
{
    public int totalCount { get; set; }
    public List<Item> data { get; set; }
}
[Serializable]
public class Item 
{
    public int quantity { get; set; }
    public int price { get; set; }
    public double review { get; set; }
    public double weight { get; set; }
    public string _id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public string catagory { get; set; }
}

public class PurchaseItem
{
    public string prefab { get; set; }
    public string name { get; set; }
    public string quantity { get; set; }
}
