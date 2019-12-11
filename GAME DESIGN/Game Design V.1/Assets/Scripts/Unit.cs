using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Unit : MonoBehaviour
{
    [Header("Stats")]
    public int attack;
    public int defence;
    public int movement;
    public int numUnits;
    public int maxUnits;
    public int price;

    [Header("Components")]
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI defenceText;
    public TextMeshProUGUI movementText;
    public TextMeshProUGUI unitsText;
    public Player_Info info;

    public void UpdateStats()
    {
        attackText.text = attack.ToString();
        defenceText.text = defence.ToString();
        movementText.text = movement.ToString();
        unitsText.text = numUnits + "/" + maxUnits;
        
    }

    public void BuyUnit()
    {
        if (numUnits < maxUnits && info.current_money >= price)
        {
            numUnits++;
            info.current_money -= price;
        }
    }

    public void RemoveUnit()
    {
        if(numUnits > 0)
        {
            numUnits--;
        }
    }
}
