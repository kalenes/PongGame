using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Ball : MonoBehaviourPunCallbacks
{
    Rigidbody2D rb;
    PhotonView pw;
    public AudioSource sound;
    
    int player1_skor =0;
    int player2_skor =0;

    public float speed = 1;

    public TMPro.TMP_Text player1_txt;
    public TMPro.TMP_Text player2_txt;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pw = GetComponent<PhotonView>();
    }


    [PunRPC]
    public void basla()
    {
        rb.velocity = new Vector2(5*speed, 5*speed);
        skor_goster();
    }
    
    public void skor_goster()
    {
        player1_txt.text = PhotonNetwork.PlayerList[0].NickName + ": " + player1_skor.ToString();
        player2_txt.text = PhotonNetwork.PlayerList[1].NickName + ": " + player2_skor.ToString();
    }

    private void OnCollisionEnter2D(Collision2D col){
        if(pw.IsMine)
        {
            if (PhotonNetwork.PlayerList.Length == 1)
            {
            PhotonNetwork.LeaveRoom();
            SceneManager.LoadScene("Lobby");
            }
            sound.Play();
            if (col.gameObject.name == "bluewall")
            {
                pw.RPC("gol", RpcTarget.All, 0, 1);
            }
            else if (col.gameObject.name == "redwall")
            {
                pw.RPC("gol", RpcTarget.All, 1, 0);
            }
        }
    }


    [PunRPC]
    public void gol(int playerOne, int playerTwo)
    {
        
        player1_skor += playerOne;
        player2_skor += playerTwo;

        skor_goster();
        servis();
    }

    public void servis()
    {
        
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        rb.velocity = new Vector2(5*speed, 5*speed);
    }
}
