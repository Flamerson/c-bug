using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInteration : MonoBehaviour
{
    public GameObject menu;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            menu.SetActive(false);
        }
    }
}
