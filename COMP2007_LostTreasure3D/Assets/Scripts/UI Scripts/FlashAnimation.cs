using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashAnimation : MonoBehaviour, AnimationInterface
{
    //Access colour components
    private Color RedImageColor;
    private Color WhiteImageColor;


    //Access image component
    public Image health;


    //Access PlayerHealthDamage and PlayerHealthBar Scripts
    public PlayerHealth playerHealth = new PlayerHealth();


    void Start()
    {
        //On start store RGB colour floats in both Color Variables
        RedImageColor = new Color(255f, 0f, 0f, 255f);
        WhiteImageColor = new Color(1f, 1f, 0f, 255f);
        UiAnimation();
    }

    #region Animation Method and IEnumerator to create Rumble effect for Healthbar
    public void UiAnimation()
    {
        StartCoroutine("UiAnimationProcess");
    }
    #endregion

    #region Animation Method and IEnumerator to create Flash effect for Healthbar
    public IEnumerator UiAnimationProcess()
    {
        //Run while loop to flash between colours while Players health is 50 or less
        while (playerHealth.CurrentPlayerHealth <= 50)
        {
            health.color = RedImageColor;
            yield return new WaitForSeconds(0.3f);
            health.color = WhiteImageColor;
            yield return new WaitForSeconds(0.3f);
        }

        //Stop routine and return to default colour
        StopCoroutine("UiAnimationProcess");
        health.color = WhiteImageColor;
    }
    #endregion
}
