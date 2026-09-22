using Ecliptic.Stats;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

            MakeButtonActive();
            foreach (var localStat in storyChoice.statRequired)
            {
                if (!StatManager.Instance.HasEnoughStat(localStat.stat, localStat.amount))
                {
                    MakeButtonInactive();
                    break;
                }
            }
            
            GetComponentInChildren<TMP_Text>().text = storyChoice.choiceText;
        }

        public void MakeButtonInactive()
        {
            /*var colors = GetComponent<Button>().colors;
            colors.normalColor = new Color(0.8f, 0.8f, 0.8f);
            GetComponent<Button>().colors = colors;*/
            
            GetComponent<Button>().interactable = false;
        }

        public void MakeButtonActive()
        {
            var colors = GetComponent<Button>().colors;
            colors.normalColor = new Color(1f, 1f, 1f);
            GetComponent<Button>().colors = colors;
            
            GetComponent<Button>().interactable = true;
        }
    }
    
}
