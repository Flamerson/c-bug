using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSpace : MonoBehaviour
{
    public GameObject menu;
    public bool jaAtivo = false;

    private void Update() {
        
        if(Input.GetButton("Jump") && jaAtivo){
            menu.SetActive(false);
        }

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player") && !jaAtivo){
            jaAtivo = true;
            menu.SetActive(true);
        }
    }
}
