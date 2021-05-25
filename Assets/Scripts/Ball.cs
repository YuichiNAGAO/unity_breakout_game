using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool isDead=false;
    public float speed=3.0f;
    public float accelSpeed=0.3f;
    bool isStart=false;
    public ScoreManager scoreManager;
    public AudioClip touchBlockSE;
    Rigidbody rb;
    AudioSource audioSource;


    // Start is called before the first frame update、スタート後一回だけ作動するプログラム
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        audioSource=GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart==false && Input.GetMouseButtonDown(0))
        {
            isStart=true;
            rb.AddForce(new Vector3(1,-1,0)*speed, ForceMode.VelocityChange);

        }
    }

    private void OnCollisionEnter(Collision collision){
        if (!isDead){
            if (collision.gameObject.CompareTag("Block"))
            {
                //audioCollision<AudioSource>().Play();
                scoreManager.AddScore();
                Destroy(collision.gameObject);
                audioSource.PlayOneShot(touchBlockSE);
            }

            if (collision.gameObject.name=="Bar")
            {
                scoreManager.ResetCombo();
                speed+=accelSpeed;
                Vector3 vec=transform.position-collision.transform.position;
                rb.velocity=Vector3.zero;
                rb.AddForce(vec.normalized*speed, ForceMode.VelocityChange);
            }
            

        }
        
        if (collision.gameObject.name=="Wall_Bottom")
        {
            isDead=true;
        }

        

        
    }

}
