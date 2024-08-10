using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    public int health = 3;
    [SerializeField] List<RawImage> lives;
    public int spentLives = 0;
    private bool corotuineActive = false;
    [SerializeField] TextMeshProUGUI gameoverText;
    [SerializeField] Button newGameButton;
    private bool gameOver = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.activeInHierarchy && !corotuineActive && !gameOver)
        {
            health -= 1;
            spentLives += 1;
            lives[lives.Count - spentLives].gameObject.SetActive(false);
            if (health > 0)
            {
                StartCoroutine(RespawnPlayer());
            }
        }
        if (health == 0 && !gameOver)
        {
            gameOver = true;
            StartCoroutine(HandleGameOverScreen());

        }
    }
    IEnumerator RespawnPlayer()
    {
        corotuineActive = true;    
        player.transform.position = new Vector3(0, 0, 0);
        player.transform.rotation = new Quaternion(0, 0, 0, 0);

        yield return new WaitForSeconds(2);     
        player.gameObject.SetActive(true);
        corotuineActive = false;
    }
    IEnumerator HandleGameOverScreen()
    {
        gameoverText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        gameoverText.gameObject.SetActive(false);
        newGameButton.gameObject.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
