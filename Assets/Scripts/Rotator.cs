using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speed = 100f;
    void Update() {
        transform.Rotate( 0f, 0f, speed*Time.deltaTime);
    }

 
}


//    score = score + 2;
//             //highScore=score;
//             scoreText.text= score.ToString();
//             if(score < PlayerPrefs.GetInt("HighScore",0)){
//                 PlayerPrefs.SetInt("HighScore",score);
//                 highScore.text = score.ToString();