using UnityEngine;

public class CircleParametr : MonoBehaviour
{
    public float timeLife = 5.5f;
    public float speed;

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, -timeLife), speed * Time.deltaTime);
        if (transform.position.y <= -timeLife)
        {
            Destroy(gameObject);
        }
    }
}
