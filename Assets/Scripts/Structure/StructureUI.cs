using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureUI : MonoBehaviour
{
    private Structure structure;

    public void SetStructure(Structure stru)
    {
        this.structure = stru;
    }

    public Structure GetStructure()
    {
        return this.structure;
    }
}
