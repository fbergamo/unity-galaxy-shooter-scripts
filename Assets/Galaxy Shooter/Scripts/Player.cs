using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public bool canTripleShot = true;

    [SerializeField]
    private float _speed = 10f;
    [SerializeField]
    private float _shootSpeed = 0.4f;
    [SerializeField]
    private GameObject _laserPrefab;
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
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 1.4f, 0), Quaternion.identity);
            if (canTripleShot)
            {
                Instantiate(_laserPrefab, transform.position + new Vector3(-0.785f, 0, 0), Quaternion.identity);
                Instantiate(_laserPrefab, transform.position + new Vector3(0.785f, 0, 0), Quaternion.identity);
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
