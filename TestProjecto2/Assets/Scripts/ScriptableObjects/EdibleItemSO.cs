using Inventory.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.Model
{
    [CreateAssetMenu]
    public class EdibleItemSO : ItemTemplate, IDestroyableItem, IItemAction
    {
        [SerializeField] private List<ModifierData> _modifiersData = new List<ModifierData>();
        public string ActionName => "Consume";

        public AudioClip actionSFX { get; private set; }

        public bool PerformAction(GameObject character)
        {
            foreach (ModifierData data in _modifiersData)
            {
                data.statsModifier.AffectCharacter(character, data.value);
            }
            return true;
        }
    }
    [Serializable]
    public class ModifierData
    {
        public CharacterStatsModifierSO statsModifier;
        public float value;
    }
}
