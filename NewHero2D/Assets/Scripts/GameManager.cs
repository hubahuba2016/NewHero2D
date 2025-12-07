using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public int ammo = 10;      // bullet clip
    public int maxAmmo = 10;

    bool isGameOver = false;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }

    // Called when enemy dies
    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);
        UIManager.Instance.UpdateUI();
    }

    // Called when player touches enemy
    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;
        Debug.Log("GAME OVER!");
        UIManager.Instance.ShowGameOver();
        // Restart after 1.5 sec
        Invoke(nameof(Restart), 1.5f);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Ammo system
    public bool UseAmmo()
    {
        if (ammo > 0)
        {
            ammo--;
            Debug.Log("Ammo: " + ammo);
            UIManager.Instance.UpdateUI();
            return true;
        }

        Debug.Log("No ammo!");
        UIManager.Instance.UpdateUI();
        return false;
    }

    public void Reload()
    {
        ammo = maxAmmo;
        Debug.Log("Reloaded. Ammo: " + ammo);
        UIManager.Instance.UpdateUI();
    }
}
