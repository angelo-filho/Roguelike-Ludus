using UnityEngine;

public class Enemy : MonoBehaviour, Entity
{
    [SerializeField] protected float speed;
    [SerializeField] protected float maxHealth;
    [SerializeField] protected float damage;
    [SerializeField] protected float attackDelay;
    protected float attackDelayTimer;

    protected Transform Player;
    protected Rigidbody2D rb2d;
    protected Animator animator;
    private float m_CurrentHealth;
    
    private AnimNames m_CurrentAnimation;

    protected virtual void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag(Tags.Player.ToString()).transform;

        m_CurrentAnimation = AnimNames.WalkingDown;
        
        m_CurrentHealth = maxHealth;
    }

    protected virtual void FixedUpdate()
    {
        AnimateEnemy();
    }

    private void AnimateEnemy()
    {
        if (Mathf.Abs(rb2d.velocity.x) > Mathf.Abs(rb2d.velocity.y))
        {
            if (rb2d.velocity.x > 0.1f)
            {
                ChangeAnimation(AnimNames.WalkingRight);
            }
            else if (rb2d.velocity.x < 0.1f)
            {
                ChangeAnimation(AnimNames.WalkingLeft);
            }
        }
        else
        {
            if (rb2d.velocity.y > 0.1f)
            {
                ChangeAnimation(AnimNames.WalkingUp);
            }
            else if (rb2d.velocity.y < 0.1f)
            {
                ChangeAnimation(AnimNames.WalkingDown);
            }
        }
    }

    private void ChangeAnimation(AnimNames newAnimation)
    {
        if (newAnimation == m_CurrentAnimation) return;

        m_CurrentAnimation = newAnimation;
        animator.Play(m_CurrentAnimation.ToString());
    }

    public virtual void ReceiveHit(float _damage)
    {
        m_CurrentHealth -= _damage;

        if (m_CurrentHealth <= 0)
        {
            StartDeath();
        }
    }

    public virtual void StartDeath()
    {
        Destroy(gameObject);
    }
}
