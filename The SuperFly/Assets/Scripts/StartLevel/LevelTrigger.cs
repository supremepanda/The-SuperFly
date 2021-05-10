using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SceneManager = UnityEngine.SceneManagement.SceneManager;

public class LevelTrigger : MonoBehaviour
{
    [SerializeField] private string _levelName;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") 
        {
            PlayerPrefs.SetString("TARGET_LEVEL", _levelName);
            SceneManager.LoadScene("Loading");
        }
    }
}
