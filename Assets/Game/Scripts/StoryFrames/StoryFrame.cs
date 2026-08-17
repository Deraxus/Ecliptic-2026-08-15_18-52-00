using System;
using Ecliptic.Characters;
using UnityEngine;

namespace Ecliptic.Story
{
    public enum FrameType
    {
        MiddleTextOnly,
        CharacterText,
        ChooseOptions
    }

    [Serializable]
    public class StoryFrame
    {
        public int id;
        public FrameType frameType;
    
        public string dialogueText;
    
        public Character character;
        public Emotions emotion;

    }   
}
