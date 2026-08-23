using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Ecliptic.Backgrounds
{
    public class BackgroundManager : MonoBehaviour
    {
        public static BackgroundManager Instance;

        [Header("Технические настройки менеджера")]
        public Image mainBackgroundImage;
        public Background startBackground;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            
            Initialize();
        }

        void Initialize()
        {
            if (mainBackgroundImage == null)
            {
                Debug.LogError("Main Background Image is null");
                return;
            }
            
            ChangeBackground(startBackground);
        }

        public void ChangeBackground(Background background)
        {
            mainBackgroundImage.sprite = background.backgroundSprite;
        }
    }    
}

