using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public GameObject ball;
    public Transform fireDetect;
    public int fireForce;
    public float timer;
    float resTime;

    private void Start() {
        resTime = timer;
    }

    private void FixedUpdate() 
    {
        
        if(resTime > 0){
            resTime -= Time.deltaTime;
        }else{
            resTime = timer;
            FireBall();
        }

    }

    void FireBall()
    {
        GameObject temp = Instantiate(ball);
        temp.transform.position = fireDetect.position;
        temp.GetComponent<Rigidbody2D>().velocity = new Vector2(-fireForce, 0);
        Destroy(temp.gameObject, 3f);        
    }


}
