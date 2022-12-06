using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum StepGame
{
    hero,
    enemy
}

public class MainController : MonoBehaviour
{
    [SerializeField]
    private ActivityDragAndDrop prefabActivity;
    [SerializeField]
    private PlayerController prefabPlayer;
    [SerializeField]
    private PlayerController prefabEnemy;
    [SerializeField]
    private Transform[] pointSpawnHero;
    [SerializeField]
    private Transform[] pointSpawnEnemy;

    [Header("---------UI----------")]
    [SerializeField]
    private RectTransform gamePanel;
    [SerializeField]
    private Button buttonEndTurn;
    [SerializeField]
    private GameObject panelWin;
    [SerializeField]
    private GameObject panelLose;
    [SerializeField]
    private KeyCode restartGame;

    private PlayerController[] playerHero;
    private PlayerController[] playerEnemy;

    private StepGame stepGame;
    private SetActivity currentActivityEnemy;
    private float timer;
    private int currentTarget;

    private void Awake()
    {
        SpawnPlayers();
        if (buttonEndTurn) buttonEndTurn.onClick.AddListener(() => ClickButtonEndTurn());
        panelLose.SetActive(false);
        panelWin.SetActive(false);
    }

    private void Start()
    {
        for (int index = 0; index < playerHero.Length; index++)
        {
            StepPlayer(playerHero[index], StepGame.hero);
        }
    }

    private void Update()
    {
        UpdateButton();
    }

    private void UpdateButton()
    {
        if (Input.GetKeyDown(restartGame))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("reset");
        }
    }

    private void ClickButtonEndTurn()
    {
        if (stepGame == StepGame.hero)
        {
            stepGame = StepGame.enemy;
            StartCoroutine(TimerStepEnemy());
        }
    }

    private void SpawnPlayers()
    {
        playerHero = new PlayerController[pointSpawnHero.Length];
        playerEnemy = new PlayerController[pointSpawnEnemy.Length];

        for (int index = 0; index < playerHero.Length; index++)
        {
            playerHero[index] = CreatePlayer(prefabPlayer, pointSpawnHero[index], gamePanel, DeathHero);
        }

        for (int index = 0; index < playerEnemy.Length; index++)
        {
            playerEnemy[index] = CreatePlayer(prefabEnemy, pointSpawnEnemy[index], gamePanel, DeathEnemy);
        }
    }

    private PlayerController CreatePlayer(PlayerController prefabPlayer, Transform pointSpawn, RectTransform gamePanel, System.Action deathHero)
    {
        PlayerController player = Instantiate(prefabPlayer, pointSpawn.position, Quaternion.identity);
        player.SetGamePanel(gamePanel);
        player.Death += deathHero;
        return player;
    }

    private void StepPlayer(PlayerController player, StepGame stepGame)
    {
        this.stepGame = stepGame;
        player.SetActivity();
        player.CheckStepShield();
        player.CheckStepPoison();
    }

    private void ApplyActivityEnemyToHero(PlayerController currentPlayer, PlayerController playerTarget)
    {
        currentActivityEnemy = currentPlayer.GetComponentInChildren<SetActivity>();
        currentActivityEnemy.ApplyActivity(playerTarget.transform);
    }

    private IEnumerator TimerStepEnemy()
    {
        for (int index = 0; index < playerEnemy.Length; index++)
        {
            StepPlayer(playerEnemy[index], StepGame.enemy);

            currentTarget = Random.Range(0, playerHero.Length);
            timer = Random.Range(0.5f, 1.0f);
            yield return new WaitForSeconds(timer);

            ApplyActivityEnemyToHero(playerEnemy[index], playerHero[currentTarget]);
            currentActivityEnemy.transform.position = new Vector3(playerHero[currentTarget].transform.position.x,
                currentActivityEnemy.transform.position.y, playerHero[currentTarget].transform.position.z);

            timer = 0.3f;
            yield return new WaitForSeconds(timer);
            currentActivityEnemy.gameObject.SetActive(false);
        }


        for (int index = 0; index < playerHero.Length; index++)
        {
            StepPlayer(playerHero[index], StepGame.hero);
        }
              
    }

    private void DeathHero()
    {
        panelLose.SetActive(true);
    }

    private void DeathEnemy()
    {
        panelWin.SetActive(true);
    }
}
