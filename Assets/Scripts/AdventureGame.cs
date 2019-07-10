using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AdventureGame : MonoBehaviour {

    [SerializeField] State startingState;
    [SerializeField] Text textComponent;
    [SerializeField] Text[] buttonTextComponent;
    [SerializeField] Button[] buttonComponent;
    State state; //this stores the current state

    // Use this for initialization
	void Start () {
        state = startingState;
        textComponent.text = state.GetStateStory();
	}
	
	// Update is called once per frame
	void Update () {
        ManageState();
        textComponent.text = state.GetStateStory();
        if (buttonTextComponent != null || buttonComponent != null)
        {
            for (int i = 0; i < buttonTextComponent.Length; i++)
            {
                buttonTextComponent[i].text = state.GetNextButtonText(i);
                if (buttonTextComponent[i].text == "")
                {
                    buttonComponent[i].gameObject.SetActive(false);
                } else
                {
                    buttonComponent[i].gameObject.SetActive(true);  
                }
            }
            if (state.shouldLoadButton)
            {
                buttonComponent[5].gameObject.SetActive(true);
            } else
            {
                buttonComponent[5].gameObject.SetActive(false);
            }
        }
    }

    private void ManageState()
    {
        var nextState = state.GetNextState();
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            state = nextState[0];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            state = nextState[1];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            state = nextState[2];
        }
    }

    public State GetCurrentState()
    {
        return state;
    }

    public void ButtonLoadNextState(int index)
    {
        var nextState = state.GetNextState();
        state = nextState[index];
    }

    public void LoadEndings()
    {
        SceneManager.LoadScene("End" + state.sceneToLoad);
    }
}
