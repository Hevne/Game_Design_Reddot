using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Build
{
    public int max_capacity;
    public int ammount;

    public int productionValue;
    public int productionRatio;

    public Build()
    {
        this.max_capacity = 100;
        this.ammount = 0;
        this.productionValue = 10;
        this.productionRatio = 1;
    }
    public Build(int max_capacity, int ammount, int productionValue)
    {
        this.max_capacity = max_capacity;
        this.ammount = ammount;
        this.productionValue = productionValue;
        this.productionRatio = 1;
    }

    public void GainProduct(int ratio)
    {
        ammount += productionValue * ratio;
    }

    public void RemoveProduct(int num)
    {
        ammount -= num;
    }

   public int CleanMoney(int ammount, int ratio)
    {
        int product = ammount * ratio;
        RemoveProduct(product);
        return product;
    }


}
