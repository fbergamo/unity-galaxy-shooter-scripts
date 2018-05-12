using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public bool gameOver = true;
    private UIManager _UIManager;
    private SpawnManager _spawnManager;
    [SerializeField]
    private GameObject _player;

    // Use this for initialization
    void Start () {
        _UIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if(gameOver == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameOver = false;
                if(_UIManager != null)
                {
                    _UIManager.ShowTitleScreen(false);
                }
                Instantiate(_player, new Vector3(0, 0, 0), Quaternion.identity);
                _UIManager.ResetScore();
            }
        }
	}
}
