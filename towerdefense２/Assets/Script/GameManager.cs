using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Incetance;

    public Subject<Unit> GameStartSubject = new Subject<Unit>();

    public Subject<Unit> FightPreparationSubject = new Subject<Unit>();

    public Subject<Unit> NewWaveSubject = new Subject<Unit>();

    public Subject<Unit> GameEndSubject = new Subject<Unit>();

    public Stage CurrentStage;

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
        ScoreManager.Incetance.ScoreStruct = new ScoreManager.Score(CurrentStage.ScoreStandardValue);
    }

  
}
