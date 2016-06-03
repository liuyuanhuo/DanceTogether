﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIManagerScript : MonoBehaviour {
    
    private static GameObject gameButtonObject;

    private static GameObject rulesButtonObject;

    private static GameObject backButtonObject;

    private static Button gameButton;

    private static Text buttonText;

    private static Text scoreText;

    private static GameObject nameInputObject;

    public static Text countdownText; // UI text object named "UI_Countdown"
    public static Text infoText; // UI text object named "UI_InfoText"
    public static Text detailsText; // UI text object named "UI_DetailsText"

    // Use this for initialization
    void Start ()
    {
        gameButtonObject = GameObject.Find("UI_GameButton");
        gameButton = gameButtonObject.GetComponent<Button>();
        buttonText = gameButtonObject.GetComponentInChildren<Text>();
        SetMainButtonHighlight(false);
        SetButton(false);
        
        rulesButtonObject = GameObject.Find("UI_RulesButton");

        backButtonObject = GameObject.Find("UI_BackButton");
        SetBackButton(false);

        nameInputObject = GameObject.Find("UI_NameInput");
        SetInput(false);

        scoreText = GameObject.Find("UI_Score").GetComponent<Text>();
        scoreText.enabled = false;
        
        GameObject obj1 = GameObject.Find("UI_Countdown");
        countdownText = obj1.GetComponent<Text>();
        countdownText.enabled = false;

        GameObject obj2 = GameObject.Find("UI_InfoText");
        infoText = obj2.GetComponent<Text>();
        infoText.enabled = false;

        GameObject obj3 = GameObject.Find("UI_DetailsText");
        detailsText = obj3.GetComponent<Text>();
        detailsText.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void MainButtonPressed()
    {
        GameObject gm = GameObject.Find("LOCAL Player");
        gm.GetComponent<NetworkedPlayerScript>().MainButtonPressed();
    }

    public void RulesButtonPressed()
    {
        GameObject gm = GameObject.Find("LOCAL Player");
        gm.GetComponent<NetworkedPlayerScript>().CmdRulesButtonPressed();
    }

    public void BackButtonPressed()
    {
        GameObject gm = GameObject.Find("LOCAL Player");
        gm.GetComponent<LocalPlayerScript>().BackButtonPressed();
    }
    
    public void SetPlayerText()
    {
        InputField field = nameInputObject.GetComponent<InputField>();

        GameObject player = GameObject.Find("LOCAL Player");
        NetworkedPlayerScript nps = player.GetComponent<NetworkedPlayerScript>();
        nps.CmdSetPlayerText(field.text);
    }

    public static void FillPlayerText(string s)
    {
        InputField field = nameInputObject.GetComponent<InputField>();
        field.text = s;
    }

    public static void SetButton(bool enabled)
    {
        if (gameButtonObject != null)
        {
            gameButtonObject.SetActive(enabled);
        }
    }

    public static void SetInput(bool enabled)
    {
        if (nameInputObject != null)
            nameInputObject.SetActive(enabled);
    }

    public static void DisableInput(bool enabled)
    {
        if (nameInputObject != null)
            nameInputObject.GetComponent<InputField>().interactable = !enabled;
    }

    public static void SetInputColor(Color c)
    {
        nameInputObject.GetComponent<Image>().color = c;
    }

    public static void SetButtonText(string s)
    {
        buttonText.text = s;
    }

    /*
    public static void SetButtonInteractable(bool enabled)
    {
        gameButton.interactable = enabled;
    }
    */

    public static void SetReplayButton(bool enabled)
    {
        if (enabled)
        {
            SetButton(true);
            //SetButtonInteractable(true);
            SetButtonText("Replay");
        }
        else
        {
            //SetButtonInteractable(false);
            SetButtonText("Dance");
        }
    }

    public static void SetBackButton(bool enabled)
    {
        if (backButtonObject != null)
            backButtonObject.SetActive(enabled);
    }

    public static void SetScoreText(int score)
    {
        scoreText.enabled = true;
        scoreText.text = "Score:\n" + score.ToString();
    }

    public static void SetMainButtonHighlight(bool highlight)
    {
        gameButtonObject.GetComponent<Outline>().enabled = highlight;
    }

    public static void SetRulesButton(bool enabled)
    {
        if (rulesButtonObject != null)
        {
            rulesButtonObject.SetActive(enabled);
        }
    }
}
