using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPotion", menuName = "Inventory/Potion")]
public class Potion : Item
{
    public int quantity;
    public enum PotionType { IncreaseHP, IncreaseWeaponPower, ReduceMonsterDamage }
    public PotionType potionType;
    public float effectDuration; // Set to zero for immediate and permanent effects

    public Potion()
    {
        effectDuration = 0; // Default to zero for permanent effects
        quantity=0;
    }
}