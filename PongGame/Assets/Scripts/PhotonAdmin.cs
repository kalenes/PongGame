using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class PhotonAdmin : MonoBehaviourPunCallbacks
{
    void Start()
    {
        if (PhotonNetwork.PlayerList.Length==2)
        {
            GameObject new_player = PhotonNetwork.Instantiate("Racket",new Vector2(-8,0),Quaternion.identity, 0);

        }
        
    }
   
}
