using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneManager : MonoBehaviour
{
    public static bool isGameRunning = true;

    private int _isLevel1Succeed;
    private int _isLevel2Succeed;
    private int _isLevel3Succeed;

    [SerializeField] private MeshCollider _level2Collider;
    [SerializeField] private MeshCollider _level3Collider;

    [SerializeField] private GameObject _textLevel2Locked;
    [SerializeField] private GameObject _textLevel3Locked;

    [SerializeField] private GameObject _castle;
    [SerializeField] private GameObject _powercell;

    private void Start()
    {   // Resetting the game
        //PlayerPrefs.DeleteAll();

        _isLevel1Succeed = PlayerPrefs.GetInt("SUCCEED_LEVEL1");
        _isLevel2Succeed = PlayerPrefs.GetInt("SUCCEED_LEVEL2");
        _isLevel3Succeed = PlayerPrefs.GetInt("SUCCEED_LEVEL3");

        if (_isLevel1Succeed == 1) 
        {
            _level2Collider.isTrigger = true;
            _textLevel2Locked.SetActive(false);
        }
        if (_isLevel2Succeed == 1) 
        {
            _level3Collider.isTrigger = true;
            _textLevel3Locked.SetActive(false);
        }
        if(_isLevel3Succeed == 1) 
        {
            _castle.transform.rotation = new Quaternion(0, 0, 0, 0);
            _powercell.SetActive(true);
        }
    }
}
