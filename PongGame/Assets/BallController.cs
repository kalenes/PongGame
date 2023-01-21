using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
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
    IEnumerator restartBall(){
        rb.velocity = new Vector2(0,0);
        rb.transform.position = new Vector2(0,0);
        yield return new WaitForSeconds (0.1f);
        startGame();
    }
    void OnCollisionEnter2D(Collision2D denetle) {
        if (denetle.gameObject.name == "redwall")
        {
            Debug.Log ("kırmızı duvar");
            scoreBoard.BluePlayerGoal();
            StartCoroutine(restartBall());
        }
        else if(denetle.gameObject.name == "bluewall"){
            Debug.Log ("mavi duvar");
            scoreBoard.RedPlayerGoal();
            StartCoroutine(restartBall());

        }
    }
}
