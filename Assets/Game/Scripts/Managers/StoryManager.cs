using Ecliptic.Backgrounds;
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
        public bool autoStoryFramesID = true;
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

            if (autoStoryFramesID)
            {
                int localID = 0;
                foreach (StoryFrame frame in storyFrames)
                {
                    frame.id = localID;
                    localID++;
                }
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

            if (frame.hideCharacters)
            {
                CharacterManager.Instance.HideCharacters();
            }

            if (frame.changeBackground)
            {
                BackgroundManager.Instance.ChangeBackground(frame.frameBackground);
            }
        }

        private void DisplayFirstFrame(StoryFrame frame)
        {
            switch (frame.frameType)
            {
                case FrameType.MiddleText:
                    DialogueManager.Instance.ChangeMiddleText(frame.dialogueText);
                    break;
            }
            
        }
        private void DisplaySameFrameType(StoryFrame frame)
        {
            switch (frame.frameType)
            {
                case FrameType.MiddleText:
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
            if (currentStoryFrame.frameType == FrameType.CharacterText && frame.frameType == FrameType.MiddleText)
            {
                print("Захожу в кейс уборки персонажей");
                DialogueManager.Instance.ShowMainDialogue();
                
                DialogueManager.Instance.ChangeMiddleText(frame.dialogueText);
            }
            
            // Было - обычный текст по центру
            // Стало - персонажи
            else if (currentStoryFrame.frameType == FrameType.MiddleText &&
                     frame.frameType == FrameType.CharacterText)
            {
                CharacterManager.Instance.ShowCharacters(frame.characterSide);
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