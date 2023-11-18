using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMov : MonoBehaviour
{
    public GameObject Personagem;
    public float altura;
    void Update()
    {
        float x = Personagem.transform.position.x - transform.position.x;
        float z = Personagem.transform.position.z - 7.5f - transform.position.z;
        float y = Personagem.transform.position.y - transform.position.y;
        transform.Translate(x , y * Time.deltaTime, z * Time.deltaTime);
    }
}
