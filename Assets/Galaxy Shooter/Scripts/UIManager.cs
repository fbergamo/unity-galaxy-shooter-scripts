using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Sprite[] lives;
    public Image livesImageDisplay;
    public GameObject titleScreen;
    private int _score;
    public Text scoreText;

    public void UpdateLives(int hp)
    {
        livesImageDisplay.sprite = this.lives[hp];
    }

    public void UpdateScore(int scorePoints)
    {
        _score += scorePoints;
        scoreText.text = _score.ToString();
    }

    public void ResetScore()
    {
        _score = 0;
        scoreText.text = _score.ToString();
    }

    public void ShowTitleScreen(bool show)
    {
        titleScreen.SetActive(show);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
