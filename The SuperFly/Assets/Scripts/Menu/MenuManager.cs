using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private AudioSource _audio;
    [SerializeField] private AudioClip _buttonHit;

    private void Start()
    {
        _audio = GameObject.Find("AudioManager").GetComponent<AudioSource>();
        // Setting cursor visible.
        Cursor.visible = true;
    }

    /// <summary>
    /// It is button function to load StartScene.
    /// </summary>
    public void OnClickPlay()
    {
        _audio.PlayOneShot(_buttonHit, 1f);
        // Setting target level to open in Loading scene.
        PlayerPrefs.SetString("TARGET_LEVEL", "StartScene");

        // Loading Loading scene.
        SceneManager.LoadScene("Loading");
    }

    /// <summary>
    /// It is button function to quit game.
    /// </summary>
    public void OnClickExit()
    {
        _audio.PlayOneShot(_buttonHit, 1f);
        // Quitting the game.
        Application.Quit();
    }
}
