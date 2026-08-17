using System;
using UnityEngine;

namespace Ecliptic.Characters
{
    public enum Emotions
    {
        Idle,
        Happy,
        Angry,
        Sad
    }

    [Serializable]
    public class Emotion
    {
        public Emotions emotion;
        public SpriteRenderer sprite;
    }
   
}