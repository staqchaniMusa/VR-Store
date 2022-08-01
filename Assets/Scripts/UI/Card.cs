using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public Text nameLabel;
    public Text priceLabel;
    public Text descriptionLabel;
    public Item data;
    public void SetData(Item item)
    {
        data = item;
        nameLabel.text =  item.name;
        priceLabel.text = "Price: " + item.price;
        descriptionLabel.text = item.description;
    }

    public void OnClick(CardMetaData meta)
    {
        meta.SetData(data);
        meta.gameObject.SetActive(true);
    }
}
