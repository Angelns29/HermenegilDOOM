using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class WeaponTemplate : ScriptableObject
{
    public new string name;

    public float weaponDamage;
    //Determina que bala dispara esa arma, de esta manera controlaremos lo que hace cada una.
    public string bulletType;
}

