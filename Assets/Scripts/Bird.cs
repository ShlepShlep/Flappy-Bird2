using TMPro;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public int score;
    public float speed;
    public float jumpSpeed;
    public float rotateScale;
    public TMP_Text scoreText;
    public GameObject endScreen;
    Rigidbody2D rb;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Pipe.speed = speed;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            rb.velocity = Vector2.up * jumpSpeed;
        }

        transform.eulerAngles = new Vector3(0, 0, rb.velocity.y * rotateScale);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Die();
    }


    void Die()
    {
        Pipe.speed = 0;
        jumpSpeed = 0;
        Invoke("ShowMenu",1f); // calls function after 1 second
        //var currentScene = SceneManager.GetActiveScene().name;
        //SceneManager.LoadScene(currentScene);
    }

    void ShowMenu()
    {
        endScreen.SetActive(true);
        scoreText.gameObject.SetActive(false); // or scoreText.enabled = false; or scoreText.text = "";
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        score++;
        scoreText.text = score.ToString();
    }
}