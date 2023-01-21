using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreWall : MonoBehaviour
{
    public Text bluetext;
    public Text redtext;
    
    [SerializeField] 
    private int bluescore=0;
    [SerializeField] 
    private int redscore=0;
    

    public void RedPlayerGoal(){
        redscore ++;
        redtext.text = redscore.ToString();
    }
    public void BluePlayerGoal(){
        bluescore ++;
        bluetext.text = bluescore.ToString();
    }
}
