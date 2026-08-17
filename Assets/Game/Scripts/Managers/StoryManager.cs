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
        }
    
        void Initialize()
        {
        
        }

        public void NextFrame()
        {
        
        }

        private void DisplayFrame(StoryFrame frame)
        {
        
        }

        private void DisplaySameFrameType(StoryFrame frame)
        {
            switch (frame.frameType)
            {
                case FrameType.MiddleTextOnly:
                
                    break;
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