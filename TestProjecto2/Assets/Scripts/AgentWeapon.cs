using Inventory.Model;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AgentWeapon : MonoBehaviour
{
    [SerializeField] private EquipableItemSO _weapon;

    [SerializeField] private InventarySO _inventoryData;

    public int Qbullet;

    private SpriteRenderer _sr;

    private void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        _sr.sprite = _weapon.WeaponSprite;
        Qbullet = _weapon.bulletQuantity;
    }
    public void SetWeapon(EquipableItemSO weaponItemSO)
    {
        if (_weapon != null)
        {
            _inventoryData.AddItem(_weapon,1);
        }
        this._weapon = weaponItemSO;
    }
}
