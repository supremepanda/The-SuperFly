using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneFire : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _fireSpeed;

    [SerializeField] private GameObject _leftBulletPos;
    [SerializeField] private GameObject _rightBulletPos;

    private int _bulletAmount;
    private const int MAX_BULLET_AMOUNT = 20;

    public int GetBulletAmount()
    {
        return _bulletAmount;
    }

    public void IncreaseBulletAmmount(int amount)
    {
        _bulletAmount += amount;
    }

    private void Fire()
    {
        if(_bulletAmount > 0)
        {
            _bulletAmount--;

            GameObject bullet1 = Instantiate(_bullet, _leftBulletPos.transform.position, Quaternion.identity);
            GameObject bullet2 = Instantiate(_bullet, _rightBulletPos.transform.position, Quaternion.identity);

            Vector3 targetVector = transform.position;

            bullet1.GetComponent<Rigidbody>().velocity = targetVector * _fireSpeed;
            bullet2.GetComponent<Rigidbody>().velocity = targetVector * _fireSpeed;
        }
        else
        {
            Debug.Log("Yetersiz cephane");
        }
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }


}
