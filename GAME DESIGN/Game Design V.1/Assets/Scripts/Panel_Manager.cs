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
    public GameObject[] plants;
    public GameObject[] wareHouses;

    [Header("Units")]
    public Unit[] units;
    public TextMeshProUGUI moneyText;


    [Header("AvailablePlants")]
    public GameObject[] plantsToUpgrade;
    public GameObject[] wareHouseToUpgrade;


    void Start()
    {
        for (int i = 1; i < panel_array.Length; i++)
        {
            panel_array[i].SetActive(false);
        }

        for (int i = 0; i < plants.Length; i++)
        {
            TextMeshProUGUI text = plants[i].GetComponentInChildren<TextMeshProUGUI>();
            text.text = "Lvl " + Plants_Building[i].level + ":";

            plants[i].SetActive(false);
        }

        for (int i = 0; i < wareHouses.Length; i++)
        {
            TextMeshProUGUI text = wareHouses[i].GetComponentInChildren<TextMeshProUGUI>();
            text.text = "Lvl " + WareHouse_Building[i].level + ":";

            plants[i].SetActive(false);
        }
    }

    private void UpdatePlantsUI()
    {
        for (int i = 0; i < plants.Length; i++)
        {
            TextMeshProUGUI text = plants[i].GetComponentInChildren<TextMeshProUGUI>();
            text.text = "Lvl " + Plants_Building[i].level + ":";

        }
    }  
    
    private void UpdateWareHouseUI()
    {
        for (int i = 0; i < wareHouses.Length; i++)
        {
            TextMeshProUGUI text = wareHouses[i].GetComponentInChildren<TextMeshProUGUI>();
            text.text = "Lvl " + WareHouse_Building[i].level + ":";

        }
    }

    public void PreClickType(bool type)
    {
        diceRollType = type;
    }

    public void ChangeScreen(int selector)
    {

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
                if (plants[i].activeInHierarchy && Plants_Building[i].unLocked)
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
                    info.AddMoney(WareHouse_Building[i].WarehouseMoneyCleaning(result,(int)Money_Laundering_Building.level));
                }
            }
            info.UpdateWareHouseUI();
        }
        ChangeScreen(0);
    }

    public void Remove10Units(int position)
    {
        if (Plants_Building[position].currentValue - 10 >= 0)
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
        else if(WareHouse_Building[position].currentValue + 10 >= WareHouse_Building[position].maxCapacity && WareHouse_Building[position].unLocked)
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

        if (buy == true)
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
        info.PrintMoneyText();
    }

    public void AddPlant(Button button)
    {
        for (int i = 0; i < plants.Length; i++)
        {
            if (!plants[i].activeInHierarchy && info.current_money >= Plants_Building[i].buyPrice)
            {
                info.current_money -= Plants_Building[i].buyPrice;
                info.PrintMoneyText();
                plants[i].SetActive(true);

                break;
            }

        }

        if (plants[plants.Length -1].activeInHierarchy)
        {
            button.interactable = false;
        }
    }

    public void OpenUpgradeScreen()
    {
        for (int i = 0; i < plants.Length; i++)
        {
            if (plants[i].activeInHierarchy)
            {
                plantsToUpgrade[i].SetActive(true);
                TextMeshProUGUI text = plantsToUpgrade[i].GetComponentInChildren<TextMeshProUGUI>();
                int price;
                if (Plants_Building[i].level == 0)
                {
                    price = Plants_Building[i].upgradePriceLevel1;
                }
                else
                {
                    price = Plants_Building[i].upgradePriceLevel2;
                }
                text.text = "Plant " + (i + 1) + ": Lvl " + Plants_Building[i].level + " (" + price + "€)";

            }
            else
            {
                plantsToUpgrade[i].SetActive(false);
            }
        }
    }   
    
    public void OpenUpgradeWareHouseScreen()
    {
        for (int i = 0; i < wareHouses.Length; i++)
        {
            if (wareHouses[i].activeInHierarchy)
            {
                wareHouseToUpgrade[i].SetActive(true);
                TextMeshProUGUI text = wareHouseToUpgrade[i].GetComponentInChildren<TextMeshProUGUI>();
                text.text = "WH" + (i + 1) + ": Lvl " + WareHouse_Building[i].level;

            }
            else
            {
                wareHouseToUpgrade[i].SetActive(false);
            }
        }
    }

    public void UpgradePlant(int num)
    {
        if (Plants_Building[num].level == 0 && info.current_money >= Plants_Building[num].upgradePriceLevel1)
        {
            info.current_money -= Plants_Building[num].upgradePriceLevel1;
            Plants_Building[num].level++;
        } 
        else if (Plants_Building[num].level == 1 && info.current_money >= Plants_Building[num].upgradePriceLevel2)
        {
            info.current_money -= Plants_Building[num].upgradePriceLevel2;
            Plants_Building[num].level++;
        }

        if (Plants_Building[num].level == 2)
        {
            Plants_Building[num].maxCapacity = 100;
            info.plant_sliders[num].maxValue = Plants_Building[num].maxCapacity;
            info.UpdatePlantsUI();
        }
        info.PrintMoneyText();
        OpenUpgradeScreen();
        UpdatePlantsUI();
    }

    public void UpgradeWareHouse(int num)
    {
        if(WareHouse_Building[num].level == 0 && info.current_money >= WareHouse_Building[num].upgradePriceLevel1)
        {
            info.current_money -= WareHouse_Building[num].upgradePriceLevel1;
            WareHouse_Building[num].level++;
            WareHouse_Building[num].maxCapacity = 150;
            info.UpdateWareHouseUI();
        }
        else if(WareHouse_Building[num].level == 1 && info.current_money >= WareHouse_Building[num].upgradePriceLevel2)
        {
            info.current_money -= WareHouse_Building[num].upgradePriceLevel2;
            WareHouse_Building[num].level++;
            WareHouse_Building[num].maxCapacity = 250;
            info.UpdateWareHouseUI();
        }
        info.PrintMoneyText();
        OpenUpgradeWareHouseScreen();
        UpdateWareHouseUI();
    }

    public void BuyWareHouse(Button button)
    {
        if (info.current_money >= WareHouse_Building[1].buyPrice)
        {
            wareHouses[1].SetActive(true);
            info.current_money -= WareHouse_Building[1].buyPrice;
            info.PrintMoneyText();
            button.interactable = false;
        }
    }


    public void Repair_DestroyPlant(int num)
    {

    }
    public void DestroyPlant(int num)
    {
        Plants_Building[num].unLocked = false;
        Plants_Building[num].currentValue = 0;
        info.UpdatePlantsUI();
    }   
       
    public void DestroyWareHouse(int num)
    {
        WareHouse_Building[num].unLocked = false;
        WareHouse_Building[num].currentValue = 0;
        info.UpdateWareHouseUI();
    }   

    public void RepairWarehouse(int num)
    {
        WareHouse_Building[num].unLocked = true;
    } 

    public void RepairPlant(int num)
    {
        Plants_Building[num].unLocked = true;

    } 


    public void BuyOperationCenter(Button button)
    {
        if(info.current_money >= Operations_Center_Building.buyPrice)
        {
            info.current_money -= Operations_Center_Building.buyPrice;
            info.PrintMoneyText();
            units[2].defence++;
            button.interactable = false;
            Operations_Center_Building.unLocked = true;
        }
    }
    public void ActiveButton(Button button)
    {

        button.interactable = true;
    }

    public void BuyWeaponWorkshop(Button button)
    {
        if(info.current_money >= Workshop_Building.buyPrice)
        {
            info.current_money -= Workshop_Building.buyPrice;
            info.PrintMoneyText();
            units[0].maxUnits++;
            button.interactable = false;
            Workshop_Building.unLocked = true;
        }
    }

    public void UpgradeWorkShop(Button button)
    {
        if(Workshop_Building.level == 0 && info.current_money >= Workshop_Building.upgradePriceLevel1)
        {
            info.current_money -= Workshop_Building.upgradePriceLevel1;
            Workshop_Building.level++;
            units[0].attack++;
            info.PrintMoneyText();
        }
        else if(Workshop_Building.level == 1 && info.current_money >= Workshop_Building.upgradePriceLevel2)
        {
            info.current_money -= Workshop_Building.upgradePriceLevel2;
            info.PrintMoneyText();
            units[0].movement++;
            Workshop_Building.level++;
            button.interactable = false;
        }
    }  
    
    public void UpgradeOperationCenter(Button button)
    {
        if(Operations_Center_Building.level == 0 && info.current_money >= Operations_Center_Building.upgradePriceLevel1)
        {
            info.current_money -= Operations_Center_Building.upgradePriceLevel1;
            Operations_Center_Building.level++;
            units[2].movement++;
            info.PrintMoneyText();
        }
        else if(Operations_Center_Building.level == 1 && info.current_money >= Operations_Center_Building.upgradePriceLevel2)
        {
            info.current_money -= Operations_Center_Building.upgradePriceLevel2;
            Operations_Center_Building.level++;
            info.PrintMoneyText();
            button.interactable = false;
        }
    }
    
    public void UpgradeMoneyLaundering(Button button)
    {
        if(Money_Laundering_Building.level == 0 && info.current_money >= Money_Laundering_Building.upgradePriceLevel1)
        {
            info.current_money -= Money_Laundering_Building.upgradePriceLevel1;
            Money_Laundering_Building.level++;
            info.PrintMoneyText();
            button.interactable = false;
        }

    }
    
}
