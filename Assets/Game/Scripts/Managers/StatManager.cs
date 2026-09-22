using System;
using System.Collections.Generic;
using UnityEngine;

namespace Ecliptic.Stats
{
    public class StatManager : MonoBehaviour
    {
        public static StatManager Instance;
        
        [Tooltip("Сюда загружаем все существующие в игре статы")]
        public List<Stat> allStats = new List<Stat>();
        
        public Dictionary<Stat, int> stats = new Dictionary<Stat, int>();

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

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
        
        // Проверка на то, что у игрока достаточное количество статов набрано
        public bool HasEnoughStat(Stat requiredStat, int requiredAmount)
        {
            if (stats[requiredStat] >= requiredAmount)
            {
                return true;
            }
            
            return false;
        }

        public void AddStat(Stat stat, int amount)
        {
            stats[stat] += amount;
            // Проигрываем звук
            // Показываем на экране что статы выданы
        }
    }
    
}
