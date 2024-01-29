using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats 
{
    public int mineLevel;
    public int woodLevel;
    public int farmLevel;
    public int buildLevel;
    public int damageLevel;


    public Stats(int mineLevel, int woodLevel, int farmLevel, int buildLevel, int damageLevel)
    {
        this.mineLevel = mineLevel;
        this.woodLevel = woodLevel;
        this.farmLevel = farmLevel;
        this.buildLevel = buildLevel;
        this.damageLevel = damageLevel;
    }
}
