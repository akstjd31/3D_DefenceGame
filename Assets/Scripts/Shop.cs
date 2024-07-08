using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    private GameObject shopCanvas;
    private GameObject shopDisplay;

    private void Start()
    {
        shopCanvas = GameObject.FindGameObjectWithTag("ShopCanvas");
        shopDisplay = shopCanvas.transform.Find("ShopDisplay").gameObject;
    }

    public void Open()
    {
        shopDisplay.SetActive(true);
    }

    public void Close()
    {
        shopDisplay.SetActive(false);
    }
}