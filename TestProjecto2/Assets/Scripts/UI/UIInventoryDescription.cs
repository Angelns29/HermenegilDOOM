using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryDescription : MonoBehaviour
{
    [SerializeField] private Image _itemImage;
    [SerializeField] private TMP_Text _title;
    [SerializeField] private TMP_Text _description;

    private void Awake()
    {
        ResetDescription();
    }

    public void ResetDescription()
    {
        this._itemImage.gameObject.SetActive(false);
        this._title.text = "";
        this._description.text = "";
    }
    public void Setdescription(Sprite sprite, string itemName, string itemDescription)
    {
        this._itemImage.gameObject.SetActive(true);
        this._description.text = itemDescription;
        this._itemImage.sprite = sprite;
        this._title.text = itemName;
    }
}
