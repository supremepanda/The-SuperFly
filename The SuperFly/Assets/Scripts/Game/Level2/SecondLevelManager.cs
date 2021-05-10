using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMP_Text = TMPro.TMP_Text;

public class SecondLevelManager : MonoBehaviour
{
    // Boolean to check is game running or not.
    public static bool isGameRunning = false;

    // Limited game time.
    [SerializeField] private float _gameTime;

    // Game time UI
    [SerializeField] private TMP_Text _timeText;

    [SerializeField] private LevelHUD _hudController;

    private int _health = 5;
    [SerializeField] private TMP_Text _healthText;

    public void DecreaseHealth()
    {
        _health--;
        _healthText.text = string.Format("Remaining Health: {0}", _health.ToString());
        CheckHealth();
    }

    private void CheckHealth()
    {
        if(_health <= 0)
        {
            GameOver(false);
        }
    }
    private void GameOver(bool win)
    {
        Debug.Log("Game Over");
        isGameRunning = false;
        if (win)
        {
            _hudController.Win();
            PlayerPrefs.SetInt("SUCCEED_LEVEL2", 1);
        }
        else
        {
            _hudController.Lose();
        }
    }

    private void Start()
    {
        isGameRunning = true;
        _timeText.text = _gameTime.ToString();
        _healthText.text = string.Format("Remaining Health: {0}", _health.ToString());
    }

    private void Update()
    {
        if (isGameRunning)
        {
            if (_gameTime > 0)
            {
                _gameTime -= Time.deltaTime;
                _timeText.text = string.Format("Remaining time: {0:0}", _gameTime);
            }
            else { GameOver(true); }
        }

    }
}
