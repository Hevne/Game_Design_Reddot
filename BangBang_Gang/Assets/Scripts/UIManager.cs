using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    public static UIManager instance;

    public TextMeshProUGUI plantaciones;
    public TextMeshProUGUI magatzems;
    public TextMeshProUGUI money;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateUI()
    {
        plantaciones.text = "";
        magatzems.text = "";
        foreach (Build build in GameManager.instance.plantaciones)
        {
            int num = GameManager.instance.plantaciones.IndexOf(build);
            plantaciones.text += "Plantacion " + (num + 1) + ": " + build.ammount + "/" + build.max_capacity + "\n";
        }

        foreach (Build build in GameManager.instance.magatzems)
        {
           int num =  GameManager.instance.magatzems.IndexOf(build);
            magatzems.text += "Magatzem "+ (num +1) +": "+ build.ammount + "/" + build.max_capacity + "\n";
        }

        money.text = "Money: " + GameManager.instance.money;
    }
}
