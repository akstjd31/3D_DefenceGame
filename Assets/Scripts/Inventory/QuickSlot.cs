using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickSlot : MonoBehaviour
{
    ///////////////////////////////
    // keyCodes.Length == slots.Length
    [SerializeField] private Slot[] slots;
    private KeyCode[] keyCodes = new KeyCode[] 
    {
        KeyCode.Alpha1,
        KeyCode.Alpha2,
        KeyCode.Alpha3,
        KeyCode.Alpha4
    };

    private void Awake()
    {
        slots = this.GetComponentsInChildren<Slot>();
    }

    private void Start()
    {

    }

    private void Update()
    {
        for (int i = 0; i < keyCodes.Length; i++)
        {
            if (Input.GetKeyDown(keyCodes[i]))
            {
                ChangeSlot(i);
            }
        }
    }

    private void ChangeSlot(int idx)
    {
        slots[idx].GetComponent<Image>().color = Color.green;
        for (int i = 0; i < slots.Length; i++)
        {
            if (i != idx)
            {
                slots[i].GetComponent<Image>().color = Color.black;
            }
        }
    }
}
