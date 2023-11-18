using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropItens : MonoBehaviour
{

    public bool Fire1;
    public bool Fire2;
    public bool Gun;
    public AudioSource audio1;
    
    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.gameObject.CompareTag("Player"))
        {
            if(Gun)
            {
                other.gameObject.GetComponent<PlayerCombat>().gun = true;
            }
            if(Fire1)
            {
                other.gameObject.GetComponent<PlayerCombat>().fireOne = true;
            }
            if(Fire2)
            {
                other.gameObject.GetComponent<PlayerCombat>().fireTwo = true;
            }
            audio1.Play();
            Destroy(this.gameObject);
        }

    }

}
