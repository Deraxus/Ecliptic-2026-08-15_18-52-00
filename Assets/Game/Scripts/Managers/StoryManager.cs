using System.Collections.Generic;
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
        public StoryFrame[] startStoryFrames;
        public bool autoStoryFramesID = true;

        public int currentFrameIndex = 0;
    
        public StoryFrame currentStoryFrame;
        
        private Stack<StoryReturnPoint> storyReturnPoints;
        private StoryFrame[] currentStoryFrames;
        

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
            if (startStoryFrames.Length == 0)
            {
                Debug.LogError("Фреймы не найдены!");
                return;
            }

            if (autoStoryFramesID)
            {
                int localID = 0;
                foreach (StoryFrame frame in startStoryFrames)
                {
                    frame.id = localID;
                    localID++;
                }
            }
            
            LoadStartCurrentFrames();
            NextFrame();
        }

        // Подключаем метод к кликам/тапам, и даем ему бегать по списку фреймов
        public void NextFrame()
        {
            if (currentFrameIndex >= currentStoryFrames.Length)
            {
                EndCurrentStoryFrameList();
            }
            
            StoryFrame currentLocalStoryFrame =  currentStoryFrames[currentFrameIndex];
            DisplayFrame(currentLocalStoryFrame);
            
            currentStoryFrame = currentLocalStoryFrame;
            currentFrameIndex++;
        }
        
        // Кнопка вызывает этот метод при нажатии
        public void LoadChoiceOption(StoryChoice choice)
        {
            StoryReturnPoint localReturnPoint = new StoryReturnPoint();
            localReturnPoint.returnedIndex = currentFrameIndex;
            localReturnPoint.storyFrames = currentStoryFrames;
            
            storyReturnPoints.Push(localReturnPoint);
            
            currentStoryFrames = choice.storyFrames;
            currentFrameIndex = 0;
            
            ChoiceManager.Instance.HideOptionsPanel();
            NextFrame();
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

        private void LoadStartCurrentFrames()
        {
            storyReturnPoints = new Stack<StoryReturnPoint>();
            currentStoryFrames = startStoryFrames;
        }

        private void EndCurrentStoryFrameList()
        {
            if (storyReturnPoints.Count == 0)
            {
                Debug.Log("История закончилась");
                return;
            }
            
            StoryReturnPoint localReturnPoint = storyReturnPoints.Pop();
            
            currentStoryFrames = localReturnPoint.storyFrames;
            currentFrameIndex = localReturnPoint.returnedIndex;
        }
        
    }
   
}