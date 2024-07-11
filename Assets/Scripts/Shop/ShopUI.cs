using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    public GameObject fortressWindow, weaponWindow;
    public Image fortressButtonImage, weaponButtonImage;

    public void OnClickFortressButton()
    {
        fortressWindow.SetActive(true);
        weaponWindow.SetActive(false);

        SetButtonAlpha(fortressButtonImage, 1f);
        SetButtonAlpha(weaponButtonImage, 0.5f);
    }

    public void OnClickWeaponButton()
    {
        weaponWindow.SetActive(true);
        fortressWindow.SetActive(false);

        SetButtonAlpha(weaponButtonImage, 1f);
        SetButtonAlpha(fortressButtonImage, 0.5f);
    }

    void SetButtonAlpha(Image buttonImage, float alpha)
    {
        Color color = buttonImage.color;
        color.a = alpha;
        buttonImage.color = color;
    }
}
