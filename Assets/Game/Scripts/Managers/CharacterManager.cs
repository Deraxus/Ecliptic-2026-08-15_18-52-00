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
    }
   
}