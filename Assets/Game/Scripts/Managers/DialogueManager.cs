using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Ecliptic.Dialogue
{
    public class DialogueManager : MonoBehaviour
    {
        public static DialogueManager Instance;

        public Image mainDialogueImage;
        public TMP_Text mainDialogueText;
    
        public string currentMainDialogueMessage;

        public void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        private void Initialize()
        {
            if (mainDialogueImage == null && mainDialogueImage != null)
            {
                mainDialogueImage = mainDialogueText.transform.parent.GetComponent<Image>();
            }
            
            if (mainDialogueImage == null && mainDialogueText == null)
            {
                Debug.LogError("Dialogue Manager has no image and text!");
                return;
            }
        }
        public void ChangeMiddleText(string newText)
        {
            // Тут начинаем делать плавно появляющийся текст
            // Но это потом, мб через корутину
            
            currentMainDialogueMessage = newText;
            mainDialogueText.text = newText;
        }

        public void ShowMainDialogue()
        {
            mainDialogueImage.enabled = true;
        }
        
        public void HideMainDialogue()
        {
            mainDialogueText.text = "";
            mainDialogueImage.enabled = false;
        }
    }
   
}