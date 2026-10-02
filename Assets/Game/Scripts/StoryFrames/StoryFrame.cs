using System;
using System.Collections.Generic;
using Ecliptic.Backgrounds;
using Ecliptic.Characters;
using UnityEngine;

namespace Ecliptic.Story
{
    public enum FrameType
    {
        MiddleText = 0,
        CharacterText = 1,
        ChooseOptions = 2,
        Cutscene = 3
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
        
        [Tooltip("Возможные выборы на этом фрейме. Для типа фрейма ChooseOptions")]
        public List<StoryChoice> choices;

        [Header("Дополнительные настройки фрейма")]
        [Tooltip("Прячет всех персонажей с кадра")]
        public bool hideCharacters = false;


    }   
}
