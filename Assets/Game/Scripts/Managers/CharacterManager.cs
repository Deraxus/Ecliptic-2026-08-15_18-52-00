using UnityEngine;
using UnityEngine.UI;

namespace Ecliptic.Characters
{
    public enum Sides
    {
        Left,
        Centre,
        Right
    }

    public class CharacterManager : MonoBehaviour
    {
        public static CharacterManager Instance;
    
        public Image leftCharacterImage;
        public Image rightCharacterImage;

        public Character currentLeftCharacter;
        public Character currentRightCharacter;
    
        public void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public void HideCharacters(Sides side = default)
        {
            switch (side)
            {
                case Sides.Left:
                    leftCharacterImage.sprite = null;
                    leftCharacterImage.gameObject.SetActive(false);
                    break;
                case Sides.Right:
                    rightCharacterImage.sprite = null;
                    rightCharacterImage.gameObject.SetActive(false);
                    break;
                default:
                    leftCharacterImage.sprite = null;
                    rightCharacterImage.sprite = null;
                
                    leftCharacterImage.gameObject.SetActive(false);
                    rightCharacterImage.gameObject.SetActive(false);
                    break;
            }
            
            
            
        }

        public void ShowCharacters()
        {
            leftCharacterImage.gameObject.SetActive(true);
            rightCharacterImage.gameObject.SetActive(true);
        }

        public void DisplayCharacter(Character character,
            Sides side,
            ClothesTypes clothesType = ClothesTypes.BaseClothes,
            Emotions emotion = Emotions.Idle)
        {
            Sprite newCharacterSprite;
            if (clothesType == ClothesTypes.BaseClothes && emotion == Emotions.Idle)
            {
                newCharacterSprite = GetDefaultCharacterSprite(character);
            }
            else
            {
                newCharacterSprite = character.GetSprite(clothesType, emotion);
            }
            
            ShowCharacters();
            
            switch (side)
            {
                case Sides.Left:
                    HideCharacters(Sides.Right);
                    currentLeftCharacter = character;
                    leftCharacterImage.sprite = newCharacterSprite;
                    break;
                
                case Sides.Right:
                    HideCharacters(Sides.Left);
                    currentRightCharacter = character;
                    rightCharacterImage.sprite = newCharacterSprite;
                    break;
            }
        }

        private Sprite GetDefaultCharacterSprite(Character character)
        {
            Sprite defaultCharacterSprite = character.GetSprite(ClothesTypes.BaseClothes, Emotions.Idle);

            if (defaultCharacterSprite == null)
            {
                Debug.LogError("Base clothes hasn't been found!");
                return null;
            }

            return defaultCharacterSprite;
        }
    }
   
}