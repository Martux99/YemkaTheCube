using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    bool gameHasEnded = false;
    public float restartDelay = 1f;
    public GameObject completeLevelUI;
    public int DeathCount = 0;
    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
    }
    private void Awake()
    {
        DeathCount = PlayerPrefs.GetInt("L1");
    }
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GameOver");
            DeathCount++;
            Invoke("Restart",restartDelay);
               
        }
       
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        PlayerPrefs.SetInt("L1", DeathCount);
    }
}
