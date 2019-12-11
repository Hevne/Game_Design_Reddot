using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSprite : MonoBehaviour
{
    public Image curr;
    public Sprite repair;
    public Sprite destroy;

    public Panel_Manager manager;

    public bool destroyed = false;


    public void Repair_DestroyPlant(int num)
    {
        if (!destroyed)
        {
            curr.sprite = repair;
            destroyed = true;
            manager.DestroyPlant(num);
        
        }
        else
        {
            curr.sprite = destroy;
            destroyed = false;
            manager.RepairPlant(num);
        }
    }   
    
    public void Repair_DestroyWareHouse(int num)
    {
        if (!destroyed)
        {
            curr.sprite = repair;
            destroyed = true;
            manager.DestroyWareHouse(num);
        
        }
        else
        {
            curr.sprite = destroy;
            destroyed = false;
            manager.RepairWarehouse(num);
        }
    }



}
