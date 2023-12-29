using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [field: Header("References")]
    [field: SerializeField] public PlayerSO Data { get; private set; }
    public Rigidbody Rigidbody { get; private set; }
    public PlayerInput Input { get; private set; }
    public CharacterController Controller { get; private set; }
    public Health health { get; private set; }
    public TextMeshProUGUI timeText;
    private PlayerStateMachine stateMachine;
    private void Awake()
    { 
        Rigidbody = GetComponent<Rigidbody>();
        Input = GetComponent<PlayerInput>();
        Controller = GetComponent<CharacterController>();
        health = GetComponent<Health>();
        timeText.text = "0.00";

        stateMachine = new PlayerStateMachine(this);
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        stateMachine.ChangeState(stateMachine.IdleState);

        health.OnDie += OnDie;
    }

    private void Update()
    {
        stateMachine.HandleInput();
        stateMachine.Update();
        if (transform.position.y > 9)
        {
            Debug.Log("클리어");
            enabled = false;
        }
        else
        {
            float time = Time.time;
            timeText.text = string.Format("{0:N2}", time);
        }
    }
    private void FixedUpdate()
    {
        stateMachine.PhysicsUpdate();
    }

    private void OnDie()
    {
        Debug.Log("죽음");
        //게임오버 UI 팝업
        enabled = false;
    }
}
