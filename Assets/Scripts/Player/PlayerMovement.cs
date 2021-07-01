using UnityEngine;

public class PlayerMovement : Player
{
    [SerializeField] private float speed;

    private InputActions m_InputActions;
    private Vector2 m_Direction;
    
    
    protected override void Awake()
    {
        base.Awake();
        
        m_InputActions = new InputActions();

        m_InputActions.Player.Movements.performed += ctx => m_Direction = ctx.ReadValue<Vector2>();
        m_InputActions.Player.Movements.canceled += _ => m_Direction = Vector2.zero;
    }

    private void OnEnable() => m_InputActions.Enable();

    private void OnDisable() => m_InputActions.Disable();
    
    
    void FixedUpdate()
    {
        m_Rb.velocity = m_Direction * speed;
    }

}
