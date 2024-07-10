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

        fortressButtonImage.color = new Color(fortressButtonImage.color.r,
                                            fortressButtonImage.color.g,
                                            fortressButtonImage.color.b,
                                            255);

        weaponButtonImage.color = new Color(weaponButtonImage.color.r,
                                            weaponButtonImage.color.g,
                                            weaponButtonImage.color.b,
                                            150);           
    }

    public void OnClickWeaponButton()
    {
        weaponWindow.SetActive(true);
        fortressWindow.SetActive(false);

        weaponButtonImage.color = new Color(weaponButtonImage.color.r,
                                            weaponButtonImage.color.g,
                                            weaponButtonImage.color.b,
                                            255);  

        fortressButtonImage.color = new Color(fortressButtonImage.color.r,
                                            fortressButtonImage.color.g,
                                            fortressButtonImage.color.b,
                                            150);
    }
}
