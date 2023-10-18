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
    public GameObject background0;
    public GameObject background1;
    public GameObject bird0;
    public GameObject bird1;
    public GameObject bird2;
    Rigidbody2D rb;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Pipe.speed = speed;


        ChangeWallpaper();
        ChooseSkin();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            rb.velocity = Vector2.up * jumpSpeed;
        }

        transform.eulerAngles = new Vector3(0, 0, rb.velocity.y * rotateScale);
    }

    void ChooseSkin()
    {
        int randomBird = Random.Range(0, 3);
        print("Bird " + randomBird);

        if (randomBird == 0)
        {
            bird0.SetActive(true);
            bird1.SetActive(false);
            bird2.SetActive(false);
        }
        else if (randomBird == 1)
        {
            bird0.SetActive(false);
            bird1.SetActive(true);
            bird2.SetActive(false);
        }
        else
        {
            bird0.SetActive(false);
            bird1.SetActive(false);
            bird2.SetActive(true);
        }
    }

    void ChangeWallpaper()
    {
        int randomWall = Random.Range(0, 2);
        print("Wall " + randomWall);

        if (randomWall == 0)
        {
            background0.SetActive(true);
            background1.SetActive(false);
        }
        if (randomWall == 1)
        {
            background0.SetActive(false);
            background1.SetActive(true);
        }
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