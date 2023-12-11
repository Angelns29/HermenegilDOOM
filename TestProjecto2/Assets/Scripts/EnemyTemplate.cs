using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Char", menuName = "Char")]
public class CharTemplate : ScriptableObject
{
    public new string name;

    public Sprite charSprite;

    //True para el que persigue, false para el que dispara
    public bool charType;
    public float health;
    public float damage;
    //Da o no un arma.
    public bool drops;

}

