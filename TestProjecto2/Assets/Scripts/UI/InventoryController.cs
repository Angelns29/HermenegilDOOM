using Inventory.Model;
using Inventory.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField] private UIInventoryPage _inventoryUI;

        [SerializeField] private InventarySO _inventoryData;

        public List<InventoryItem> initialItems = new List<InventoryItem>();

        private void Start()
        {
            PrepareUI();
            PrepareInventoryData();
        }

        private void PrepareInventoryData()
        {
            _inventoryData.Initialize();
            _inventoryData.OnInventoryUpdated += UpdateInventoryUI;
            foreach (var item in initialItems)
            {
                if(item.IsEmpty || item.item == null) continue;
                _inventoryData.AddItem(item);
            }
        }

        private void UpdateInventoryUI(Dictionary<int, InventoryItem> inventoryState)
        {
            _inventoryUI.ResetAllItems();
            foreach (var item in inventoryState)
            {
                _inventoryUI.UpdateData(item.Key, item.Value.item.WeaponSprite,item.Value.quantity);
            }
        }

        private void PrepareUI()
        {
            _inventoryUI.InitializeInventoryUI(_inventoryData.Size);
            this._inventoryUI.OnDescriptionRequested += HandleDescriptionRequest;
            this._inventoryUI.OnSwapItems += HandleSwapItems;
            this._inventoryUI.OnStartDragging += HandleDragging;
            this._inventoryUI.OnItemActionRequested += HandleItemActionRequest;

        }

        private void HandleItemActionRequest(int itemIndex)
        {
            InventoryItem inventoryItem = _inventoryData.GetItemAt(itemIndex);
            if (inventoryItem.IsEmpty) return;
            IItemAction itemAction = inventoryItem.item as IItemAction;
            if (itemAction != null)
            {
                itemAction.PerformAction(gameObject);
            }
            IDestroyableItem destroyableItem = inventoryItem.item as IDestroyableItem;
            if (destroyableItem != null)
            {
                _inventoryData.RemoveItem(itemIndex, 1);
            }
        }

        private void HandleDragging(int itemIndex)
        {
            InventoryItem inventoryItem = _inventoryData.GetItemAt(itemIndex);
            if (inventoryItem.IsEmpty) return;
            _inventoryUI.CreateDraggedItem(inventoryItem.item.WeaponSprite, inventoryItem.quantity);

        }

        private void HandleSwapItems(int itemIndex1, int itemIndex2)
        {
            _inventoryData.SwapItems(itemIndex1,itemIndex2);
        }

        private void HandleDescriptionRequest(int itemIndex)
        {
            InventoryItem inventoryItem = _inventoryData.GetItemAt(itemIndex);
            if (inventoryItem.IsEmpty || inventoryItem.item == null)
            {
                _inventoryUI.ResetSelection();
                return;
            }
            ItemTemplate item = inventoryItem.item;
            _inventoryUI.UpdateDescription(itemIndex, item.WeaponSprite, item.name, item.Description);
        }

        private void Update()
        {
            //Cambiar a NewInputSystem
            if (Input.GetKeyUp(KeyCode.E))
            {
                if (_inventoryUI.isActiveAndEnabled == false)
                {
                    _inventoryUI.Show();
                    foreach (var item in _inventoryData.GetCurrentInventoryState())
                    {
                        _inventoryUI.UpdateData(item.Key, item.Value.item.WeaponSprite, item.Value.quantity);
                    }
                }
                else
                {
                    _inventoryUI.Hide();
                }
            }
        }
    }
}

