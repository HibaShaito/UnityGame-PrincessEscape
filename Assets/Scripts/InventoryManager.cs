using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    // Panels
    public GameObject weaponPanel;
    public GameObject potionPanel;

    // UI elements for displaying weapon details
    public Text weaponNameText;
    public Text weaponDescriptionText;
    public Text weaponLevelText;
    public Text weaponPowerText;
    public Image weaponImage;
    public Button upgradeButton;
    public Button equipButton;
    public Text upgradeCostCoinsText;
    public Text upgradeCostJewelsText;

    // UI elements for displaying potion details
    public Text potionNameText;
    public Text potionDescriptionText;
    public Image potionImage;
    public Button useButton;
    public Text potionQuantityText;

    // Inventory items
    [SerializeField]
    private List<Item> items;

    // Dropdowns
    public Dropdown weaponDropdown;
    public Dropdown potionDropdown;

    // Selected items
    private Weapon selectedWeapon;
    private Potion selectedPotion;

    void Start()
    {
        // Populate dropdowns
        PopulateWeaponDropdown();
        PopulatePotionDropdown();

        // Set up dropdown listeners
        weaponDropdown.onValueChanged.AddListener(OnWeaponDropdownValueChanged);
        potionDropdown.onValueChanged.AddListener(OnPotionDropdownValueChanged);

        // Clear details
        ClearDetails();
    }

    void PopulateWeaponDropdown()
    {
        weaponDropdown.ClearOptions();

        List<string> weaponNames = new List<string>();
        foreach (var item in items)
        {
            if (item is Weapon weapon)
            {
                weaponNames.Add(item.itemName);
            }
        }

        weaponDropdown.AddOptions(weaponNames);
    }

    void PopulatePotionDropdown()
    {
        potionDropdown.ClearOptions();

        List<string> potionNames = new List<string>();
        foreach (var item in items)
        {
            if (item is Potion potion)
            {
                potionNames.Add(item.itemName);
            }
        }

        potionDropdown.AddOptions(potionNames);
    }

    void OnWeaponDropdownValueChanged(int index)
    {
        Debug.Log($"Weapon Dropdown Changed: Index {index}");
        if (index >= 0 && index < items.Count)
        {
            var selectedItem = items.Find(item => item is Weapon && item.itemName == weaponDropdown.options[index].text);
            if (selectedItem is Weapon weapon)
            {
                OnItemSelected(weapon);
            }
        }
    }

    void OnPotionDropdownValueChanged(int index)
    {
        Debug.Log($"Potion Dropdown Changed: Index {index}");
        if (index >= 0 && index < items.Count)
        {
            var selectedItem = items.Find(item => item is Potion && item.itemName == potionDropdown.options[index].text);
            if (selectedItem is Potion potion)
            {
                OnItemSelected(potion);
            }
        }
    }

    void OnItemSelected(Item item)
    {
        if (item is Weapon weapon)
        {
            selectedWeapon = weapon;
            selectedPotion = null;
            ShowWeaponDetails(selectedWeapon);
        }
        else if (item is Potion potion)
        {
            selectedPotion = potion;
            selectedWeapon = null;
            ShowPotionDetails(selectedPotion);
        }
    }

    void ShowWeaponDetails(Weapon weapon)
    {
        weaponNameText.text = weapon.itemName;
        weaponDescriptionText.text = weapon.description;
        weaponLevelText.text = weapon.level.ToString();
        weaponPowerText.text = weapon.power.ToString();
        weaponImage.sprite = weapon.image;

        upgradeButton.gameObject.SetActive(true);
        equipButton.gameObject.SetActive(true);
        useButton.gameObject.SetActive(false);
        upgradeCostCoinsText.text = "" +weapon.GetUpgradeCostCoins();
        upgradeCostJewelsText.text ="" +weapon.GetUpgradeCostJewels();
    }

    void ShowPotionDetails(Potion potion)
    {
        potionNameText.text = potion.itemName;
        potionDescriptionText.text = potion.description;
        potionImage.sprite = potion.image;
        potionQuantityText.text = potion.quantity.ToString();

        upgradeButton.gameObject.SetActive(false);
        equipButton.gameObject.SetActive(false);
        useButton.gameObject.SetActive(true);
    }

    void ClearDetails()
    {
        weaponNameText.text = "";
        weaponDescriptionText.text = "";
        weaponLevelText.text = "";
        weaponPowerText.text = "";
        weaponImage.sprite = null;
        upgradeButton.gameObject.SetActive(false);
        equipButton.gameObject.SetActive(false);
        upgradeCostCoinsText.text = "";
        upgradeCostJewelsText.text = "";

        potionNameText.text = "";
        potionDescriptionText.text = "";
        potionImage.sprite = null;
        potionQuantityText.text = "";
        useButton.gameObject.SetActive(false);
    }

    public void UpgradeWeapon()
    {
        if (selectedWeapon != null && selectedWeapon.level < selectedWeapon.maxLevel)
        {
            int requiredCoins = selectedWeapon.GetUpgradeCostCoins();
            int requiredJewels = selectedWeapon.GetUpgradeCostJewels();

            if (PlayerHasEnoughResources(requiredCoins, requiredJewels))
            {
                DeductPlayerResources(requiredCoins, requiredJewels);
                selectedWeapon.level++;
                selectedWeapon.power += 5;
                ShowWeaponDetails(selectedWeapon);
            }
        }
    }

    bool PlayerHasEnoughResources(int coins, int jewels)
    {
        // Implement logic to check if player has enough coins and jewels
        return true; // Placeholder
    }

    void DeductPlayerResources(int coins, int jewels)
    {
        // Implement logic to deduct coins and jewels from player
    }

    public void EquipWeapon()
    {
        if (selectedWeapon != null)
        {
            // Implement the logic to equip the weapon to the character
        }
    }

    public void UsePotion()
    {
        if (selectedPotion != null && selectedPotion.quantity > 0)
        {
            selectedPotion.quantity--;
            ApplyPotionEffect(selectedPotion);
            ShowPotionDetails(selectedPotion);
        }
    }

    void ApplyPotionEffect(Potion potion)
    {
        switch (potion.potionType)
        {
            case Potion.PotionType.IncreaseHP:
                IncreaseHP();
                break;
            case Potion.PotionType.IncreaseWeaponPower:
                StartCoroutine(TemporaryIncreaseWeaponPower(potion.effectDuration));
                break;
            case Potion.PotionType.ReduceMonsterDamage:
                StartCoroutine(TemporaryReduceMonsterDamage(potion.effectDuration));
                break;
        }
    }

    void IncreaseHP()
    {
        // Implement logic to permanently increase HP
    }

    IEnumerator TemporaryIncreaseWeaponPower(float duration)
    {
        // Implement logic to temporarily increase weapon power
        yield return new WaitForSeconds(duration);
        // Revert the effect after duration
    }

    IEnumerator TemporaryReduceMonsterDamage(float duration)
    {
        // Implement logic to temporarily reduce monster damage
        yield return new WaitForSeconds(duration);
        // Revert the effect after duration
    }
}
