using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleTarget : MonoBehaviour
{
    private ThirdLevelManager _manager;

    private void Start()
    {
        _manager = GameObject.Find("Level 3 Manager").GetComponent<ThirdLevelManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "bullet")
        {
            if (_manager.GetCanCastleGetDamage())
            {
                _manager.PlayHitFx();
                _manager.DecreaseCastleHealth("castle");
            }
        }
    }
}
