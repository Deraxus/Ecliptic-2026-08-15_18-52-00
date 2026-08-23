using UnityEngine;

namespace Ecliptic.Backgrounds
{
    [CreateAssetMenu(fileName = "Background", menuName = "Backgrounds/Background")]
    public class Background : ScriptableObject
    {
        public string backgroundName;
        public Sprite backgroundSprite;
        
    }    
}

