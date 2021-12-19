using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    [SerializeField]
    private Text enemyKillCountTxt;

    private int enemyKillCount;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void EnemyKilled()
    {
        enemyKillCount++;
        enemyKillCountTxt.text = "Enemy Killed: " + enemyKillCount;
    }

    public void RestartGame()
    {
        Invoke("Restart", 3f);
    }

    void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
}
