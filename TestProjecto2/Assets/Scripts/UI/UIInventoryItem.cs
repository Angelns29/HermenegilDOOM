using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Inventory.UI
{
    public class UIInventoryItem : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IEndDragHandler, IDropHandler, IDragHandler
    {
        [SerializeField] private Image _itemImage;
        [SerializeField] private TMP_Text _quantityText;
        [SerializeField] private Image _borderImage;

        public event Action<UIInventoryItem> OnItemClicked, OnItemDroppedOn, OnItemBeginDrag, OnItemEndDrag, OnRightMouseBtnClick;

        private bool _empty = true;

        private void Awake()
        {
            ResetData();
            Deselect();
        }
        public void ResetData()
        {
            this._itemImage.gameObject.SetActive(false);
            _empty = true;
        }
        public void Deselect()
        {
            _borderImage.enabled = false;
        }
        public void SetData(Sprite sprite, int quantity)
        {
            this._itemImage.gameObject.SetActive(true);
            this._itemImage.sprite = sprite;
            this._quantityText.text = quantity.ToString();
            _empty = false;
        }
        public void Select()
        {
            _borderImage.enabled = true;
        }


        public void OnPointerClick(PointerEventData pointerData)
        {
            if (pointerData.button == PointerEventData.InputButton.Right)
            {
                OnRightMouseBtnClick?.Invoke(this);
            }
            else
            {
                OnItemClicked?.Invoke(this);
            }
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (_empty) return;
            OnItemBeginDrag?.Invoke(this);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            OnItemEndDrag?.Invoke(this);
        }

        public void OnDrop(PointerEventData eventData)
        {
            OnItemDroppedOn?.Invoke(this);
        }

        public void OnDrag(PointerEventData eventData)
        {

        }
    }
}
