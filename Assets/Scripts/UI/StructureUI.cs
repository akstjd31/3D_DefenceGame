using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StructureUI : MonoBehaviour
{
    private Structure structure;
    public Text itemName, cost;
    public RawImage rawImage;
    public Image image;

    public void OnClickBuyButton()
    {
        // Have money?
        if (structure.cost <= Status.MONEY)
        {
            QuickSlot quickSlot = GameObject.FindGameObjectWithTag("Slots").GetComponent<QuickSlot>();
            
            // Have space? (slot)
            if (quickSlot.HasSpaceInStructureList())
            {
                Status.MONEY -= structure.cost;
                quickSlot.AddStructureList(structure);

                Destroy(this.gameObject);
            }
            else
            {
                Debug.Log("Slot is full!");
            }
        }
        else
        {
            Debug.Log("You don't have money!");
        }
    }

    public void SetStructure(Structure stru)
    {
        this.structure = stru;
        Init();
    }

    public void Init()
    {
        this.itemName.text = structure.name;
        this.rawImage.texture = structure.texture;

        Color color = Color.gray;
        switch (structure.ratingTable)
        {
            case RATING_TABLE.RARE:
                color = new Color(55/255f, 198/255f, 255/255f, 1f); // Azure
                break;
            case RATING_TABLE.EPIC:
                color = new Color(174/255f, 55/255f, 255/255f, 1f); // Eclipse
                break;
            case RATING_TABLE.LEGENDARY:
                color = new Color(255/255f, 255/255f, 73/255f, 1f); // Yellow
                break;
        }

        this.image.color = color;
        this.cost.text = structure.cost + "$";
    }

    public Structure GetStructure()
    {
        return this.structure;
    }
}
