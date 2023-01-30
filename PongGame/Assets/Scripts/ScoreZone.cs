using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ScoreZone : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.GetComponent<BallController>().pw.IsMine)
        {
            score ++;
            scoreText.text = score.ToString();
            col.gameObject.GetComponent<BallController>().resetBall(); 
        }
        
    }
}
