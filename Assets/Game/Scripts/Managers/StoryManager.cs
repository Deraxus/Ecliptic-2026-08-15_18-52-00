using Ecliptic.Characters;
using Ecliptic.Dialogue;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Ecliptic.Story
{
    public class StoryManager : MonoBehaviour
    {
        public static StoryManager Instance;
    
        [Header("Основные настройки сцены")]
    
        public StoryFrame[] storyFrames;

        public int currentFrameIndex = 0;
    
        public StoryFrame currentStoryFrame;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            
            Initialize();
        }
    
        void Initialize()
        {
            if (storyFrames.Length == 0)
            {
                Debug.LogError("Фреймы не найдены!");
                return;
            }
            
            NextFrame();
        }

        // Подключаем метод к кликам/тапам, и даем ему бегать по списку фреймов
        public void NextFrame()
        {
            if (currentFrameIndex >= storyFrames.Length)
            {
                Debug.LogError("Закончились фреймы для отображения!");
                return;
            }
            
            StoryFrame currentLocalStoryFrame =  storyFrames[currentFrameIndex];
            DisplayFrame(currentLocalStoryFrame);
            
            currentStoryFrame = currentLocalStoryFrame;
            currentFrameIndex++;
        }

        private void DisplayFrame(StoryFrame frame)
        {
            if (currentStoryFrame == null)
            {
                DisplayFirstFrame(frame);
                return;
            }

            if (IsSameFrameType(frame))
            {
                DisplaySameFrameType(frame);
            }
            else
            {
                DisplayDifferenceFrame(frame);
            }
        }

        private void DisplayFirstFrame(StoryFrame frame)
        {
            switch (frame.frameType)
            {
                case FrameType.MiddleTextOnly:
                    DialogueManager.Instance.ChangeMiddleText(frame.dialogueText);
                    break;
            }
            
        }
        private void DisplaySameFrameType(StoryFrame frame)
        {
            switch (frame.frameType)
            {
                case FrameType.MiddleTextOnly:
                    DialogueManager.Instance.ChangeMiddleText(frame.dialogueText);
                    break;
                
                case FrameType.CharacterText:
                    DialogueManager.Instance.ChangeMiddleText(frame.dialogueText);
                    CharacterManager.Instance.DisplayCharacter(frame.character, frame.characterSide, frame.clothesType, frame.emotion);
                    break;
            }
        }

        private void DisplayDifferenceFrame(StoryFrame frame)
        {
            // Было - персонажи
            // Стало - одиночный текст по центру
            if (currentStoryFrame.frameType == FrameType.CharacterText && frame.frameType == FrameType.MiddleTextOnly)
            {
                CharacterManager.Instance.HideCharacters();
                DialogueManager.Instance.ShowMainDialogue();
                
                DialogueManager.Instance.ChangeMiddleText(frame.dialogueText);
            }
            
            // Было - обычный текст по центру
            // Стало - персонажи
            else if (currentStoryFrame.frameType == FrameType.MiddleTextOnly &&
                     frame.frameType == FrameType.CharacterText)
            {
                CharacterManager.Instance.ShowCharacters();
                CharacterManager.Instance.DisplayCharacter(frame.character, frame.characterSide, frame.clothesType, frame.emotion);
                DialogueManager.Instance.ShowMainDialogue();
                DialogueManager.Instance.ChangeMiddleText(frame.dialogueText);
            }
        }

        private bool IsSameFrameType(StoryFrame frame)
        {
            if (currentStoryFrame.frameType == frame.frameType)
            {
                return true;
            }

            return false;
        }
    }
   
}