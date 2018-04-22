using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
    [SerializeField]
    private float _speed = 3f;
    [SerializeField]
    private GameObject _enemyExplosionPrefab;

    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if(transform.position.y < -7.5f)
        {
            float randomX = Random.Range(-11f, 11f);
            transform.position = new Vector3(randomX, 7.5f, 0);
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag.Equals("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.OnEnemyCollision();
                Instantiate(_enemyExplosionPrefab, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
        else if (other.tag.Equals("Laser"))
        {
            Laser laser = other.GetComponent<Laser>();
            if (laser != null)
            {
                Destroy(laser.gameObject);
                Instantiate(_enemyExplosionPrefab, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }
}
