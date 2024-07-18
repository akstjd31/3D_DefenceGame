using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatUI : MonoBehaviour
{
    public Text money, life;

    private void Update()
    {
        life.text = "Life: " + Status.LIFE;
        money.text = "Money: " + Status.MONEY;
    }
}
