using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public ScoreCounter m_score;
    public ScoreData m_data;
    public int CurrentHigh;

    [SerializeField] private TextMeshProUGUI m_scoretext;
    [SerializeField] private TextMeshProUGUI m_highscoretext;

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
        m_highscoretext.text = "HighScore :" + CurrentHigh.ToString();
        m_scoretext.text = "Score :" + m_score.MaxScore.ToString();
    }

    private void Update()
    {
        if (m_data.HighScore < CurrentHigh)
        {
            m_data.HighScore = CurrentHigh;
            m_highscoretext.text = "HighScore :" + CurrentHigh.ToString();
            m_scoretext.text = "Score :" + m_score.MaxScore.ToString();
        }

        if (m_score.MaxScore > CurrentHigh)
        {
            CurrentHigh = m_score.MaxScore;
            m_highscoretext.text = "HighScore :" + CurrentHigh.ToString();
            m_scoretext.text = "Score :" + m_score.MaxScore.ToString();
        }
    }
}
