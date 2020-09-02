using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerGame : MonoBehaviour
{
    public static bool isGameOver;
    public Text textScore;
    public Text textBest;


    private float score;
    private float best;


    public Text text;
    public GameObject panel;

    private void Start()
    {
        isGameOver = false;
        if (PlayerPrefs.HasKey("Record"))
        {
            best = PlayerPrefs.GetFloat("Record");
            textBest.text = "Best: " + (int)score;
        }
        else
        {
            best = 0;
            textBest.text = "Best: " + (int)score;
        }
    }
    
    private void Update()
    {
        if (!isGameOver)
        {
            score += Time.deltaTime;
            textScore.text = "Score: " + (int)score;
            if (score > best)
            {
                best = score;
            }
            textBest.text = "Best: " + (int)best;
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        PlayerPrefs.SetFloat("Record", best);
        text.gameObject.SetActive(true);
        panel.gameObject.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
