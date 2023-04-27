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

    public TextMeshProUGUI timerText;

    public TextMeshProUGUI textTime;

    public Transform player;
    public Transform respawnPoint;
    public Transform respawnPointLevelTwo;
    public Vector3 startPoint = new Vector3(-2.39f, -0.98f, -0.0514f);
    public CheckpointController checkpoint;
    public CheckpointControllerLevelTwo checkpointLevelTwo;
    public Damageable health;

    public void Setup()
    {
        gameObject.SetActive(true);
        pointsText.text = textCoins.text + " POINTS";

        textTime.text = "TIME: " + timerText.text;
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
        if (checkpoint.checkpointReached == true && checkpointLevelTwo.checkpointReached == false)
        {
            player.transform.position = respawnPoint.transform.position;
            health.Health = 100;
            health.IsAlive = true;
            gameObject.SetActive(false);
        }
        else if(checkpointLevelTwo.checkpointReached == true && checkpoint.checkpointReached == true)
        {
            player.transform.position = respawnPointLevelTwo.transform.position;
            health.Health = 100;
            health.IsAlive = true;
            gameObject.SetActive(false);
        }
        else
        {
            player.transform.position = startPoint;
            health.Health = 100;
            health.IsAlive = true;
            gameObject.SetActive(false);
        }
    }
}
