using System;
using System.Collections.Generic;
using UnityEngine;

namespace Ecliptic.Stats
{
    public class StatManager : MonoBehaviour
    {
        [Tooltip("Сюда загружаем все существующие в игре статы")]
        public List<Stat> allStats = new List<Stat>();
        
        public Dictionary<Stat, int> stats = new Dictionary<Stat, int>();

        public void Start()
        {
            Initialize();
        }

        public void Initialize()
        {
            foreach (Stat stat in allStats)
            {
                stats.Add(stat, 0);
            }
        }
    }
    
}
