using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isGameRunning = false;

    private float _lifeTime;
    private const float MAX_LIFE_TIME = 10f;

    private float[] _pointstoNextLevel = { 100, 300, 600, 1000 };
    private int _level = 1;

    public void AddLifeTime(float timeValue)
    {
        _lifeTime += _lifeTime;
    }

    private void Start()
    {
        _lifeTime = MAX_LIFE_TIME;
        isGameRunning = true;
    }

    private void Update()
    {
        if (isGameRunning)
        {
            if(_lifeTime > 0) { _lifeTime -= Time.deltaTime; }
            else
            {
                GameOver();
            }
        }
    }

    private void GameOver()
    {

    }
}
