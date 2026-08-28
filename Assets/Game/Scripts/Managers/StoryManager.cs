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
        
        [Tooltip("Список фреймов, которые мы получаем если заходим в выборную ветку")]
        public StoryFrame[] optionStoryFrames;

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

            switch (frame.frameType)
            {
                case FrameType.MiddleText:
                    DisplayTextOnlyFrame(frame);
                    break;
                
                case FrameType.CharacterText:
                    DisplayCharacterTextFrame(frame);
                    break;
                
                case FrameType.ChooseOptions:
                    DisplayOptionsFrame(frame);
                    break;
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

        private void DisplayTextOnlyFrame(StoryFrame frame)
        {
            DialogueManager.Instance.ShowMainDialogue();
            DialogueManager.Instance.ChangeMiddleText(frame.dialogueText);
        }

        private void DisplayCharacterTextFrame(StoryFrame frame)
        {
            CharacterManager.Instance.ShowCharacters(frame.characterSide);
            CharacterManager.Instance.DisplayCharacter(frame.character, frame.characterSide, frame.clothesType, frame.emotion);
            DialogueManager.Instance.ShowMainDialogue();
            DialogueManager.Instance.ChangeMiddleText(frame.dialogueText);
        }

        private void DisplayOptionsFrame(StoryFrame frame)
        {
            DialogueManager.Instance.HideMainDialogue();
            
            ChoiceManager.Instance.ShowOptionsPanel();
            ChoiceManager.Instance.RedrawOptionPanel(frame);
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