using System;
using System.Collections.Generic;
using UnityEngine;

public enum ClothesTypes
{
    BaseClothes,
    SetOfClothes1,
    SetOfClothes2,
    SetOfClothes3
}

[Serializable]
public class Clothes
{
    public ClothesTypes name;
    public List<Emotion> emotions;
}
