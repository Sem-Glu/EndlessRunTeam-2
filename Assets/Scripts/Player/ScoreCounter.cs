using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private Transform m_transform;
    public float Score;
    public float MaxScore;

    private void Start()
    {
        m_transform = GetComponent<Transform>();
    }

    private void Update()
    {
        Score = m_transform.position.x;
        if (Score > MaxScore)
        {
        MaxScore = Mathf.RoundToInt(Score);
        }
    }

}
