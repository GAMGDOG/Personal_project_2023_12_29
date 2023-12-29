using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySO", menuName = "Character/Enemy")]

public class EnemySO : ScriptableObject
{
    [field: SerializeField] public float PlayerChasingRange { get; private set; } = 20f;
    [field: SerializeField] public float AttackRange { get; private set; } = 1f;

    [field: SerializeField] public PlayerGroundData GroundData { get; private set; }
}
