using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] RawImage rawImage;

    private Structure stru;

    private void Start()
    {
    }

    private void Update()
    {
        // if (countText != null)
        //     countText.text = count.ToString();
    }

    public Structure structure
    {
        get { return stru; }
        set
        {
            stru = value;
            if (structure != null)
            {
                rawImage.texture = structure.texture;
            }
            else
            {
                rawImage.texture = null;
            }
        }
    }
}


