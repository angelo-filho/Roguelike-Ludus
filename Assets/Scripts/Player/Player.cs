using UnityEngine;

public class Player : MonoBehaviour
{
    protected Rigidbody2D m_Rb;
    
    protected virtual void Awake()
    {
        m_Rb = GetComponent<Rigidbody2D>();
    }
}
