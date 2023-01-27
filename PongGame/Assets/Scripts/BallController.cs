using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public AudioSource audioSource;
    public ScoreWall scoreBoard;
    public Rigidbody2D rb;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        startGame();
    }

    void startGame(){
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(x*speed, y*speed);
    }
    
    public void resetBall(){
        rb.velocity = new Vector2(0,0);
        rb.transform.position = new Vector2(0,0);
        Invoke("startGame",0.1f);
    }
    
}
