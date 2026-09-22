using System;
using System.Collections.Generic;
using Ecliptic.Stats;
using UnityEngine;
using UnityEngine.Serialization;

namespace Ecliptic.Story
{
    
    [Serializable]
    public class StoryChoice
    {
        public string choiceText;
        
        [FormerlySerializedAs("statChangings")] public List<StatChanging> statChanging = new List<StatChanging>();
        public List<StatRequired> statRequired = new List<StatRequired>();
        public StoryFrame[] storyFrames;
    }
    
}
