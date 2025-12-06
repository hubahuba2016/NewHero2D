using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Legacy UI Text")]
    public Text scoreText;
    public Text clipText;
    public Text reloadText;
    public Text gameOverText;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        reloadText.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);   // hide on start

        UpdateUI();
    }

    public void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + GameManager.Instance.score;

        if (clipText != null)
            clipText.text = "Ammo: " + GameManager.Instance.ammo + " / " + GameManager.Instance.maxAmmo;

        if (reloadText != null)
            reloadText.gameObject.SetActive(GameManager.Instance.ammo <= 0);
    }

    public void ShowGameOver()
    {
        if (gameOverText != null)
            gameOverText.gameObject.SetActive(true);
    }
}
