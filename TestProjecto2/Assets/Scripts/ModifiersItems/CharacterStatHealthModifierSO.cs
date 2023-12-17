using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterStatHealthModifierSO : CharacterStatsModifierSO
{
    public override void AffectCharacter(GameObject character, float val)
    {
        Heath heath = character.GetComponent<Heath>();
        if (heath != null)heath.AddHealth((int)val);
    }
}
