using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    [SerializeField]
    private GameObject _enemyGameObject;
    [SerializeField]
    private GameObject[] _powerUps;

    private GameManager _gameManager;

	// Use this for initialization
	void Start () {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

    public void StartSpawning()
    {
        StartCoroutine(EnemySpawnRoutine());
        StartCoroutine(PowerUpSpawnRoutine());
    }

    IEnumerator EnemySpawnRoutine()
    {
        while (!_gameManager.gameOver) {
            Vector3 position = new Vector3(Random.Range(-5.6f, 5.6f), 12f, 0f);
            Debug.Log("enemy: " + position);
            Instantiate(_enemyGameObject, position, Quaternion.identity);
            yield return new WaitForSeconds(5f);
        }
    }

    IEnumerator PowerUpSpawnRoutine()
    {
        while (!_gameManager.gameOver)
        {
            Vector3 position = new Vector3(Random.Range(-5.6f, 5.6f), 12f, 0f);
            Debug.Log("powerup: " + position);
            int randPowerupId = Random.Range(0, 3);
            Instantiate(_powerUps[randPowerupId], position, Quaternion.identity);
            yield return new WaitForSeconds(3f);
        }
    }

}
