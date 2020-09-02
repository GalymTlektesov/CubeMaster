using UnityEngine;

public class CircleDown : MonoBehaviour
{
    public ParticleSystem deathCircle;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            Instantiate(deathCircle, transform.position, Quaternion.Euler(90, 0, 0));
            Destroy(gameObject);
        }
    }
}
