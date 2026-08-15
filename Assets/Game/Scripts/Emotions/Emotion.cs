using System;
using UnityEngine;

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
