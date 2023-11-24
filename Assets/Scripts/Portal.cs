using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    //gameOver index
    [SerializeField] private Sprite whiteHole;
    [SerializeField] private SpriteRenderer sr;
    private bool canEnter;

    private int gameOverLevel = 9;

    private void Start()
    {
        canEnter = false;
    }

    public void UpdatePortal()
    {
        sr.sprite = whiteHole;
        canEnter = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {

            if (canEnter)
            {
                LevelManager.instance.NextLevel();
            }
            else
            {
                SceneManager.LoadScene(gameOverLevel);
            }
        }
    }
}
