using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthController : MonoBehaviour
{
    #region VARIABLES
    [Header("Rference Valeues")]
    [SerializeField]
    CharacterSwitcher characterSwitcherScript;
    [SerializeField]
    CharacterMovments characterMovementScript;
    [SerializeField]
    Animator iceAnimator, fireAnimator;
    [SerializeField]
    Slider healthSlider;

    [Header("development values")]
    string fireColliderName = "fireCollider";
    float filledHealth = 100;
    float currentHealth = 100;
    float rainDamage = .03f;
    float fireDamage = 35;
    float fireHealth = 2;
    #endregion

    #region UNITY CALLBACKS
    private void Start()
    {
        ResetHealth();
    }
    private void Update()
    {
        RainDamage();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == fireColliderName)
        {
            FireCollision();
        }
    }
    #endregion

    #region PRIVATE METHODS
    private void ResetHealth()
    {
        currentHealth = filledHealth;
        UpdateHealthSlider();
    }
    private void ReduceDamage(float value)
    {
        if(currentHealth-value <= 0)
        {
            currentHealth = 0;
        }
        else
        {
            currentHealth -= value;
        }
        UpdateHealthSlider();

        if(currentHealth <= 0)
        {
            Die();
        }
    }
    private void IncreaseHealth(float value)
    {
        if(currentHealth+value > 100)
        {
            currentHealth = 100;
        }
        else
        {
            currentHealth += value;
        }
        UpdateHealthSlider();
    }
    private void RainDamage()
    {
        if( characterSwitcherScript.GetSelectedCharacterName() == CharacterSwitcher.firePlayerName)
        {
            ReduceDamage(rainDamage);
        }
    }
    private void FireCollision()
    {
        if (characterSwitcherScript.GetSelectedCharacterName() == CharacterSwitcher.icePlayerName)
        {
            FireDamage();
        }
        else
        {
            FireHeal();
        }
    }
    private void FireDamage()
    {
        if (characterSwitcherScript.GetSelectedCharacterName() == CharacterSwitcher.icePlayerName)
        {
            ReduceDamage(fireDamage);
        }
    }
    private void FireHeal()
    {
        if (characterSwitcherScript.GetSelectedCharacterName() == CharacterSwitcher.firePlayerName)
        {
            IncreaseHealth(fireHealth);
        }
    }
    private void UpdateHealthSlider()
    {
        healthSlider.value = currentHealth / filledHealth;
    }
    private void Die()
    {
        characterMovementScript.enabled = false;
        characterSwitcherScript.DisableSwitcher();
        fireAnimator.SetBool("IsDead", true);
        iceAnimator.SetBool("IsDead", true);
    }
    #endregion

}
