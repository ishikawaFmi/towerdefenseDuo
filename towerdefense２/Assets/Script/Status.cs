using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName ="ScriptableObject/StatuData")]
public class Status : ScriptableObject
{
    public string CharacterName;

    public int CharacterId;

    public int AttackDamage;

    public float AttackSpeed = 1.0f;

    public int Cost;
}
