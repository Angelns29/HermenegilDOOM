using Inventory.Model;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AgentWeapon : MonoBehaviour
{
    [SerializeField] private EquipableItemSO _weapon;

    [SerializeField] private InventarySO _inventoryData;

    public void SetWeapon(EquipableItemSO weaponItemSO)
    {
        if (_weapon != null)
        {
            _inventoryData.AddItem(_weapon,1);
        }
        this._weapon = weaponItemSO;
    }
}
