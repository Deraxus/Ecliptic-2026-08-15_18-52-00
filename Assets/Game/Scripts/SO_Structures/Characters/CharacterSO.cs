using System.Collections.Generic;
using Ecliptic.Characters;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Scriptable Objects/Character")]
public class Character : ScriptableObject
{
    public string name;
    public List<Clothes> clothes = new List<Clothes>();
}
