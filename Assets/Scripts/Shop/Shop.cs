using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    private GameObject shopCanvas;
    private GameObject shopDisplay;

    public bool isUIActive = false;

    private void Start()
    {
        shopCanvas = GameObject.FindGameObjectWithTag("ShopCanvas");
        shopDisplay = shopCanvas.transform.Find("ShopDisplay").gameObject;
    }

    public void Open()
    {
        shopDisplay.SetActive(true);
        isUIActive = true;
        SetCursorVisibility(isUIActive);
    }

    public void Close()
    {
        shopDisplay.SetActive(false);
        isUIActive = false;
        SetCursorVisibility(!isUIActive);
    }

    private void SetCursorVisibility(bool isVisible)
    {
        Cursor.visible = isVisible;
        Cursor.lockState = isVisible ? CursorLockMode.None : CursorLockMode.Locked;
    }
}