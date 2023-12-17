using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

namespace Inventory.Model
{
    [CreateAssetMenu]
    public class EquipableItemSO : ItemTemplate, IDestroyableItem, IItemAction
    {
        public string ActionName => "Equip";

        public AudioClip actionSFX { get; private set; }

        public bool PerformAction(GameObject character)//, List<ItemParameter> itemState = null
        {
            return true;
        }
        public float weaponDamage;
        //Determina que bala dispara esa arma, de esta manera controlaremos lo que hace cada una.
        public string bulletType;
    }
}

