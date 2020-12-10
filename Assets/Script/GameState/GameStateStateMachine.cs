using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState
{

    // Possible states:
    //     "Init"
    //     "Menu"
    //     "Intro
    //     "InGame"
    //     "Win"
    //     "Credit
    //     "Controls"
    //     "Quit"

    // Starting state is the initialisation state
    public string CurrentState = "Init";

    public void SwitchToMenu()
    {
        Debug.Log("GameState switch to 'Menu' requested.");

        Debug.Log("Checking preconditions ...");

        if (CurrentState == "Menu")
        {
            Debug.LogWarning("Already in state 'Menu', declining switch.");

            // This will end the execution of this function.
            return;
        }

        if (CurrentState == "Quit")
        {
            Debug.LogWarning("Declining switch from the 'Quit' state.");

            // This will end the execution of this function.
            return;
        }

        // All other states so far allow switching to menu.

        Debug.Log("Preconditions okay. Switching to 'Menu' state");
        Cursor.visible = true;
        // Don't forget to update the current state
        CurrentState = "Menu";
        SceneManager.LoadScene("Menu");
    }


    public void SwitchToIntro()
    {
        Debug.Log("GameState switch to 'Intro' requested.");

        Debug.Log("Checking preconditions ...");

        //do nothing if Init state
        if (CurrentState == "Init")
        {
            Debug.LogWarning("Declining switch from the 'Init' state.");
            return;
        }

        //do nothing if Intro state
        if (CurrentState == "Intro")
        {
            Debug.LogWarning("Already in state 'Intro', declining switch.");
            return;
        }

        //do nothing if InGame state
        if (CurrentState == "Ingame")
        {
            Debug.LogWarning("Declining switch from the 'Ingame' state.");
            return;
        }

        //do nothing if Win state
        if (CurrentState == "Win")
        {
            Debug.LogWarning("Declining switch from the 'Win' state.");
            return;
        }

        //do nothing if credit state
        if (CurrentState == "Credit")
        {
            Debug.LogWarning("Declining switch from the 'Credit' state.");
            return;
        }

        ////do nothing if Controls state
        //if (CurrentState == "Controls")
        //{
        //    Debug.LogWarning("Declining switch from the 'Controls' state.");
        //    return;
        //}

        //do nothing if Quit state
        if (CurrentState == "Quit")
        {
            Debug.LogWarning("Declining switch from the 'Quit' state.");
            return;
        }

        Debug.Log("Preconditions okay. Switching to 'Ingame' state");

        //change state to Ingame, go to Gameplay scene
        Cursor.visible = true;
        CurrentState = "Intro";
        SceneManager.LoadScene("Introduction");

    }

    public void SwitchToInGame()
    {
        Debug.Log("GameState switch to 'InGame' requested.");

        Debug.Log("Checking preconditions ...");

        //do nothing if Init state
        if (CurrentState == "Init")
        {
            Debug.LogWarning("Declining switch from the 'Init' state.");
            return;
        }

        //do nothing if Menu state
        if (CurrentState == "Menu")
        {
            Debug.LogWarning("Declining switch from the 'Menu' state.");

            // This will end the execution of this function.
            return;
        }

        //do nothing if InGame state
        if (CurrentState == "InGame")
        {
            Debug.LogWarning("Already in state 'Ingame', declining switch.");
            return;
        }

        //do nothing if Win state
        if (CurrentState == "Win")
        {
            Debug.LogWarning("Declining switch from the 'Win' state.");
            return;
        }

        //do nothing if credit state
        if (CurrentState == "Credit")
        {
            Debug.LogWarning("Declining switch from the 'Credit' state.");
            return;
        }

        //do nothing if Controls state
        if (CurrentState == "Controls")
        {
            Debug.LogWarning("Declining switch from the 'Controls' state.");
            return;
        }

        //do nothing if quit state
        if (CurrentState == "Quit")
        {
            Debug.LogWarning("Declining switch from the 'Quit' state.");
            return;
        }

        Debug.Log("Preconditions okay. Switching to 'Ingame' state");

        //change state to Ingame, go to Gameplay scene
        Cursor.visible = false;
        CurrentState = "Ingame";
        SceneManager.LoadScene("GameL1");

    }

    public void SwitchToWin()
    {
        Debug.Log("GameState switch to 'Win' requested.");

        Debug.Log("Checking preconditions ...");

        //do nothing if Init state
        if (CurrentState == "Init")
        {
            Debug.LogWarning("Declining switch from the 'Init' state.");
            return;
        }

        //do nothing if Menu state
        if (CurrentState == "Menu")
        {
            Debug.LogWarning("Declining switch from the 'Menu' state.");

            // This will end the execution of this function.
            return;
        }

        //do nothing if Win state
        if (CurrentState == "Win")
        {
            Debug.LogWarning("Already in state 'Win', declining switch.");
            return;
        }

        //do nothing if credit state
        if (CurrentState == "Credit")
        {
            Debug.LogWarning("Declining switch from the 'Credit' state.");
            return;
        }

        //do nothing if Controls state
        if (CurrentState == "Controls")
        {
            Debug.LogWarning("Declining switch from the 'Controls' state.");
            return;
        }

        //do nothing if quit state
        if (CurrentState == "Quit")
        {
            Debug.LogWarning("Declining switch from the 'Quit' state.");
            return;
        }

        Debug.Log("Preconditions okay. Switching to 'Win' state");

        //change state to Ingame, go to Gameplay scene
        Cursor.visible = true;
        CurrentState = "Win";
        SceneManager.LoadScene("Win");

    }

    public void SwitchToCredit()
    {
        Debug.Log("GameState switch to 'Win' requested.");

        Debug.Log("Checking preconditions ...");

        //do nothing if Init state
        if (CurrentState == "Init")
        {
            Debug.LogWarning("Declining switch from the 'Init' state.");
            return;
        }

        //do nothing if Menu state
        if (CurrentState == "Menu")
        {
            Debug.LogWarning("Declining switch from the 'Menu' state.");

            // This will end the execution of this function.
            return;
        }

        //do nothing if credit state
        if (CurrentState == "Credit")
        {
            Debug.LogWarning("Declining switch from the 'Credit' state.");
            return;
        }

        //do nothing if Controls state
        if (CurrentState == "Controls")
        {
            Debug.LogWarning("Declining switch from the 'Controls' state.");
            return;
        }

        //do nothing if quit state
        if (CurrentState == "Quit")
        {
            Debug.LogWarning("Declining switch from the 'Quit' state.");
            return;
        }

        Debug.Log("Preconditions okay. Switching to 'Credit' state");

        //change state to Ingame, go to Gameplay scene
        Cursor.visible = true;
        CurrentState = "Credit";
        SceneManager.LoadScene("Credit");

    }

    public void SwitchToControls()
    {
        Debug.Log("GameState switch to 'Controls' requested.");

        Debug.Log("Checking preconditions ...");

        //do nothing if Init state
        if (CurrentState == "Init")
        {
            Debug.LogWarning("Declining switch from the 'Init' state.");
            return;
        }

        //do nothing if Menu state
        if (CurrentState == "InGame")
        {
            Debug.LogWarning("Declining switch from the 'InGame' state.");

            // This will end the execution of this function.
            return;
        }

        //do nothing if Win state
        if (CurrentState == "Win")
        {
            Debug.LogWarning("Already in state 'Win', declining switch.");
            return;
        }

        //do nothing if credit state
        if (CurrentState == "Credit")
        {
            Debug.LogWarning("Declining switch from the 'Credit' state.");
            return;
        }

        //do nothing if Controls state
        if (CurrentState == "Controls")
        {
            Debug.LogWarning("Declining switch from the 'Controls' state.");
            return;
        }

        //do nothing if quit state
        if (CurrentState == "Quit")
        {
            Debug.LogWarning("Declining switch from the 'Quit' state.");
            return;
        }

        Debug.Log("Preconditions okay. Switching to 'Win' state");

        //change state to Controls, go to Controls scene
        Cursor.visible = true;
        CurrentState = "Controls";
        SceneManager.LoadScene("Controls");
    }

    public void QuitGame()
    {
        Debug.Log("GameState switch to 'Quit' requested.");

        Debug.Log("Checking preconditions ...");

        //do nothing if Init state
        if (CurrentState == "Init")
        {
            Debug.LogWarning("Declining switch from the 'Init' state.");
            return;
        }

        //do nothing if Controls state
        if (CurrentState == "Controls")
        {
            Debug.LogWarning("Declining switch from the 'Controls' state.");
            return;
        }

        //do nothing if Intro state
        if (CurrentState == "Intro")
        {
            Debug.LogWarning("Already in state 'Intro', declining switch.");
            return;
        }

        //do nothing if InGame state
        if (CurrentState == "Ingame")
        {
            Debug.LogWarning("Already in state 'Ingame', only can switch to Menu.");
            return;
        }

        //do nothing if Win state
        if (CurrentState == "Win")
        {
            Debug.LogWarning("Declining switch from the 'Win' state.");
            return;
        }

        //do nothing if credit state
        if (CurrentState == "Credit")
        {
            Debug.LogWarning("Declining switch from the 'Credit' state.");
            return;
        }

        //do nothing if Quit state
        if (CurrentState == "Quit")
        {
            Debug.LogWarning("Already in state 'Quit', declining switch");
            return;
        }

        Debug.Log("Preconditions okay. Switching to 'Quit' state");

        // change state to Quit, Quit game
        CurrentState = "Quit";
        Application.Quit();
        
    }

}
