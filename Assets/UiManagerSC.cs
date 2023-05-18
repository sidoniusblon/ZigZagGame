using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UiManagerSC : MonoBehaviour
{
    public static UiManagerSC Instance;
    public GameObject startPanel,restartPanel;
    public static bool isRestarted;
    [SerializeField] TextMeshProUGUI bestScore,bestScore2;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else Destroy(this);
    }
    private void Start()
    {
        bestScore.text ="Best Score: " +PlayerPrefs.GetInt("BestScore").ToString();
        if (isRestarted) startPanel.SetActive(false);
        
    }
    public void startGame()
    {
         
        startPanel.SetActive(false);
        PlayerController.isdead = false;
    }
    public void restartGame()
    {
        isRestarted = true;
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
     
    }
    public void bestScoreShow()
    {
        bestScore2.text = "Best Score: " + PlayerPrefs.GetInt("BestScore").ToString();
    }
}
