using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private UIInventoryPage _inventoryUI;

    public int inventorySize = 10;
    private void Start()
    {
        _inventoryUI.InitializeInventoryUI(inventorySize);
    }
    private void Update()
    {
        //Cambiar a NewInputSystem
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (_inventoryUI.isActiveAndEnabled == false)
            {
                _inventoryUI.Show();
            }
            else
            {
                _inventoryUI.Hide();
            }
        }
    }



}
