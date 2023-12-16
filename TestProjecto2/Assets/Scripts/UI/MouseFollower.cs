using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollower : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Camera _camera;
    [SerializeField] private UIInventoryItem _item;

    private void Awake()
    {
        _canvas = transform.root.GetComponent<Canvas>();
        _camera = Camera.main;
        _item = GetComponentInChildren<UIInventoryItem>();
    }
    public void SetData(Sprite sprite, int quantity)
    {
        _item.SetData(sprite, quantity);
    }
    private void Update()
    {
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)_canvas.transform,Input.mousePosition,_canvas.worldCamera,out position);
        transform.position = _canvas.transform.TransformPoint(position);

    }
    public void Toggle(bool val)
    {
        gameObject.SetActive(val);
    }
}
