using Inventory.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [field: SerializeField] public ItemTemplate InventoryItem { get; private set; }

    [field: SerializeField] public int Quantity { get; set; }

    //[SerializeField] private AudioSource audioSource;
    [SerializeField] private float _duration = 0.3f;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = InventoryItem.WeaponSprite;
    }
    public void DestroyItem()
    {
        GetComponent<Collider2D>().enabled = false;
        StartCoroutine(AnimateItemPickup());
    }

    private IEnumerator AnimateItemPickup()
    {
        //audioSource.PlaySFX();
        Vector3 startScale = transform.localScale;
        Vector3 endScale = Vector3.zero;
        float currentTime = 0;
        while (currentTime < _duration)
        {
            currentTime += Time.deltaTime;
            transform.localScale = Vector3.Lerp(startScale, endScale, currentTime/_duration);
            yield return null;
        }
        Destroy(gameObject);
    }
}
