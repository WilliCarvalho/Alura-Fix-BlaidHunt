using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class BaseEnemy : MonoBehaviour
{
    protected Animator animator;
    protected Health health;

    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
        health = GetComponent<Health>();

        health.OnDead += HandleDeath;
    }

    protected abstract void Update();
    
    private void HandleDeath()
    {
        //TODO: tocar animação de morte
        StartCoroutine(DestroyEnemy(2));
    }

    private IEnumerator DestroyEnemy(int time)
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }
}
