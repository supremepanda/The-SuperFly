using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMP_Text = TMPro.TMP_Text;

public class FirstLevelManager : MonoBehaviour
{
    // Boolean to check is game running or not.
    public static bool isGameRunning = false;

    // Limited game time.
    [SerializeField] private float _gameTime;

    // Game time UI
    [SerializeField] private TMP_Text _timeText;

    [SerializeField] private LevelHUD _hudController;

    #region Pipe
    // Constant total pipe amount.
    private const int TOTAL_PIPES = 19;

    // Remaining pipe amount.
    private int _remainingPipes;

    // Pipes parent object.
    private GameObject _pipes;

    // Remaining pipes UI
    [SerializeField] private TMP_Text _remainingPipeText;

    // Just point
    private int _point = 0;
    [SerializeField] private TMP_Text _pointText;

    /// <summary>
    /// If player go throgh a pipe, it will decrase the remaining pipes value.
    /// </summary>
    public void DecreaseRemainingPipe()
    {
        _remainingPipes--;
        _remainingPipeText.text = "Remaining Pipes: " + _remainingPipes.ToString();

        _point += 100;
        _pointText.text = _point.ToString();
        if (CheckGameConditionDone()) { GameOver(true); }
    }

    /// <summary>
    /// Every decreasing remaining pipe values, checking the game is done or not.
    /// </summary>
    /// <returns></returns>
    private bool CheckGameConditionDone()
    {
        if (_remainingPipes == 0) { return true; }
        else { return false; }
    }

    /// <summary>
    /// Preparing the every pipes to set different colors.
    /// </summary>
    private void PreparePipes()
    {
        // Getting pipes parent object.
        _pipes = GameObject.Find("Pipes");

        // For every child object of pipes:
        for (int i = 0; i < _pipes.transform.childCount; i++)
        {
            // Setting random color.
            Color randomColor = new Color(
                       Random.Range(0f, 1f),
                       Random.Range(0f, 1f),
                       Random.Range(0f, 1f),
                       0.117f);

            // Setting random color to material of pipe.
            _pipes.transform.GetChild(i).transform.GetChild(0).GetComponent<MeshRenderer>().material.color = randomColor;
        }

    }

    #endregion

    private void GameOver(bool win)
    {
        Debug.Log("Game Over");
        isGameRunning = false;
        if (win)
        {
            _hudController.Win();
            PlayerPrefs.SetInt("SUCCEED_LEVEL1", 1);
        }
        else
        {
            _hudController.Lose();
        }
    }

    private void Start()
    {
        PreparePipes();

        isGameRunning = true;
        _remainingPipes = TOTAL_PIPES;
        _timeText.text = _gameTime.ToString();
        _remainingPipeText.text = "Remaining Pipes: " + _remainingPipes.ToString();
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
            else { GameOver(false); }
        }

    }

}
