
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    int max_plantaciones;
    int current_plantaciones;
    
    int max_magatzem;
    int current_magatzem;

    public List<Build> plantaciones;
    public List<Build> magatzems;
    public int money;

    private void Awake()
    {
        instance = this;
        plantaciones = new List<Build>();
        magatzems = new List<Build>();
        money = 1000;
    }
    public void CreatPlantacionButton()
    {
        Build build = new Build();
        plantaciones.Add(build);
        UIManager.instance.UpdateUI();      
    } 
    
    public void CreatMagatzemButton()
    {
        Build build = new Build();
        magatzems.Add(build);
        UIManager.instance.UpdateUI();       
    }
}
