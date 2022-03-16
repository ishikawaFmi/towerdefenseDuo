using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager Incetance;

    public List<Stage> StageList = new List<Stage>();
    void Awake()
    {
        if (Incetance == null)
        {
            Incetance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Start()
    {
        Stage[] stages = Resources.LoadAll<Stage>("StageData");

        foreach (var stage in stages)
        {
            StageList.Add(stage);
        }
    }

}
