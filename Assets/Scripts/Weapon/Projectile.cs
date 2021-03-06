using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;
    [SerializeField] private float damage;

    private IEnumerator projectileCoroutine;
    
    void Update()
    {
        transform.Translate(Vector2.up * (speed * Time.deltaTime));
    }

    public void DeactiveProjectile()
    {
        if (projectileCoroutine != null)
        {
            StopCoroutine(projectileCoroutine);
        }

        projectileCoroutine = DeactiveInTime();
        StartCoroutine(projectileCoroutine);
    }

    IEnumerator DeactiveInTime()
    {
        yield return new WaitForSeconds(lifeTime);  
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Tags.Enemy.ToString()))
        {
            other.GetComponent<Enemy>().ReceiveHit(damage);
            gameObject.SetActive(false);
        }
    }
}
