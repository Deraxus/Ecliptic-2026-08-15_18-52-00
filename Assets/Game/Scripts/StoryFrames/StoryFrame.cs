using System;
using Ecliptic.Backgrounds;
using Ecliptic.Characters;
using UnityEngine;

namespace Ecliptic.Story
{
    public enum FrameType
    {
        MiddleText,
        CharacterText,
        ChooseOptions
    }

    [Serializable]
    public class StoryFrame
    {
        public int id;
        public FrameType frameType;
    
        public string dialogueText;

        public bool changeBackground = false;
        public Background frameBackground;
    
        public Character character;
        public Sides characterSide;
        
        public ClothesTypes clothesType;
        public Emotions emotion;

        [Header("Дополнительные настройки фрейма")]
        [Tooltip("Прячет всех персонажей с кадра")]
        public bool hideCharacters = false;


    }   
}
