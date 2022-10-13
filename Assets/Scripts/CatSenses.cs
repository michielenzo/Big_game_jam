using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CatSenses", menuName = "ScriptableObjects/CatSenses", order = 1)]
public class CatSenses : ScriptableObject
{
    public enum Level
    {
        Low,
        Medium,
        High
    }

    public float proximityToExitPercentage;
    public Level enemyPresence;
}
