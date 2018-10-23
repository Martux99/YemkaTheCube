using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Transform player;
    public Text scoreText;
    public bool ArcadeFire;
    public GameManager gameManager;

	// Update is called once per frame
	void Update () {
        if (ArcadeFire)
        {
            scoreText.text = (player.position.z.ToString("0"));
        }
        else
        {
            scoreText.text = (PlayerPrefs.GetInt("L1").ToString("0"));
        }

	}
}
