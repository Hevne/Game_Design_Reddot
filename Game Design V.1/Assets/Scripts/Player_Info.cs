using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Info : MonoBehaviour
{


    [Header("Money Settings")]
    public int current_money;
    public Text money_text;
    public Panel_Manager p_manager;

    [Header("UI Settings")]
    public Slider[] plant_sliders;
    public Slider[] warehouse_sliders;

    void Start()
    {
        PrintMoneyText();
        UpdatePlantsUI();
        UpdateWareHouseUI();
    }

    public void AddMoney(int increment)
    {
        current_money += increment;
        Debug.Log(increment);
        PrintMoneyText(); 
    }

    void PrintMoneyText()
    {
        money_text.text = current_money.ToString("C0");
    }



    public void UpdatePlantsUI()
    {

        int i = 0;
        foreach (Slider item in plant_sliders)
        {
            Buildings crb = p_manager.Plants_Building[i];
            item.maxValue = crb.maxCapacity;
            Text slider_text = item.GetComponentInChildren<Text>();
            item.value = crb.currentValue;
            slider_text.text = crb.currentValue + " / " + crb.maxCapacity;
            i++;
        }
    }

    public void UpdateWareHouseUI()
    {
        int i = 0;
        foreach (Slider item in warehouse_sliders)
        {
            Buildings crb = p_manager.WareHouse_Building[i];
            item.maxValue = crb.maxCapacity;
            Text slider_text = item.GetComponentInChildren<Text>();
            item.value = crb.currentValue;
            slider_text.text = crb.currentValue + " / " + crb.maxCapacity;
            i++;
        }
    }



}
