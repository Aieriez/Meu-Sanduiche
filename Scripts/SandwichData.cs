using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="sandwich", menuName ="ScriptableObject/Sandwich")]
public class SandwichData : ScriptableObject
{
    public string[] ingredients;
    public Sprite[] sprites;
}
