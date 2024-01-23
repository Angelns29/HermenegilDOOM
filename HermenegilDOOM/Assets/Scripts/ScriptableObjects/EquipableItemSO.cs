using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.Model
{
    [CreateAssetMenu( menuName = "Items/EquipableItem")]
    public class EquipableItemSO : ItemTemplate, IDestroyableItem, IItemAction
    {
        public string ActionName => "Equip";

        public AudioClip actionSFX { get; private set; }

        public bool PerformAction(GameObject weapon)//, List<ItemParameter> itemState = null
        {
            AgentWeapon weaponSystem = weapon.GetComponent<AgentWeapon>();
            if (weaponSystem != null)
            {
                weaponSystem.SetWeapon(this);
                return true;
            }
            return false;
        }
        public float weaponDamage;
        //Determina que bala dispara esa arma, de esta manera controlaremos lo que hace cada una.
        public GameObject bulletType;

        public int bulletQuantity;
    }
}

