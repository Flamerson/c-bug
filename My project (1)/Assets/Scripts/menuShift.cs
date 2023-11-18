using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuShift : MonoBehaviour
{
    public GameObject menu;
    public bool jaAtivo = false;

    private void Update() {
        
        if(Input.GetKeyDown(KeyCode.LeftShift) && jaAtivo){
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
