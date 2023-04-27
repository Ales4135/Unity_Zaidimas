using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameFinishedScreen : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI pointsText;

    public TextMeshProUGUI textCoins;

    public TextMeshProUGUI timerText;

    public TextMeshProUGUI textTime;



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

}
