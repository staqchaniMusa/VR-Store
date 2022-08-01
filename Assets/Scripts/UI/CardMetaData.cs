using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardMetaData : MonoBehaviour
{

    Item item;
    public Text NameLabel;
    public Text priceLabel;
    public Text categoryLabel;
    public Text descriptionLabel;
    public Text weightLabel;

    public Button btn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetData(Item item)
    {
        this.item = item;
        NameLabel.text = item.name;
        priceLabel.text = "Price: " + item.price;
        categoryLabel.text = "Category: " + item.catagory;
        descriptionLabel.text = "Description\n" + item.description;
        weightLabel.text = "Weight: " + item.weight;
        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        btn.interactable = false;
        StartCoroutine(StoreApi.UpdateServerData<Data<PurchaseItem>>($"api/item/buyItems?quantity=1&id={item._id}",(item)=> {
            if (item == null)
            {
                btn.interactable = true;
                return;
            }

            AddressableDataLoader.InstantiatePrefab(item.body.prefab, StoreManager.Instance.ActivePlayer, Vector3.forward * 1f, (success) => {
                
                if (success)
                {
                    btn.interactable = true;
                    gameObject.SetActive(false);
                }
                else btn.interactable = true;
            });
        }));
    }
}
