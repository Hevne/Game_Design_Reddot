using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BuildingType
{

    WareHouse,
    Plant,
    Workshop,
    GangHCQ,
    Operations_Center,
    Money_Laundering
}

[System.Serializable]
public class Buildings
{

    public BuildingType type;

    public uint defense;
    public uint level;
    public uint maxLevel;
    public uint maxCapacity;
    public int currentValue;

    public bool unLocked = false;


    public void IncreaseValuePlant(uint increment)
    {

        uint inc = 0;

        switch (level)
        {
            case 0:
                inc = increment * 2;
                break;

            case 1:
                inc = increment * 3;
                break;

            case 2:
                inc = increment * 2;
                break;
        }

        if (currentValue + inc <= maxCapacity)
        {
            currentValue += (int)inc;
        }
        else
        {
            currentValue = (int)maxCapacity;
        }
    }

    public int WarehouseMoneyCleaning(int increment)
    {
        int inc = 0;
        int valueToUse = 0;

        if (currentValue - increment >= 0)
        {
            currentValue -= increment;
            valueToUse = increment;
        }
        else
        {
            valueToUse = currentValue;
            currentValue = 0;
        }

        switch (level)
        {
            case 0:
                inc = valueToUse * 20;
                break;

            case 1:
                inc = valueToUse * 30;
                break;
        }
        return inc;

    }


}