using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Levels : MonoBehaviour
{
    public static bool startLevel;
    public static int level, enemiesKilled, enemiesKilledTotal;
    public static float timer;
    [SerializeField] private TMP_Text levelTMP, enemiesKilledTMP, vidaTMP, timeTMP;
    void Start()
    {
        timer = 0;
        level = 0;
        enemiesKilled = 0;
        enemiesKilledTotal = 0;
        ChangeLevelTMP();
    }

    void Update()
    {
        timer += Time.deltaTime;
        ChangeLevelTMP();
        if(level >= 6)
        {
            SceneManager.LoadScene("VictoryMenu");
        }
    }

    void ChangeLevelTMP()
    {
        Debug.Log(level);
        levelTMP.text = $"Nivel {level}";
        enemiesKilledTMP.text = $"{enemiesKilledTotal}";
        vidaTMP.text = $"Vida {PlayerLife.life}";
        timeTMP.text = $"Tiempo {timer}";
    }
}
