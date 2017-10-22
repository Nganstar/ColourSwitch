using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player : MonoBehaviour {
    public string currentColour;
    public float jumpForce = 5f;
    public Rigidbody2D circle;
    public SpriteRenderer sr;
    public GameObject obstacle;
    public GameObject colorChanger;
    public Color blue;
    public Color yellow;
    public Color pink;
    public Color purple;
    public static int score = 0;
    public Text scoreText;
	// Use this for initialization
	void Start () {
        setRandomColour();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            circle.velocity = Vector2.up * jumpForce;
        }
        scoreText.text = score.ToString();
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "scored")
        {
            score++;
            Destroy(collision.gameObject);
            Instantiate(obstacle, new Vector2(transform.position.x, transform.position.y + 7f), transform.rotation);
            return;
        }
        if (collision.tag == "ColorChanger")
        {
            setRandomColour();
            Destroy(collision.gameObject);
            Instantiate(colorChanger, new Vector2(transform.position.x, transform.position.y + 7f), transform.rotation);
            return;
        }
        if(collision.tag != currentColour)
        {
            Debug.Log("You died!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            score = 0;
        }
    }
    void setRandomColour()
    {
        int rand = Random.Range(0, 4);
        switch (rand)
        {
            case 0:
                currentColour = "Teal";
                sr.color = blue;
                break;
            case 1:
                currentColour = "Yellow";
                sr.color = yellow;
                break;
            case 2:
                currentColour = "Pink";
                sr.color = pink;
                break;
            case 3:
                currentColour = "Purple";
                sr.color = purple;
                break;

        }
    }
}
