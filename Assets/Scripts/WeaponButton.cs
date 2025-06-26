using UnityEngine;

public class WeaponButton : MonoBehaviour
{
    [SerializeField] private GameObject weaponInventoryPanel;
    [SerializeField] private GameObject otherCanvas;

    public void OpenWeaponInventory()
    {
        weaponInventoryPanel.SetActive(true);
        otherCanvas.SetActive(false);
    }

    public void CloseWeaponInventory()
    {
        weaponInventoryPanel.SetActive(false);
        otherCanvas.SetActive(true);
    }
}
