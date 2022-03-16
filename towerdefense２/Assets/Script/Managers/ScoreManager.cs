using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    static public ScoreManager Incetance;

    public Score ScoreStruct;

    void Awake()
    {
        if (Incetance == null)
        {
            Incetance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public struct Score
    {
        private int ScorePoint;

        public int ScoreStandardValue;

        public Score(int scoreStandardValue)
        {
            this.ScorePoint = 0;

            this.ScoreStandardValue = scoreStandardValue;
        }

        public int GetScore() => ScorePoint;
      
    }
}
