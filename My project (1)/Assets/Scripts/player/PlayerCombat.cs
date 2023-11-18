using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    
    public Animator animator;
    public LayerMask enemyLayer;
    public Transform punchDetect;
    public float punchRange = 0.5f;
    public int attackDamage = 20;
    private SpriteRenderer mainRenderer;
    public GameObject bullet;
    public int fireForce;
    public bool gun = false;
    public GameObject fireOneItem;
    public bool fireOne = false;
    public GameObject fireTwoItem;
    public bool fireTwo = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        mainRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.J))
        {
            PunchAnimation();
            Invoke("Punch", 0.4f);
        }

        if(Input.GetKeyDown(KeyCode.K) && gun)
        {
            Fire();
            animator.SetBool("fire", true);
            Invoke("FireFalse", 0.2f);
        }

        if(Input.GetKeyDown(KeyCode.L) && fireOne)
        {
            if(fireTwo){
                Invoke("PunchFire2", 0.3f);
                animator.SetBool("punch", true);
                Invoke("EndPunch", 0.3f);
                fireTwo = false;
                Invoke("FireReset", 2f);
            }else{
                Invoke("PunchFire1", 0.3f);
                animator.SetBool("punch", true);
                Invoke("EndPunch", 0.3f);
            }
        }

    }

    void FireReset()
    {
        fireTwo = true;
    }


    void FireFalse()
    {
        animator.SetBool("fire", false);
    }

    void Punch()
    {

        EndPunch();

        //punch attack in enemies
        Collider2D[] punchHitEnemies = Physics2D.OverlapCircleAll(punchDetect.position, punchRange, enemyLayer);

        foreach(Collider2D enemy in punchHitEnemies){
            enemy.GetComponent<Enemy1>().TakeDamage(attackDamage);
        }

    }

    void PunchAnimation()
    {
        
        animator.SetBool("punch", true);
        animator.SetBool("run", false);
        
    }

    void EndPunch()
    {
        animator.SetBool("punch", false);
    }

    void PunchFire1()
    {
        GameObject temp = Instantiate(fireOneItem);
        temp.transform.position = punchDetect.position;
        bool lado = this.gameObject.GetComponent<PlayerMoviment>().ladoDireito;
        if(lado){
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(fireForce, 0);
        }else{
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(-fireForce, 0);
        }
        Destroy(temp.gameObject, 3f);
    }

    void PunchFire2()
    {
        GameObject temp = Instantiate(fireTwoItem);
        temp.transform.position = punchDetect.position;
        bool lado = this.gameObject.GetComponent<PlayerMoviment>().ladoDireito;
        if(lado){
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(fireForce, 0);
        }else{
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(-fireForce, 0);
        }
        Destroy(temp.gameObject, 3f);
    }

    void Fire()
    {
        GameObject temp = Instantiate(bullet);
        temp.transform.position = punchDetect.position;
        bool lado = this.gameObject.GetComponent<PlayerMoviment>().ladoDireito;
        if(lado){
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(fireForce, 0);
        }else{
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(-fireForce, 0);
        }
        Destroy(temp.gameObject, 3f);
    }

    void OnDrawGizmosSelected() {
        if(punchDetect == null){
            return;
        }

        Gizmos.DrawWireSphere(punchDetect.position, punchRange);
    }
}
