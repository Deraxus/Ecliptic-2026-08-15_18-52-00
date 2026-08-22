using System.Collections.Generic;
using Ecliptic.Characters;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Characters/Character")]
public class Character : ScriptableObject
{
    public string characterName;
    public List<Clothes> clothes = new List<Clothes>();
    
    public Sprite GetSprite(ClothesTypes clothesType, Emotions emotionType)
    {
        Clothes clothes = this.clothes.Find(
            item => item.name == clothesType
        );

        Emotion emotion = clothes.emotions.Find(
            item => item.emotion == emotionType
        );

        return emotion.sprite;
    }
}
