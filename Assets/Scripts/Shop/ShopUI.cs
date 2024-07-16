using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    public GameObject structureWindow, weaponWindow;
    public GameObject structureContent, weaponContent;
    public Image structureButtonImage, weaponButtonImage;
    [SerializeField] private Transform structureUIPrefab;
    private Shop shop;

    void Awake()
    {
        shop = GameObject.FindGameObjectWithTag("Shop").GetComponent<Shop>();
    }

    public void OnClickStructureButton()
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

    public void Display()
    {
        // Structure
        for (var i = 0; i < shop.GetMaxStructure(); i++)
        {
            GameObject prefab = Instantiate(structureUIPrefab.gameObject, Vector3.zero, Quaternion.identity, structureContent.transform);
            StructureUI structureUI = prefab.GetComponent<StructureUI>();

            // structure info
            structureUI.SetStructure(shop.RandomStructureReturner());
            shop.AddDisplayStructure(structureUI.GetStructure());
        }

        // Weapon

    }

    public void ClearDisplayItems()
    {
        shop.ClearDisplayStructure();

        // Clear content child
        foreach (Transform child in structureContent.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
