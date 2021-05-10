using UnityEngine;
using UnityEngine.SceneManagement;
using TMP_Text = TMPro.TMP_Text;

public class LevelHUD : MonoBehaviour
{
    private const string LEVEL_1 = "Colors in the Sky";
    private const string LEVEL_2 = "Under Fire!";
    private const string LEVEL_3 = "Fight for the Power Cell!";

    private AudioSource _audio;
    private AudioSource _planeAudio;

    [SerializeField] private AudioClip _buttonHit;
    [SerializeField] private AudioClip _win;
    [SerializeField] private AudioClip _lose;

    // Initializing 3D text of left pipe.
    [SerializeField] private TextMesh _textLeftPipe;

    // Initializing 3D text of right pipe
    [SerializeField] private TextMesh _textRightPipe;

    [SerializeField] private bool _isStartScene = false;

    // Counting value of left pipe.
    private int _countLeftPipe = 0;

    // Counting value of right pipe.
    private int _countRightPipe = 0;

    // Initializing escape panel.
    [SerializeField] private GameObject _panelEscape;

    // Boolean to control escape panel is active or not.
    private bool _panelIsActive = false;

    // Plane mouse HUD to change normal cursor or this.
    [SerializeField] private GameObject _planeMouseHUD;

    #region Game Ending

    [SerializeField] private GameObject _endGamePanel;
    [SerializeField] private TMP_Text _endGameTitle;
    [SerializeField] private TMP_Text _endGameMainText;

    [SerializeField] private GameObject _retryButton;
    [SerializeField] private GameObject _exitButton;
    [SerializeField] private GameObject _gameDoneExitButton;

    private string _currentLevel;

    #endregion

    public void SetActivePlaneMouseHUD()
    {
        _planeMouseHUD.SetActive(true);
    }

    /// <summary>
    /// Setter of panel is active boolean.
    /// </summary>
    /// <param name="value">boolean</param>
    public void SetPanelIsActive(bool value)
    {
        _panelIsActive = value;
    }

    private void Start()
    {
        _audio = GameObject.Find("AudioManager").GetComponent<AudioSource>();
        _planeAudio = GameObject.Find("Player").transform.GetChild(0).gameObject.GetComponent<AudioSource>();

        _currentLevel = PlayerPrefs.GetString("ACTIVE_SCENE");

        Cursor.visible = false;
        if (_isStartScene)
        {
            // Giving default values to text of left pipe.
            _textLeftPipe.text = "Count: " + _countLeftPipe;

            // Giving default values to text of right pipe.
            _textRightPipe.text = "Count: " + _countRightPipe;
        }      
    }

    private void Update()
    {
        switch (_currentLevel)
        {
            case "StartScene":
                if (StartSceneManager.isGameRunning)
                {
                    // Escape panel menu opening.
                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        // Panel handling.
                        if (_panelIsActive)
                        {
                            // Booelan of escape panel is false.
                            SetPanelIsActive(false);

                            // Time Scale to start game time.
                            Time.timeScale = 1;

                            // De-activating the escape panel.
                            _panelEscape.SetActive(false);

                            // Activating plane mouse HUDs.
                            _planeMouseHUD.SetActive(true);
                        }
                        else
                        {
                            // Booelan of escape panel is false. 
                            SetPanelIsActive(true);

                            // Time Scale to stop game time.
                            Time.timeScale = 0;

                            // Activating the escape panel.
                            _panelEscape.SetActive(true);

                            // De-activating plane mouse HUDs.
                            _planeMouseHUD.SetActive(false);
                        }
                    }
                }
                break;
            case "Level1":
                if (FirstLevelManager.isGameRunning)
                {
                    // Escape panel menu opening.
                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        // Panel handling.
                        if (_panelIsActive)
                        {
                            // Booelan of escape panel is false.
                            SetPanelIsActive(false);

                            // Time Scale to start game time.
                            Time.timeScale = 1;

                            // De-activating the escape panel.
                            _panelEscape.SetActive(false);

                            // Activating plane mouse HUDs.
                            _planeMouseHUD.SetActive(true);
                        }
                        else
                        {
                            // Booelan of escape panel is false. 
                            SetPanelIsActive(true);

                            // Time Scale to stop game time.
                            Time.timeScale = 0;

                            // Activating the escape panel.
                            _panelEscape.SetActive(true);

                            // De-activating plane mouse HUDs.
                            _planeMouseHUD.SetActive(false);
                        }
                    }
                }
                break;
            case "Level2":
                if (SecondLevelManager.isGameRunning)
                {
                    // Escape panel menu opening.
                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        // Panel handling.
                        if (_panelIsActive)
                        {
                            // Booelan of escape panel is false.
                            SetPanelIsActive(false);

                            // Time Scale to start game time.
                            Time.timeScale = 1;

                            // De-activating the escape panel.
                            _panelEscape.SetActive(false);

                            // Activating plane mouse HUDs.
                            _planeMouseHUD.SetActive(true);
                        }
                        else
                        {
                            // Booelan of escape panel is false. 
                            SetPanelIsActive(true);

                            // Time Scale to stop game time.
                            Time.timeScale = 0;

                            // Activating the escape panel.
                            _panelEscape.SetActive(true);

                            // De-activating plane mouse HUDs.
                            _planeMouseHUD.SetActive(false);
                        }
                    }
                }
                break;
            case "Level3":
                if (ThirdLevelManager.isGameRunning)
                {
                    // Escape panel menu opening.
                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        // Panel handling.
                        if (_panelIsActive)
                        {
                            // Booelan of escape panel is false.
                            SetPanelIsActive(false);

                            // Time Scale to start game time.
                            Time.timeScale = 1;

                            // De-activating the escape panel.
                            _panelEscape.SetActive(false);

                            // Activating plane mouse HUDs.
                            _planeMouseHUD.SetActive(true);
                        }
                        else
                        {
                            // Booelan of escape panel is false. 
                            SetPanelIsActive(true);

                            // Time Scale to stop game time.
                            Time.timeScale = 0;

                            // Activating the escape panel.
                            _panelEscape.SetActive(true);

                            // De-activating plane mouse HUDs.
                            _planeMouseHUD.SetActive(false);
                        }
                    }
                }
                break;
        }
    }

    /// <summary>
    /// It increases counting value of left pipe.
    /// </summary>
    public void IncreaseCountLeftPipe()
    {   
        // Increasing counting value.
        _countLeftPipe++;

        // Changing text.
        _textLeftPipe.text = "Count: " + _countLeftPipe.ToString();
    }

    /// <summary>
    /// It increases counting value of right pipe.
    /// </summary>
    public void IncreaseCountRightPipe()
    {
        // Increasing counting value.
        _countRightPipe++;

        // Changing text.
        _textRightPipe.text = "Count: " + _countRightPipe.ToString();
    }

    public void Win()
    {
        _audio.Stop();
        _planeAudio.Stop();
        _audio.PlayOneShot(_win, 1f);
        Cursor.visible = true;

        _planeMouseHUD.SetActive(false);
        Time.timeScale = 0;

        string levelName = GetLevelName(true);

        _exitButton.SetActive(false);
        _retryButton.SetActive(false);
        _gameDoneExitButton.SetActive(true);

        _endGameTitle.text = "Congratulations!";
        _endGameTitle.gameObject.SetActive(true);

        _endGameMainText.text = string.Format("{0} completed!", levelName);
        _endGameMainText.gameObject.SetActive(true);

        _endGamePanel.SetActive(true);
    }

    public void Lose()
    {
        _audio.Stop();
        _planeAudio.Stop();
        _audio.PlayOneShot(_lose, 1f);
        Cursor.visible = true;

        _planeMouseHUD.SetActive(false);
        Time.timeScale = 0;

        string levelName = GetLevelName(false);

        _gameDoneExitButton.SetActive(false);
        _retryButton.SetActive(true);
        _exitButton.SetActive(true);

        _endGameTitle.text = "Level Failed!";
        _endGameTitle.gameObject.SetActive(true);

        _endGameMainText.text = string.Format("{0} failed!", levelName);
        _endGameMainText.gameObject.SetActive(true);

        _endGamePanel.SetActive(true);
    }

    private string GetLevelName(bool win)
    {
        if (win)
        {
            PlayerPrefs.SetInt(_currentLevel, 1);
        }

        string levelName = "";

        switch (_currentLevel)
        {
            case "Level1":
                levelName = LEVEL_1;
                break;
            case "Level2":
                levelName = LEVEL_2;
                break;
            case "Level3":
                levelName = LEVEL_3;
                break;
            default:
                break;
        }

        return levelName;
    }

    public void OnClickRetry()
    {
        _audio.PlayOneShot(_buttonHit, 1f);
        PlayerPrefs.SetString("TARGET_LEVEL", _currentLevel);
        SceneManager.LoadScene("Loading");
        Time.timeScale = 1;
    }

    public void OnClickExit()
    {
        _audio.PlayOneShot(_buttonHit, 1f);
        PlayerPrefs.SetString("TARGET_LEVEL", "StartScene");
        SceneManager.LoadScene("Loading");
        Time.timeScale = 1;
    }
}
