using Inventory.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponRandom : MonoBehaviour
{
    //Lista de las Armas
    [field: DoNotSerialize] public ItemTemplate InventoryItem { get; private set; }

    [field: SerializeField] public int Quantity { get; set; }

    [SerializeField] private AudioManager _audioSource;
    [SerializeField] private float _duration = 0.3f;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = InventoryItem.WeaponSprite;
        _audioSource = AudioManager.instance;
    }
    public void DestroyItem()
    {
        GetComponent<Collider2D>().enabled = false;
        StartCoroutine(AnimateItemPickup());
    }

    private IEnumerator AnimateItemPickup()
    {
        _audioSource.PlaySFX(_audioSource.collectItems);
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
