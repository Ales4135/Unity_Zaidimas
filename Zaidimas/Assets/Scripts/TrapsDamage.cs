using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrapsDamage : MonoBehaviour
{
    [SerializeField] private int damage;
    Vector2 vector = new Vector2(0f, 0f);
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Damageable>().Hit(damage, vector);
        }
    }
}
