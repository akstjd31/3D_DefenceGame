using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    public GameObject structureWindow, weaponWindow;
    public Image structureButtonImage, weaponButtonImage;

    public void OnClickFortressButton()
    {
        structureWindow.SetActive(true);
        weaponWindow.SetActive(false);

        SetButtonAlpha(structureButtonImage, 1f);
        SetButtonAlpha(weaponButtonImage, 0.5f);
    }

    public void OnClickWeaponButton()
    {
        weaponWindow.SetActive(true);
        structureWindow.SetActive(false);

        SetButtonAlpha(weaponButtonImage, 1f);
        SetButtonAlpha(structureButtonImage, 0.5f);
    }

    void SetButtonAlpha(Image buttonImage, float alpha)
    {
        Color color = buttonImage.color;
        color.a = alpha;
        buttonImage.color = color;
    }
}
