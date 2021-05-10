using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMP_Text = TMPro.TMP_Text;

public class EscapeMenu : MonoBehaviour
{
    // Constant scene name of Start scene.
    private const string START_SCENE = "Laputa";

    private const string LEVEL_1 = "Colors in the Sky";
    private const string LEVEL_2 = "Under Fire!";
    private const string LEVEL_3 = "Fight for the Power Cell!";

    private AudioSource _audio;
    [SerializeField] private AudioClip _buttonHit;

    // Initializing current scene text variable.
    [SerializeField] private TMP_Text _currentSceneText;

    // Initializing escape panel variable.
    [SerializeField] private GameObject _panelEscape;

    // Initializing current scene string variable.
    private string _currentScene;

    // Initializing hud controller variable.
    [SerializeField] private LevelHUD _hudController;

    private void Start()
    {
        _audio = GameObject.Find("AudioManager").GetComponent<AudioSource>();

        // Getting current scene from player prefs.
        _currentScene = PlayerPrefs.GetString("ACTIVE_SCENE");

        // Changing current scene text according to active scene.
        switch (_currentScene)
        {
            case "StartScene":
                _currentSceneText.text = string.Format("Current scene: {0}", START_SCENE);
                break;
            case "Level1":
                _currentSceneText.text = string.Format("Current scene: {0}", LEVEL_1);
                break;
            case "Level2":
                _currentSceneText.text = string.Format("Current scene: {0}", LEVEL_2);
                break;
            case "Level3":
                _currentSceneText.text = string.Format("Current scene: {0}", LEVEL_3);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// It is button function to return the game.
    /// </summary>
    public void OnClickPlay()
    {
        _audio.PlayOneShot(_buttonHit, 1f);
        _hudController.SetPanelIsActive(false);
        _hudController.SetActivePlaneMouseHUD();
        Cursor.visible = false;
        Time.timeScale = 1;
        _panelEscape.SetActive(false);
    }

    /// <summary>
    /// It is button function to go back to menu scene.
    /// </summary>
    public void OnClickExit()
    {
        _audio.PlayOneShot(_buttonHit, 1f);
        Time.timeScale = 1;
        Cursor.visible = false;
        PlayerPrefs.SetString("TARGET_LEVEL", "StartScene");
        SceneManager.LoadScene("Loading");
    }

    public void OnClickExitToMenu()
    {
        _audio.PlayOneShot(_buttonHit, 1f);
        Time.timeScale = 1;
        Cursor.visible = true;
        PlayerPrefs.SetString("TARGET_LEVEL", "Menu");
        SceneManager.LoadScene("Loading");
    }
}
