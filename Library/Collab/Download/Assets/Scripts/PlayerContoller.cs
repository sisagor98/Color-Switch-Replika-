using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerContoller : MonoBehaviour
{
    public Rigidbody2D rb;

    public float jumpSpeed = 8f;
    public SpriteRenderer spriteRenderer;
    public string cureentColor;


    public Color colorRed;
    public Color colorPink;
    public Color colorYellow;
    public Color colorBlue;

    private int score = 0;

    private bool isGameStart = false;
    private bool startSpawn = false;

    public Text scoreText;
    //public Text highScore;

    void Start()
    {
        SetRandomColor();
        rb.isKinematic = true;
      //  highScore.text =PlayerPrefs.GetInt("HighScore",0).ToString();


    }

    private void Update()
    {
        if (Input.GetMouseButton(0) || Input.GetButtonDown("Jump"))
        {
            isGameStart = true;
            rb.isKinematic = false;
        }

        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpSpeed;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != cureentColor && other.tag != "ccl")
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (other.tag == cureentColor)
        {

            startSpawn = true;
            if (startSpawn)
            {

                FindObjectOfType<Sponwner>().SpawnColorSwitch();
                FindObjectOfType<Sponwner>().Spawn();
            }

            StartCoroutine(DestroyColorPrefab()){
            score = score + 2;
            //highScore=score;
            scoreText.text= score.ToString();

            if(score > PlayerPrefs.GetInt("HighScore",0)){
                PlayerPrefs.SetInt("HighScore",score);
                highScore.text = score.ToString();     
             Debug.Log(score);

             }
            }
        if (other.tag == "ccl")
        {
            SetRandomColor();
            Destroy(other.gameObject);
            return;
        }


    }

    void SetRandomColor()
    {

        int index = Random.Range(0, 4);

        switch (index)
        {
            case 0:
                cureentColor = "blue";
                spriteRenderer.color = colorBlue;
                break;
            case 1:
                cureentColor = "red";
                spriteRenderer.color = colorRed;
                break;
            case 2:
                cureentColor = "pink";
                spriteRenderer.color = colorPink;
                break;
            case 3:
                cureentColor = "Yellow";
                spriteRenderer.color = colorYellow;
                break;
        }
    }

    IEnumerator DestroyColorPrefab()
    {
        yield return new WaitForSeconds(5.0f);
    }

}
