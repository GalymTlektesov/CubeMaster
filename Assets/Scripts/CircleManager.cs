using UnityEngine;

public class CircleManager : MonoBehaviour
{
    public CircleParametr[] circle;
    public float[] delay;
    public float[] next;

    private void Start()
    {
        next = new float[delay.Length];
        for (int i = 0; i < next.Length; i++)
        {
            next[i] = Time.time + delay[i];
        }
    }

    void Update()
    {
        int rnd = Random.Range(0, 10);

        CircleInstate(0, circle[0], Quaternion.identity, Random.Range(-2.7f, 2.7f));
        if (rnd % 2 == 0)
        {
            CircleInstate(1, circle[1], Quaternion.identity, -1.0f);
            CircleInstate(2, circle[2], Quaternion.identity, -1.4f);
            CircleInstate(3, circle[3], Quaternion.identity, -1.15f);
            CircleInstate(4, circle[4], Quaternion.Euler(0, 0, 0), 0);
        }
        else
        {
            CircleInstate(1, circle[1], Quaternion.identity, 1.4f);
            CircleInstate(2, circle[2], Quaternion.identity, 2.2f);
            CircleInstate(3, circle[3], Quaternion.identity, -0.2f);
            CircleInstate(4, circle[4], Quaternion.Euler(0, 180, 0), 0);
        }

        CircleInstate(5, circle[5], Quaternion.identity, Random.Range(-2.7f, 2.7f));
    }

    private void CircleInstate(int i, CircleParametr circleDown, Quaternion quaternion, float x)
    {
        if (Time.time > next[i])
        {
            CircleParametr circledown = Instantiate(circleDown.GetComponent<CircleParametr>(), new Vector2(x, 5.4f), quaternion);
            circledown.speed = Random.Range(2, 5);
            next[i] = Time.time + delay[i];
        }
    }
}
