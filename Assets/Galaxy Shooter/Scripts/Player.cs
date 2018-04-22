using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private bool _canTripleShot = false;
    [SerializeField]
    private bool _canSpeed = false;
    [SerializeField]
    private bool _canShield = false;
    [SerializeField]
    private int hp = 3;
    [SerializeField]
    private float _speed = 10f;
    [SerializeField]
    private float _shootSpeed = 0.4f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _laseripleShotPrefab;
    [SerializeField]
    private GameObject _shieldGameObject;
    [SerializeField]
    private GameObject _playerExplosionPrefab;
    private float _nextShot = 0.0f;

    

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        Movement();
        Shoot();

        CheckHp();
    }

    private void Shoot()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > _nextShot)
        {
            if (!_canTripleShot)
            {
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 1.4f, 0), Quaternion.identity);
            } else
            {
                Instantiate(_laseripleShotPrefab, transform.position, Quaternion.identity);
            }
            _nextShot = Time.time + _shootSpeed;
        }
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if (!_canSpeed) { 
            transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * _speed);
        } else
        {
            transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * _speed * 1.5f);
        }
        checkVerticalBounds(5.6f);
        checkHorizontalBounds(12f);
    }

    private void CheckHp()
    {
        if(this.hp == 0)
        {
            Instantiate(_playerExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    private void checkHorizontalBounds(float horizontalBound)
    {
        if (transform.position.x > horizontalBound)
        {
            transform.position = new Vector3(-horizontalBound, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -horizontalBound)
        {
            transform.position = new Vector3(horizontalBound, transform.position.y, transform.position.z);
        }
    }

    private void checkVerticalBounds(float verticalBound)
    {
        if (transform.position.y > verticalBound)
        {
            transform.position = new Vector3(transform.position.x, verticalBound, transform.position.z);
        }
         else if (transform.position.y < -verticalBound)
        {
            transform.position = new Vector3(transform.position.x, -verticalBound, transform.position.z);
        }
    }

    public void TripleShotPowerUp()
    {
        _canTripleShot = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5f);
        _canTripleShot = false;
    }

    public void SpeedPowerUp()
    {
        _canSpeed = true;
        StartCoroutine(SpeedPowerDownRoutine());
    }

    IEnumerator SpeedPowerDownRoutine()
    {
        yield return new WaitForSeconds(5f);
        _canSpeed = false;
    }

    public void ShieldPowerUp()
    {
        _canShield = true;
        _shieldGameObject.SetActive(true);
    }


    public void  OnEnemyCollision()
    {
        if (!_canShield)
        {
            this.hp -= 1;
        } else
        {
            _canShield = false;
            _shieldGameObject.SetActive(false);
        }
    }


}
