using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	public GameObject gameOver;
    public static UIManager instance;
	public TextMeshProUGUI winLoseText;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		} else
		{
			Destroy(gameObject);
		}
	}

	private void Start()
	{
		gameOver.SetActive(false);
	}

	public void ShowGameOver(bool isWin)
	{
		winLoseText.text = isWin ? "YOU WON!!!" : "YOU LOST!!!";
		gameOver.SetActive(true);
	}

	public void PlayAgain()
	{
		SceneManager.LoadScene(0);
	}
}
