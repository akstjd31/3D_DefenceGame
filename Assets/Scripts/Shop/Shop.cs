using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum RATING_TABLE
{
    COMMON, RARE, EPIC, LEGENDARY
}

public class Shop : MonoBehaviour
{
    private GameObject shopCanvas;
    private GameObject shopDisplay;
    private ShopUI shopUI;
    private const int MAX_STRUCTURE = 5; // Max display

    public bool isUIActive = false;

    ///////////////////////////////
    // structure
    public StructureSO structureSO;
    [SerializeField] private List<Structure> commonStructure;
    [SerializeField] private List<Structure> rareStructure;
    [SerializeField] private List<Structure> epicStructure;
    [SerializeField] private List<Structure> legendaryStructure;

    [SerializeField] private List<Structure> displayedStructure; // displayed

    private void Awake()
    {
        foreach (Structure structure in structureSO.structures)
        {
            switch (structure.ratingTable)
            {
                case RATING_TABLE.COMMON:
                    commonStructure.Add(structure);
                    break;
                case RATING_TABLE.RARE:
                    rareStructure.Add(structure);
                    break;
                case RATING_TABLE.EPIC:
                    epicStructure.Add(structure);
                    break;
                case RATING_TABLE.LEGENDARY:
                    legendaryStructure.Add(structure);
                    break;
            }
        }
    }


    private void Start()
    {
        shopCanvas = GameObject.FindGameObjectWithTag("ShopCanvas");
        shopDisplay = shopCanvas.transform.Find("ShopDisplay").gameObject;
        shopUI = shopCanvas.GetComponent<ShopUI>();
    }

    public void AddDisplayStructure(Structure stru)
    {
        displayedStructure.Add(stru);
    }

    public void ClearDisplayStructure()
    {
        displayedStructure.Clear();
    }

    public void Open()
    {
        shopUI.Display();
    
        shopDisplay.SetActive(true);

        isUIActive = true;
        SetCursorVisibility(isUIActive);
    }

    public void Close()
    {
        shopUI.ClearDisplayItems();

        shopDisplay.SetActive(false);

        isUIActive = false;
        SetCursorVisibility(isUIActive);
    }

    private void SetCursorVisibility(bool isVisible)
    {
        Cursor.visible = isVisible;
        Cursor.lockState = isVisible ? CursorLockMode.None : CursorLockMode.Locked;
    }

    public int GetMaxStructure()
    {
        return MAX_STRUCTURE;
    }
    
    //////////////////////////////
    // Legendary : 0 ~ 2%
    // Epic : 3 ~ 10%
    // Rare : 11 ~ 30%
    // Common : 31 ~ 100%
    public Structure RandomStructureReturner()
    {
        float randomRatingProbability = Random.Range(0, 100f);
        int randIdx = -1;

        // legendary
        if (0f <= randomRatingProbability && randomRatingProbability <= 2f)
        {
            randIdx = Random.Range(0, legendaryStructure.Count);
            return legendaryStructure[randIdx];
        }

        // epic
        else if (3f <= randomRatingProbability && randomRatingProbability <= 10f)
        {
            randIdx = Random.Range(0, epicStructure.Count);
            return epicStructure[randIdx];
        }

        // rare
        else if (11f <= randomRatingProbability && randomRatingProbability <= 30f)
        {
            randIdx = Random.Range(0, rareStructure.Count);
            return rareStructure[randIdx];
        }

        // common
        else
        {
            randIdx = Random.Range(0, commonStructure.Count);
            return commonStructure[randIdx];
        }
    }
}