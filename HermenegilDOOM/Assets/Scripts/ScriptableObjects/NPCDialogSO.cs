using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(menuName = "DialogsSO")]
public class NPCDialogSO : ScriptableObject
{
    [field: SerializeField] public Sprite NPCSprite { get; set; }
    [field: SerializeField] public string NPCName { get; set; }
    [field: SerializeField] public string[] Dialogs { get; set; }
}
