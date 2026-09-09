using TMPro;
using UnityEngine;

namespace Ecliptic.Story
{
    public class ChoiceButtonLogic : MonoBehaviour
    {
        public StoryChoice storyChoice;
        
        public void OnClick()
        {
            StoryManager.Instance.LoadChoiceOption(storyChoice);
        }

        public void RedrawButton(StoryChoice storyChoice)
        {
            this.storyChoice = storyChoice;

            GetComponentInChildren<TMP_Text>().text = storyChoice.choiceText;
        }
        
    }
    
}
