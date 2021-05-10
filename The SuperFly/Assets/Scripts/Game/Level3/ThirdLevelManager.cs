using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMP_Text = TMPro.TMP_Text;

public class ThirdLevelManager : MonoBehaviour
{
    [SerializeField] private GameObject _powerCell;
    [SerializeField] private LevelHUD _hudController;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            _canCastleGetDamage = true;
        }
    }

    #region Audio
    private AudioSource _audio;
    [SerializeField] private AudioClip _hitFx;
    [SerializeField] private AudioClip _explosionFx;

    public void PlayHitFx()
    {
        _audio.PlayOneShot(_hitFx, 1f);
    }

    public void PlayExplosionFx()
    {
        _audio.PlayOneShot(_explosionFx, 1f);
    }

    #endregion
    public static bool isGameRunning = true;

    #region Health

    private int _health = 5;
    [SerializeField] private TMP_Text _healthText;

    private void CheckHealth()
    {
        if(_health <= 0)
        {
            GameOver(false);
        }
    } 

    public void DecreaseHealthAmount()
    {
        _health--;
        if(_health < 0) { _health = 0; }
        _healthText.text = string.Format("Remaining Health: {0}", _health.ToString());
        CheckHealth();
    }

    public void IncreaseHealthAmount()
    {
        _health++;
        if(_health > 5) { _health = 5; }
        _healthText.text = string.Format("Remaining Health: {0}", _health.ToString());
    }

    #endregion

    #region EnemyCastle

    private bool _canCastleGetDamage = false;

    public bool GetCanCastleGetDamage()
    {
        return _canCastleGetDamage;
    }

    private int _destroyedTargetAmount = 0;

    private void CheckDestroyedTargetAmounts()
    {
        Debug.Log(_destroyedTargetAmount);
        if(_destroyedTargetAmount >= 4) { _canCastleGetDamage = true; }
    }

    [SerializeField] private GameObject _pinkTargetUI;
    [SerializeField] private GameObject _purpleTargetUI;
    [SerializeField] private GameObject _redTargetUI;
    [SerializeField] private GameObject _yellowTargetUI;
    [SerializeField] private GameObject _castleTargetUI;

    private GameObject[] _targets = new GameObject[5];
    private Healthbar _defaultHealthbar;
    
    private void SetDefaultHealthbar(int index)
    {
        if(index == -1)
        {
            for(int i = 0; i < _targets.Length; i++)
            {
                _targets[i].SetActive(false);
                _defaultHealthbar = null;
            }
        }
        for(int i = 0; i < _targets.Length; i++)
        {
            if(i == index) 
            {
                _targets[i].SetActive(true);
                _defaultHealthbar = _targets[i].transform.GetChild(0).gameObject.GetComponent<Healthbar>();
            }
            else { _targets[i].SetActive(false); }
        }
    }

    private Healthbar _pinkTargetHealthbar;
    private Healthbar _purpleTargetHealthbar;
    private Healthbar _redTargetHealthbar;
    private Healthbar _yellowTargetHealthbar;
    private Healthbar _castleTargetHealthbar;

    [SerializeField] private GameObject _pinkTarget;
    [SerializeField] private GameObject _pinkPlane;

    [SerializeField] private GameObject _purpleTarget;
    [SerializeField] private GameObject _purplePlane;

    [SerializeField] private GameObject _redTarget;
    [SerializeField] private GameObject _redPlane;
    
    [SerializeField] private GameObject _yellowTarget;
    [SerializeField] private GameObject _yellowPlane;

    [SerializeField] private GameObject _castleTarget;

    private int _pinkTargetHealth = 10;
    private int _purpleTargetHealth = 10;
    private int _redTargetHealth = 10;
    private int _yellowTargetHealth = 10;
    private int _castleHealth = 50;

    public void DecreaseCastleHealth(string target)
    {
        Debug.Log(target);

        switch (target)
        {
            case "pink":
                _pinkTargetHealth--;
                SetDefaultHealthbar(0);
                _defaultHealthbar.TakeDamage(1);
                if (_pinkTargetHealth <= 0) 
                { 
                    DestroyEnemyObject(_pinkTarget, _pinkPlane);
                    PlayExplosionFx();
                    _destroyedTargetAmount++;
                    CheckDestroyedTargetAmounts();
                }
                break;
            case "purple":
                _purpleTargetHealth--;
                SetDefaultHealthbar(1);
                _defaultHealthbar.TakeDamage(1);
                if (_purpleTargetHealth <= 0) 
                { 
                    DestroyEnemyObject(_purpleTarget, _purplePlane); 
                    PlayExplosionFx();
                    _destroyedTargetAmount++;
                    CheckDestroyedTargetAmounts();
                }
                break;
            case "red":
                _redTargetHealth--;
                SetDefaultHealthbar(2);
                _defaultHealthbar.TakeDamage(1);
                if (_redTargetHealth <= 0) 
                { 
                    DestroyEnemyObject(_redTarget, _redPlane); 
                    PlayExplosionFx();
                    _destroyedTargetAmount++;
                    CheckDestroyedTargetAmounts();
                }
                break;
            case "yellow":
                _yellowTargetHealth--;
                SetDefaultHealthbar(3);
                _defaultHealthbar.TakeDamage(1);
                if (_yellowTargetHealth <= 0) 
                { 
                    DestroyEnemyObject(_yellowTarget, _yellowPlane); 
                    PlayExplosionFx();
                    _destroyedTargetAmount++;
                    CheckDestroyedTargetAmounts();
                }
                break;
            case "castle":
                _castleHealth--;
                SetDefaultHealthbar(4);
                _defaultHealthbar.TakeDamage(1);
                if (_castleHealth <= 0) 
                { 
                    DestroyEnemyObject(_castleTarget); 
                    PlayExplosionFx();
                    GameOver(true);
                }
                break;
            default:
                break;
        }
    }

    private void DestroyEnemyObject(GameObject target)
    {
        SetDefaultHealthbar(-1);
        Destroy(target);

    }

    private void DestroyEnemyObject(GameObject target, GameObject plane)
    {
        SetDefaultHealthbar(-1);
        Destroy(target);
        Destroy(plane);
    }

    #endregion

    private void Start()
    {
        _audio = GameObject.Find("AudioManager").GetComponent<AudioSource>();

        _targets[0] = _pinkTargetUI;
        _targets[1] = _purpleTargetUI;
        _targets[2] = _redTargetUI;
        _targets[3] = _yellowTargetUI;
        _targets[4] = _castleTargetUI;

        _pinkTargetHealthbar = _pinkTargetUI.transform.GetChild(0).gameObject.GetComponent<Healthbar>();
        _purpleTargetHealthbar = _purpleTargetUI.transform.GetChild(0).gameObject.GetComponent<Healthbar>();
        _redTargetHealthbar = _redTargetUI.transform.GetChild(0).gameObject.GetComponent<Healthbar>();
        _yellowTargetHealthbar = _yellowTargetUI.transform.GetChild(0).gameObject.GetComponent<Healthbar>();
        _castleTargetHealthbar = _castleTargetUI.transform.GetChild(0).gameObject.GetComponent<Healthbar>();

        _healthText.text = string.Format("Remaining health: {0}", _health.ToString());
    }

    private void GameOver(bool win)
    {
        if (win)
        {
            isGameRunning = false;
            _powerCell.GetComponent<BoxCollider>().isTrigger = true;
            Debug.Log("win");
        }
        else
        {
            isGameRunning = false;
            _hudController.Lose();
            Debug.Log("false");
        }
    }

    public void FinishGame()
    {
        _hudController.Win();
        PlayerPrefs.SetInt("SUCCEED_LEVEL3", 1);
        Debug.Log("Finish");
    }
}
