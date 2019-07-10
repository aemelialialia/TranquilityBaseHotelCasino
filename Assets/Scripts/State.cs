using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject {

    [TextArea(10, 14)] [SerializeField] string storyText;
    [SerializeField] State[] nextState;
    [SerializeField] string[] buttons;
    [SerializeField] public string sceneToLoad;
    [SerializeField] public bool shouldLoadButton;

    public string GetStateStory()
    {
        return storyText;
    }

    public State[] GetNextState()
    {
        return nextState;
    }
    
    public string GetNextButtonText(int index)
    {
        return buttons[index];
    }


}


// Button colors
// Normal: 431933
// Highlighted: 84406B
// Presse: 1A0512