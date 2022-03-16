using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "ScriptableObject/StatuData")]
public class Stage : ScriptableObject
{
    public string StageId;

    public string StageName;

    public int ScoreStandardValue;
}