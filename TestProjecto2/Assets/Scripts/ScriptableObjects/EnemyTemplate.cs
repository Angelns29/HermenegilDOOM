using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemyTemplate : ScriptableObject
{
    public new string name;

    //True para el que persigue, false para el que dispara

    public float health;
    public float damage;
    //Da o no un arma.
    public bool drops;

}

