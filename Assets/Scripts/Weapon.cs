using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Inventory/Weapon")]

public class Weapon : Item
{
    public int level;
    public int power;
    public int maxLevel = 5;
    public List<UpgradeCost> upgradeCosts;

    [System.Serializable]
    public struct UpgradeCost
    {
        public int coins;
        public int jewels;
    }

    public int GetUpgradeCostCoins()
    {
        if (level < maxLevel)
            return upgradeCosts[level].coins;
        return 0;
    }

    public int GetUpgradeCostJewels()
    {
        if (level < maxLevel)
            return upgradeCosts[level].jewels;
        return 0;
    }
}


