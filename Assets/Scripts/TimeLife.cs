using UnityEngine;

public class TimeLife : MonoBehaviour
{
    public float timeLife;

    void Start()
    {
        Destroy(gameObject, timeLife);
    }
}
