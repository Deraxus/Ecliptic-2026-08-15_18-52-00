using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Ecliptic.Story
{
    public class ChoiceManager : MonoBehaviour
    {
        public static ChoiceManager Instance;

        public TMP_Text optionText;

        public GameObject optionPanel;

        public Button[] optionButtons;

        public void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public void Initialize()
        {
            
        }

        public void ShowOptionsPanel()
        {
            optionPanel.SetActive(true);
        }

        public void HideOptionsPanel()
        {
            optionPanel.SetActive(false);
        }

        public void RedrawOptionPanel(StoryFrame storyFrame)
        {
            optionText.text = storyFrame.dialogueText;
            
            for (int i = 0; i < optionButtons.Length; i++)
            {
                if (i < storyFrame.choices.Count)
                {
                    optionButtons[i].GetComponent<ChoiceButtonLogic>().RedrawButton(storyFrame.choices[i]);   
                }
                else
                {
                    optionButtons[i].gameObject.SetActive(false);
                }
            }
        }
    }    
}

