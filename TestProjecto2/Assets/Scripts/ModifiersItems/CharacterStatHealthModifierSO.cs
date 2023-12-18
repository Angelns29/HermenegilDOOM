using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterStatHealthModifierSO : CharacterStatsModifierSO
{
    public override void AffectCharacter(GameObject character, float val)
    {
        Health heath = character.GetComponent<Health>();
        if (heath != null)heath.AddHealth((int)val);
    }
}
