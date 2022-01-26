using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController ThisInstance = null;
    public GameObject Player = null;
    public static int Score;
    public string ScorePrefix = string.Empty;
    public Text ScoreText = null;
    public PlayerHealth PlayerHealths;
    public string PlayerHealthPrefix = string.Empty;
    public Text PlayerHealthText = null;
    public Text GameOverText = null;

    void Awake()
    {
        ThisInstance = this;
        ThisInstance.GameOverText.gameObject.SetActive(false);
        PlayerHealths = Player.gameObject.GetComponent<PlayerHealth>();
    }
    void Update()
    {
        if (ScoreText != null)
        {
            ScoreText.text = ScorePrefix + Score.ToString();
        }
        if (PlayerHealthText != null)
        {
            PlayerHealthText.text = PlayerHealthPrefix + PlayerHealths.HealthPoints;
        }
        if (PlayerHealths.HealthPoints <= 0)
            GameOver();
    }

    public static void GameOver()
    {
        if (ThisInstance.GameOverText != null)
        {
            ThisInstance.GameOverText.gameObject.SetActive(true);
        }
    }
}
