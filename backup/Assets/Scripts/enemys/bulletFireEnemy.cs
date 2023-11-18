using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletFireEnemy : MonoBehaviour
{
    public int damage;
    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerMoviment>().PlayerDamage(damage);
            Destroy(this.gameObject);
        }

    }

}
