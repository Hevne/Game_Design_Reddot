using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Panel_Manager : MonoBehaviour
{
    [Header("Panel Settings")]
    public GameObject[] panel_array;
    int currentScreen = 0;

    [Header("Script Sharing")]
    public Player_Info info;

    [Header("Dice Settings")]
    bool diceRollType;

    [Header("Buildings Info")]
    public Buildings[] WareHouse_Building;
    public Buildings[] Plants_Building;
    public Buildings Workshop_Building;
    public Buildings GangHCQ_Building;
    public Buildings Operations_Center_Building;
    public Buildings Money_Laundering_Building;

    [Header("Units")]
    public Unit[] units;
    public TextMeshProUGUI moneyText;


    void Start()
    {
        for (int i = 1; i < panel_array.Length; i++)
        {
            panel_array[i].SetActive(false);
        }
    }

    public void PreClickType(bool type)
    {
        diceRollType = type;
    }

    public void ChangeScreen(int selector)
    {

        panel_array[currentScreen].SetActive(false);
        panel_array[selector].SetActive(true);
        currentScreen = selector;
    }

    public void DiceRoll(int result)
    {
        if (!diceRollType)
        {
            //Produce plants
            for (int i = 0; i < Plants_Building.Length; i++)
            {
                if (Plants_Building[i].unLocked)
                    Plants_Building[i].IncreaseValuePlant((uint)result);
            }
            info.UpdatePlantsUI();

        }
        else
        {
            //ML
            for (int i = 0; i < WareHouse_Building.Length; i++)
            {
                if (WareHouse_Building[i].unLocked)
                {
                    info.AddMoney(WareHouse_Building[i].WarehouseMoneyCleaning(result));
                }
            }
            info.UpdateWareHouseUI();
        }
        ChangeScreen(0);
    }

    public void Remove10Units(int position)
    {
        if(Plants_Building[position].currentValue - 10 >= 0 && Plants_Building[position].unLocked)
        {
            Plants_Building[position].currentValue -= 10;
            info.UpdatePlantsUI();
        }
    }
    public void Add10Units(int position)
    {
        if (WareHouse_Building[position].currentValue + 10 <= WareHouse_Building[position].maxCapacity && WareHouse_Building[position].unLocked)
        {
            WareHouse_Building[position].currentValue += 10;
        }
        else
        {
            WareHouse_Building[position].currentValue = (int)WareHouse_Building[position].maxCapacity;
        }
        info.UpdateWareHouseUI();
    }

    public void InstallClick(int s_type)
    {
        bool buy = false;
        Buildings currentBuilding;
        BuildingType tp = (BuildingType)s_type;
        switch (tp)
        {
            case BuildingType.WareHouse:
                //Diferent bh
                break;

            case BuildingType.Plant:
                //Diferent bh
                break;

            case BuildingType.Workshop:
                if (!Workshop_Building.unLocked)
                {
                    currentBuilding = Workshop_Building;
                    buy = true;
                }
                break;

            case BuildingType.GangHCQ:
                if (!GangHCQ_Building.unLocked)
                {
                    currentBuilding = GangHCQ_Building;
                    buy = true;
                }
                break;

            case BuildingType.Operations_Center:
                if (!Operations_Center_Building.unLocked)
                {
                    currentBuilding = Operations_Center_Building;
                    buy = true;
                }
                break;

            case BuildingType.Money_Laundering:
                if (!Money_Laundering_Building.unLocked)
                {
                    currentBuilding = Money_Laundering_Building;
                    buy = true;
                }
                break;



        }

        if(buy == true)
        {
            //Buy
        }
        else
        {
            //Do stuff
        }


    }

    public void UpdateUnits()
    {
        for (int i = 0; i < units.Length; i++)
        {
            units[i].UpdateStats();
        }

        moneyText.text = info.current_money.ToString("C0");
    }

}
