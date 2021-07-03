using UnityEngine;

public class PlayerHealth : Player, Entity
{
    [SerializeField] private float maxHealth;
    private float m_CurrentHealth;
    
    protected override void Awake()
    {
        base.Awake();
        
        m_CurrentHealth = maxHealth;
    }

    public void ReceiveHit(float _damage)
    {
        m_CurrentHealth -= _damage;

        if (m_CurrentHealth <= 0)
        {
            StartDeath();
        }
    }

    public void StartDeath()
    {
        Destroy(gameObject);
    }
}
