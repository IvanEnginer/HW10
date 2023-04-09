using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public int Health = 5;
    public int MaxHealth = 8;

    //public AudioSource TakeDamageSound;
    public AudioSource AddHealthSound;

    public HealthUI HealthUI;

    //public DamageScrin DamageScrin;

    //public Blink Blink;

    private bool _invulnerable = false;

    public UnityEvent EventOnTakeDamage;

    private void Start()
    {
        HealthUI.Setup(MaxHealth);
        HealthUI.DisplayHelth(Health);
    }

    public void TakeDamage(int damageValue)
    {
        if (_invulnerable) return;

            Health -= damageValue;

            if (Health <= 0)
            {

                Health = 0;
                Die();
            }

            _invulnerable = true;
            Invoke(nameof(StopInvulnerable), 1);
            //TakeDamageSound.Play();
            HealthUI.DisplayHelth(Health);
            //DamageScrin.StartEffect();
            //Blink.StartBlink();

            EventOnTakeDamage.Invoke();
    }

    public void AddHealth(int healthValue)
    {
        Health += healthValue;

        if(Health > MaxHealth)
        {
            Health = MaxHealth;
        }
        
        AddHealthSound.Play();
        HealthUI.DisplayHelth(Health);
    }

    void StopInvulnerable()
    {
        _invulnerable = false;
    }

    public void Die()
    {
        Debug.Log("You lose");
    }
}
