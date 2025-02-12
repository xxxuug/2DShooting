using System.Collections;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public Canvas canvas;
    public GameObject poulpi;
    public Button RestartButton;
    public TMP_Text ScoreText;
    public GameObject Platforms;

    private int totScore = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        canvas.enabled = false;
    }

    void Start()
    {
        StartCoroutine(SpawnPoulpi());
        StartCoroutine(SpawnPlatforms1());
        StartCoroutine(SpawnPlatforms2());
        RestartButton.onClick.AddListener(onClickRestartButton);

        Score(0);
    }

    IEnumerator SpawnPoulpi()
    {
        yield return new WaitForSeconds(2f);
        float posY = Random.Range(3f, -3f);
        Instantiate(poulpi, new Vector3(11, posY, 0), Quaternion.identity);
        StartCoroutine(SpawnPoulpi());
    }

    IEnumerator SpawnPlatforms1()
    {
        yield return new WaitForSeconds(7f);
        float posY = Random.Range(3.5f, 0f);
        Instantiate(Platforms, new Vector3(11, posY, 0), Quaternion.identity);
        StartCoroutine(SpawnPlatforms1());
    }

    IEnumerator SpawnPlatforms2()
    {
        yield return new WaitForSeconds(7f);
        float posY = Random.Range(-1f, -4.5f);
        Instantiate(Platforms, new Vector3(15, posY, 0), Quaternion.identity);
        StartCoroutine(SpawnPlatforms2());
    }

    void onClickRestartButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    public void Score(int score)
    {
        totScore += score;
        ScoreText.text = $"Score : {totScore}";
    }
}
