using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI pointsText;

    public TextMeshProUGUI textCoins;

    public Transform player;
    public Transform respawnPoint;
    public Vector3 startPoint = new Vector3(-2.39f, -0.98f, -0.0514f);
    public CheckpointController checkpoint;
    public Damageable health;

    public void Setup()
    {
        gameObject.SetActive(true);
        pointsText.text = textCoins.text + " POINTS";
    }

    public void RestartButton()
    { 
        SceneManager.LoadScene("GameplayScene");
    }

    public void ExitButton()
    {
        SceneManager.LoadScene(0);
    }

    public void RespawnButton()
    {
        if (checkpoint.checkpointReached == true)
        {
            player.transform.position = respawnPoint.transform.position;
            health.Health = 100;
            gameObject.SetActive(false);
            health.IsAlive = true;
        }
        else
        {
            player.transform.position = startPoint;
            health.Health = 100;
            gameObject.SetActive(false);
            health.IsAlive = true;
        }
    }
}
