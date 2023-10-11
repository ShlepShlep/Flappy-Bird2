using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float speed;
    public float screenStartX;
    public float screenEndX;
    void Start()
    {
        screenStartX = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0.5f)).x - 1;
        screenEndX =  Camera.main.ViewportToWorldPoint(new Vector3(1f, 0.5f)).x + 1;
    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < screenStartX)
        {
            var height = Random.Range(-2, 4);
            transform.position = new Vector3(screenEndX,height);
        }
    }
}