using TMPro;
using UnityEngine;

namespace Ecliptic.Dialogue
{
    public class DialogueManager : MonoBehaviour
    {
        public static DialogueManager Instance;
    
        public TMP_Text mainDialogueText;
    
        public string currentMainDialogueMessage;

        public void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }
    }
   
}