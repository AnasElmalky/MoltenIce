using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterSwitcher : MonoBehaviour
{
    #region VARIABLES
    [Header("Referenced values")]
    
    [SerializeField]
    GameObject iceCharacter, fireCharacter;
    [SerializeField]
    GameObject iceHealthBarImage, fireHealthBarImage;
    [SerializeField]
    GameObject iceSwitchImage, fireSwitchImage;
    [SerializeField]
    Color iceSwitchColor, fireSwitchColor;
    [SerializeField]
    GameObject characterSwitcherImage;
    [SerializeField]
    GameObject iceRespawnEffect, fireRespawnEffect;

    [Header("development values")]
    string currentPlayer;
    string playerToSwitch;
    public static string firePlayerName = "fire", icePlayerName = "ice";
    #endregion

    #region UNITYCALLBACKS
    private void Start()
    {
        ChoosePlayerValues(icePlayerName);
    }
    #endregion

    #region PUBLIC METHODS
    public void TogglePlayer()
    {
        string playerToChoose = (playerToSwitch == firePlayerName) ? firePlayerName : icePlayerName;
        ChoosePlayerValues(playerToChoose);
    }

    public string GetSelectedCharacterName()
    {
        return currentPlayer;
    }
    public void DisableSwitcher()
    {
        characterSwitcherImage.SetActive(false);
    }
    #endregion

    #region PRIVATE METHODS
    private void ChoosePlayerValues(string playerToBeActivated)
    {
        

        //Ice player variables
        iceCharacter.SetActive(playerToBeActivated.Equals(icePlayerName));
        iceHealthBarImage.SetActive(playerToBeActivated.Equals(icePlayerName));
        iceSwitchImage.SetActive(!playerToBeActivated.Equals(icePlayerName));

        //fire player variables
        fireCharacter.SetActive(playerToBeActivated.Equals(firePlayerName));
        fireHealthBarImage.SetActive(playerToBeActivated.Equals(firePlayerName));
        fireSwitchImage.SetActive(!playerToBeActivated.Equals(firePlayerName));

        //color and effect
        if (playerToBeActivated == icePlayerName)
        {
            Instantiate(iceRespawnEffect, gameObject.transform);
            characterSwitcherImage.GetComponent<Image>().color = fireSwitchColor;
            playerToSwitch = firePlayerName;
            currentPlayer = icePlayerName;
        }
        else
        {
            Instantiate(fireRespawnEffect, gameObject.transform);
            characterSwitcherImage.GetComponent<Image>().color = iceSwitchColor;
            playerToSwitch = icePlayerName;
            currentPlayer = firePlayerName;
        }
    }
    #endregion
}
