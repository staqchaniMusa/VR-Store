using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NavBarUI : MonoBehaviour
{
    public Color normal, selected;
    public Button[] buttons;
    public GameObject[] pages;
    int currentSelected;
    // Start is called before the first frame update
    void Start()
    {
        Select(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Select(int index)
    {
        for(int i = 0; i< buttons.Length; i++)
        {
            buttons[i].image.color = normal;
            pages[i].SetActive(false);
        }

        buttons[index].image.color = selected;
        pages[index].SetActive(true);
    }
}
