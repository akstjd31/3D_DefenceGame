using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickSlot : MonoBehaviour
{
    ////////////////////////////////
    // slot 1 ~ 3 :structure
    // slot 4 : weapon
    // keyCodes.Length == slots.Length

    [SerializeField] private Slot[] slots;
    [SerializeField] private List<Structure> structureList;
    private const int MAX_STRUCTURE = 3;
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
        structureList = new List<Structure>(MAX_STRUCTURE);
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

    public bool HasSpaceInStructureList()
    {
        if (structureList.Count < MAX_STRUCTURE)
        {
            return true;
        }

        return false;
    }
    
    public void AddStructureList(Structure stru)
    {
        structureList.Add(stru);
        FreshSlot();
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

    public void FreshSlot()
    {
        if (structureList.Count > 0)
        {
            // Structure
            for (int i = 0; i < structureList.Count; i++)
            {
                slots[i].structure = structureList[i];
            }

            // Weapon
        }
    }
}
