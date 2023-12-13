using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class UIController : MonoBehaviour
{
  int score = 0;
  GameObject scoreText;
  GameObject gameOverText;

  public void GameOver()
  {
    this.gameOverText.GetComponent<TMP_Text>().text = "GameOver";
  }

  public void AddScore()
  {
    this.score += 10;
  }

  void Start()
  {
    this.scoreText = GameObject.Find("Score");
    this.gameOverText = GameObject.Find("GameOver");
  }

  void Update()
  {
    scoreText.GetComponent<TMP_Text>().text = "Score:" + score.ToString("D4");
  }
}
