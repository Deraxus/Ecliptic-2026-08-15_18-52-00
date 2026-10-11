using TMPro;
using UnityEngine;

namespace Ecliptic.UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;

        public TMP_Text currentFrameIdText;
        
        public void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public void Initialize()
        {
            
        }

        public void ChangeFrameIDText(int newFrameID)
        {
            currentFrameIdText.text = newFrameID.ToString();
        }

    }
    
}
