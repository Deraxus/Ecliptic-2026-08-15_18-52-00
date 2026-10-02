using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Ecliptic.Dialogue
{
    public class DialogueManager : MonoBehaviour
    {
        public static DialogueManager Instance;
        
        
        public Image mainCharacterImage;
        public Image mainDialogueImage;
        
        public TMP_Text mainCharacterText;
        public TMP_Text mainDialogueText;
    
        public string currentMainDialogueMessage;
        public string currentCharacterTextMessage;

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
        public void ChangeMiddleMainText(string newText)
        {
            // Тут начинаем делать плавно появляющийся текст
            // Но это потом, мб через корутину
            
            currentMainDialogueMessage = newText;
            mainDialogueText.text = newText;
        }

        public void ChangeCharacterText(string newText)
        {
            currentCharacterTextMessage = newText;
            mainCharacterText.text = newText;
        }

        public void ShowCharacterDialogue()
        {
            mainCharacterImage.enabled = true;
        }
        public void ShowMainDialogue()
        {
            mainDialogueImage.enabled = true;
        }

        public void HideCharacterDialogue()
        {
            mainCharacterText.text = "";
            mainCharacterImage.enabled = false;
        }
        
        public void HideMainDialogue()
        {
            mainDialogueText.text = "";
            mainDialogueImage.enabled = false;
        }
    }
   
}