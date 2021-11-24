using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public ScoreCounter m_score;
    public Score_Data m_data;
    public int CurrentHigh;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        CurrentHigh = m_data.HighScore;
    }

    private void Update()
    {
        if (m_data.HighScore < CurrentHigh)
        {
            m_data.HighScore = CurrentHigh;
        }
    }
}
