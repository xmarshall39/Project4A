using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienC : MonoBehaviour
{

    public float attackDelay = 3f;
    public Projectile acid_drop;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
        animator = GetComponent<Animator>();
        if (attackDelay > 0)
        {
            StartCoroutine(OnAttack());
            
        }
    }
    private void Update()
    {
        animator.SetInteger("AnimState", 0);
    }

    IEnumerator OnAttack()
    {
        
        yield return new WaitForSeconds(attackDelay);
        Fire();
        StartCoroutine(OnAttack());
    }

    void Fire()
    {
        animator.SetInteger("AnimState", 1);
    }

    void onShoot()
    {
        print("Called onShoot");
        if (acid_drop) { 
            Projectile clone = Instantiate(acid_drop, transform.position,
                                Quaternion.identity) as Projectile;
        }
    }
}
