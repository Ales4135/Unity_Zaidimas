using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public TMP_Text healthBarTetx;
    
    Damageable playerDamageable;

    private void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if(player == null )
        {
            Debug.Log("No player found in the scene.");
        }

        playerDamageable = player.GetComponent<Damageable>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        healthSlider.value = CalculateSliderPercentage(playerDamageable.Health, playerDamageable.MaxHealth);
        healthBarTetx.text = "Health " + playerDamageable.Health + " / " + playerDamageable.MaxHealth;
        
    }

    private void OnEnable()
    {
        playerDamageable.healthChanged.AddListener(OnPlayerHealthChanged);
    }

    private void OnDisable()
    {
        playerDamageable.healthChanged.RemoveListener(OnPlayerHealthChanged);
    }

    private float CalculateSliderPercentage(float currentHealth, float maxHealth)
    {
        return currentHealth / maxHealth;
    }

    private void OnPlayerHealthChanged(int newHealth, int maxHealth)
    {
        healthSlider.value = CalculateSliderPercentage(newHealth, maxHealth);
        healthBarTetx.text = "Health " + newHealth + " / " + maxHealth;
        if(newHealth <= 0)
        {
            healthBarTetx.text = "Health " + 0 + " / " + maxHealth;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
