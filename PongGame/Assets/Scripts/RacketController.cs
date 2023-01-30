using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RacketController : MonoBehaviourPunCallbacks
{
    public PhotonView pw;
    TMPro.TMP_Text txt;
    public Rigidbody2D rb;

    void Start()
    {
        pw = GetComponent<PhotonView>();
            if(pw.IsMine){
                
                SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
                rb = GetComponent<Rigidbody2D>();
                if (PhotonNetwork.IsMasterClient)
                {
                    transform.position = new Vector2(8,0);
                }
                else if (!PhotonNetwork.IsMasterClient)
                {
                    renderer.color =  Color.red;
                    transform.position = new Vector2(-8,0);
                    InvokeRepeating("playerControl",0,0.5f);
                }
            }
    }

    void playerControl()
    {
        if (PhotonNetwork.PlayerList.Length==2)
        {
            GameObject.Find("Ball").GetComponent<PhotonView>().RPC("basla",RpcTarget.All,null);
            CancelInvoke("playerControl");

        }
    }

    void Update()
    {
        if (pw.IsMine)
        {
            move();
        }
        
    }

    void move(){
        float vertical_ = Input.GetAxis("Mouse Y")* Time.deltaTime * 5;
        transform.Translate(0,vertical_,0);

       /* foreach (Touch touch in Input.touches)
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            Vector2 myPosition = rb.position;
            myPosition.y = Mathf.Lerp(myPosition.y, touchPosition.y,10);
            rb.position = myPosition;

        }*/
    }
}
