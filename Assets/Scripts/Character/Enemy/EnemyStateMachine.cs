using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : StateMachine
{
    public Enemy Enemy { get; }
    public Health Target { get; private set; }
    public EnemyIdleState IdleState { get; }
    public EnemyChasingState ChasingState { get; }
    public Vector2 MovementInput { get; set; }
    public float MovementSpeed { get; private set; }
    public float RotationDamping { get; private set; }
    public float MovementSpeedModifier { get; set; } = 1f;

    public EnemyStateMachine(Enemy enemy)
    {
        Enemy = enemy;
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();

        IdleState = new EnemyIdleState(this);
        ChasingState = new EnemyChasingState(this);

        MovementSpeed = enemy.Data.GroundData.BaseSpeed;
        RotationDamping = enemy.Data.GroundData.BaseRotationDamping;

    }
}
