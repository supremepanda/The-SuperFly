using UnityEngine;
using SceneManager = UnityEngine.SceneManagement.SceneManager;
using TMP_Text = TMPro.TMP_Text;

public class LoadingManager : MonoBehaviour
{
    private const string START_SCENE_STORY = "Castle in the Sky (Laputa)" +
        " lost own power cell, it was stolen! The castle is in danger of falling. " +
        "You need to find the stolen power cell to save the castle." +
        " If you are ready, Let's Start!";

    private const string MENU_STORY = "See you again in Laputa!";

    private const string LEVEL_1_STORY = "We found traces of the stolen power cell," +
        " but there are some obstacles on the way. To find the sphere, you have to go" +
        " through all the obstacles and find the teleport portal. ";

    private const string LEVEL_2_STORY = "They found us! You need to survive for 60 seconds under fire!" +
        " We should be very close to power cell, be careful skychild...";

    private const string LEVEL_3_STORY = "We found the power cell. But I guess we'll have to fight for it." +
        " The castle should be destroyed! But be careful about the colors. Choose your plane color wisely. (Press 'Space' to fire!)";

    // Initializing saiting time to load level
    [SerializeField] private float _waitTime;

    // Initializing target level.
    private string _targetLevel;

    // Initializing play button.
    [SerializeField] private GameObject _playButton;

    // Initializing story text.
    [SerializeField] private TMP_Text _storyText;

    private void Start()
    {
        // Setting cursor visible.
        Cursor.visible = true;

        // Getting stored target level with using PlayerPrefs.
        _targetLevel = PlayerPrefs.GetString("TARGET_LEVEL");

        // Setting active scene to use in target scene.
        PlayerPrefs.SetString("ACTIVE_SCENE", _targetLevel);

        Debug.Log(_targetLevel);

        // Setting story texts for each level.
        switch (_targetLevel)
        {
            case "StartScene":
                _storyText.text = START_SCENE_STORY;
                break;
            case "Menu":
                _storyText.text = MENU_STORY;
                break;
            case "Level1":
                _storyText.text = LEVEL_1_STORY;
                break;
            case "Level2":
                _storyText.text = LEVEL_2_STORY;
                break;
            case "Level3":
                _storyText.text = LEVEL_3_STORY;
                break;
            default:
                break;      
        }
    }

    private void Update()
    {
        // Wait time updating with deltatime.
        if(_waitTime > 0) { _waitTime -= Time.deltaTime; }

        // Activating play button
        else { _playButton.SetActive(true); }
    }

    /// <summary>
    /// It is button function to load target level.
    /// </summary>
    public void OnClickPlay()
    {
        // Loading target level.
        SceneManager.LoadScene(_targetLevel);
    }
}
