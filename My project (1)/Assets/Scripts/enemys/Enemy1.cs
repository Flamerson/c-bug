using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy1 : MonoBehaviour
{
    public int maxLife = 100;
    public int currentLife;
    public int enemyDamage = 10;
    public float maxVelocity = 5.5f;
    Vector2 velocity;
    bool lado;
    public Transform player;
    public LayerMask playerLayer;
    public Transform enemyCollisor;
    public float enemyRange = 0.2f;
    bool colissorPlayerCheck = false;
    public int face = 1;
    public Transform faceCheck;
    public LayerMask enemyCheckFace;
    float faceRange = 0.2f;
    bool colissorEnemyFace = false;
    public GameObject arma;
    public bool dropaArma;
    public bool enemyFlip;
    public GameObject nextFase;
    public Text bossLife;

    // Start is called before the first frame update
    void Start()
    {
        currentLife = maxLife;
    }

    void FixedUpdate()
    {

        if(bossLife && currentLife >= 0){
            bossLife.text = "" + currentLife;
        }else{
            bossLife.text = "0";
        }

        colissorPlayerCheck = Physics2D.OverlapCircle(enemyCollisor.position,enemyRange , playerLayer);

        if(colissorPlayerCheck && currentLife > 0)
        {
            
            if(!player.GetComponent<PlayerMoviment>().imortal){
                player.GetComponent<PlayerMoviment>().PlayerDamage(enemyDamage);
            }
        }

        move();

        if(currentLife <= 0){
            Die();
        }

    }

    void move()
    {
        if(currentLife > 0){

            velocity = new Vector2 (face * maxVelocity, GetComponent<Rigidbody2D>().velocity.y);

            GetComponent<Rigidbody2D>().velocity = velocity;

            colissorEnemyFace = Physics2D.OverlapCircle(faceCheck.position, faceRange, enemyCheckFace);

            if(colissorEnemyFace && face == 1)
            {
                face = -1;

                flip();
                
            }else if(colissorEnemyFace && face == -1){
                face = 1;

                flip();
            }
        }
    }

    public void TakeDamage(int damage)
    {  
        
        if(currentLife > 0){

            currentLife -= damage;

            lado = player.GetComponent<PlayerMoviment>().ladoDireito;

            if(lado){
                if(face == -1){
                    face = 1;
                    flip();
                }
                if(enemyFlip){
                    GetComponent<Rigidbody2D>().AddForce (new Vector2 (250, 250));
                }
            }else{
                if(face == 1){
                    face = -1;
                    flip();
                }
                if(enemyFlip){
                    GetComponent<Rigidbody2D>().AddForce (new Vector2 (-250, 250));
                }
            }

        }
    }

   void Die()
   {
        if(dropaArma){
            GameObject temp = Instantiate(arma);
            temp.transform.position = this.gameObject.transform.position;
            Destroy(this.gameObject);
            nextFase.SetActive(true);
        }else{
            Destroy(this.gameObject);
        }
   }

   void flip()
   {
        if(enemyFlip)
        {
            Vector2 novoScale = new Vector2 (transform.localScale.x * -1, transform.localScale.y);
            transform.localScale = novoScale;
        }

   }

   void OnDrawGizmosSelected() {
        if(enemyCollisor == null){
            return;
        }

        Gizmos.DrawWireSphere(enemyCollisor.position, enemyRange);

        if(faceCheck == null){
            return;
        }

        Gizmos.DrawWireSphere(faceCheck.position, faceRange);

    }

}
