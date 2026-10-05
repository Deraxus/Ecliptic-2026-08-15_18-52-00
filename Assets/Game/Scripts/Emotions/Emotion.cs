using System;
using UnityEngine;

namespace Ecliptic.Characters
{
    public enum Emotions
    {
        Idle,
        Happy,
        Angry,
        Sad,
        Amazed,
    }

    [Serializable]
    public class Emotion
    {
        public Emotions emotion;
        public Sprite sprite;
    }
   
}