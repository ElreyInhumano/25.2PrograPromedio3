using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MenuManager : MonoBehaviour
{
    [SerializeField] private TMP_Text levelTMP, timeTMP, enemiesTMP;
    public bool defeatScene;
    public void StartGame()
    {
        SceneManager.LoadScene("HelloCardboard");
    }
    public void BackToStart()
    {
        SceneManager.LoadScene("StartMenu");
    }
    public void Defeat()
    {
        SceneManager.LoadScene("DefeatMenu");
    }
    private void Start()
    {
        if (defeatScene)
        {
            ChangeTMPs();
        }
    }
    void ChangeTMPs()
    {
        levelTMP.text = $"Nivel {Levels.level}";
        enemiesTMP.text = $"Enemigos Eliminados {Levels.enemiesKilledTotal}";
        timeTMP.text = $"Tiempo Sobrevivido {Levels.timer}";
    }
}
