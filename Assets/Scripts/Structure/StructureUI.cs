using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StructureUI : MonoBehaviour
{
    private Structure structure;
    public Text text;
    public RawImage rawImage;
    public Image image;

    public void SetStructure(Structure stru)
    {
        this.structure = stru;

        this.text.text = structure.name;
        this.rawImage.texture = structure.texture;

        Color color = Color.gray;
        switch (structure.ratingTable)
        {
            case RATING_TABLE.RARE:
                color = new Color(55/255f, 198/255f, 255/255f, 1f); // Azure
                break;
            case RATING_TABLE.EPIC:
                color = new Color(174/255f, 55/255f, 255/255f, 1f); // eclipse
                break;
            case RATING_TABLE.LEGENDARY:
                color = new Color(255/255f, 255/255f, 73/255f, 1f);
                break;
        }

        image.color = color;
    }


    public Structure GetStructure()
    {
        return this.structure;
    }
}
