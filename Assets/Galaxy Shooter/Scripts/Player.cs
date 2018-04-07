using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public bool canTripleShot = false;

    [SerializeField]
    private float _speed = 10f;
    [SerializeField]
    private float _shootSpeed = 0.4f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _laseripleShotPrefab;
    private float _nextShot = 0.0f;

    

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        Movement();
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > _nextShot)
        {
            if (!canTripleShot)
            {
                Instantiate(_laserPrefab, transform.position, Quaternion.identity);
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
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * _speed);

        checkVerticalBounds(5.6f);
        checkHorizontalBounds(12f);
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
}
