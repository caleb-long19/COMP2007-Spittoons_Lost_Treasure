using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public class OnDamagedEvent : UnityEvent<int> { }

public class PlayerDamaged : AnimatorController
{
    //Reference the PlayerHealthBar script
    public PlayerHealth playerHealth;


    #region Start and Update Methods
    void Start()
    {
        //When the game starts - Set the players health to the max amount (100)
        playerHealth.MaximumHealth = 100;
        playerHealth.CurrentPlayerHealth = playerHealth.MaximumHealth;
    }

    #endregion

    public void TakeEnemyDamage(int damage) // (Linked to HurtTrigger Script)
    {
        playerHealth.CurrentPlayerHealth -= damage; // If Shield is less than or equal to 1, Player can lose Health
        HealthbarAnimations();
        SoundEffectHurt();

        //if the health is less than 0 - reset to 0
        if (playerHealth.CurrentPlayerHealth <= 0)
        {
            playerHealth.CurrentPlayerHealth = 0;
        }
    }

    #region Virtual Methods
    public override void SoundEffectHurt()
    {
        //Access the virtual method from the AnimatorController method and run the hurt SFX
        base.SoundEffectHurt();
    }

    public override void HealthbarAnimations()
    {
        //Access the virtual method from the AnimatorController method and run the healthbar animations
        base.HealthbarAnimations();
    }
    #endregion

}