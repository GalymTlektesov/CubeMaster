using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public ManagerGame manager;
    public ParticleSystem deathEffect;
    public static int Health;
    public Text textHealth;

    private void Start()
    {
        Health = 1;
        textHealth.text = Health.ToString();
    }

    private void OnMouseDrag()
    {
        if (Input.GetMouseButton(0) && !ManagerGame.isGameOver)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Limit
            mousePos.x = mousePos.x > 2.55f ? 2.55f : mousePos.x;
            mousePos.x = mousePos.x < -2.55f ? -2.55f : mousePos.x;
            mousePos.y = mousePos.y > -1.45f ? -1.45f : mousePos.y;
            mousePos.y = mousePos.y < -4.53f ? -4.53f : mousePos.y;
            //Limit

            transform.position = Vector2.Lerp(transform.position, mousePos, speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<CircleHelth>() != null)
        {
            Health += 2;
            textHealth.text = Health.ToString();
        }
        if (other.GetComponent<CircleDown>() != null)
        {
            Health--;
            textHealth.text = Health.ToString();
            if (Health <= 0)
            {
                Instantiate(deathEffect, transform.position, Quaternion.Euler(90, 0, 0));
                manager.GameOver();
                Destroy(gameObject);
            }
        }
    }
}
