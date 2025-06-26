using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DamageTester : MonoBehaviour
{
    public AttributesManager playerAtm;
    public AttributesManager enemyAtm;
   [SerializeField] private Text hpText;

    public float attackCooldown = 1f; // Time between attacks
    private float lastAttackTime = 0f;

    // Update is called once per frame
    private void Update()
    {
      
        
        // Deal player damage to the enemy health
        if (Input.GetKeyDown(KeyCode.Z))
        {
            playerAtm.DealDamage(enemyAtm.gameObject);
        }

        // Check if the player is in range and the cooldown period has passed
        if (CanAttack())
        {
            // Perform the attack
            enemyAtm.DealDamage(playerAtm.gameObject);

            // Update the last attack time
            lastAttackTime = Time.time;

        }
          UpdateHpText();
    }

    bool CanAttack()
    {
        // Check if enough time has passed since the last attack
        return Time.time - lastAttackTime >= attackCooldown;
    }
     private void UpdateHpText() 
    { 
        hpText.text = playerAtm.health.ToString(); 
    } 
}
