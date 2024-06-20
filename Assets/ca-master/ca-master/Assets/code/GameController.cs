using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject enemy;

    public float spawnTime;

    float m_spawnTime;

    int m_score;

    bool m_isGameover;

    // Start is called before the first frame update
    void Start()
    {
        m_spawnTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        m_spawnTime -= Time.deltaTime;

        if (m_spawnTime <= 0)
        {
            spawnEnemy();

            m_spawnTime = spawnTime;
        }
    }

    public void spawnEnemy()
    {
        float randXpos = Random.Range(-7f, 7f);

        Vector2 spawnPos = new Vector2(randXpos, 7);

        if (enemy)
        {
            Instantiate(enemy, spawnPos, Quaternion.identity);
        }
    }

    public void SetScore(int value)
    {
        m_score = value;
    }

    public int GetScore()
    { 
        return m_score; 
    }

    public void ScoreIncrement()
    {
        m_score++;
    }

    public void SetGameoverState(bool state)
    {
        m_isGameover = state;
    }

    public bool IsGameover()
    {
        return m_isGameover;
    }    
}
