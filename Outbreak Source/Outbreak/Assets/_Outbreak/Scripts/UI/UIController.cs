using UnityEngine;
using UnityEngine.UI;
using Outbreak.World;
using Outbreak.Player;

namespace Outbreak.UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField]
        GameObject inGameUIPanel;
        [SerializeField]
        Text timer;
        [SerializeField]
        GameObject introPanel;
        [SerializeField]
        GameObject pausePanel;
        [SerializeField]
        GameObject gameOverPanel;
        [SerializeField]
        Button resumeBtn;
        [SerializeField]
        Button restartBtn;
        [SerializeField]
        Text score;
        [SerializeField]
        Button gOverRestartBtn;
        [SerializeField]
        Image wallHealth;
        [SerializeField]
        Image playerHealth;

        GameManager gameManager;
        ScoreManager scoreManager;

        float timercount;

        private void Start()
        {
            gameManager = FindObjectOfType<GameManager>();
            scoreManager = FindObjectOfType<ScoreManager>();
            introPanel.SetActive(true);
        }

        private void OnEnable()
        {
            GameManager.GameStartEvent += GameManager_GameStartEvent;
            GameManager.GamePauseEvent += GameManager_GamePauseEvent;
            GameManager.GameOverEvent += GameManager_GameOverEvent;

            WallHealth.WallDamageEvent += WallHealth_WallDamageEvent;
            WallHealth.WallRepairEvent += WallHealth_WallRepairEvent;

            PlayerHealth.PlayerDamageEvent += PlayerHealth_PlayerDamageEvent;


            resumeBtn.onClick.AddListener(OnResumeBtnClicked);
            restartBtn.onClick.AddListener(OnRestartBtnClicked);
            gOverRestartBtn.onClick.AddListener(OnRestartBtnClicked);
        }

        private void WallHealth_WallRepairEvent(float repair)
        {
            wallHealth.fillAmount = (float) repair / 10000;
            Debug.Log("Wall Health Repair: " + (float)repair / 10000);
        }

        private void WallHealth_WallDamageEvent(float damage)
        {
            wallHealth.fillAmount = (float) damage/10000;
            Debug.Log("Wall Health Damage: " + (float)damage / 10000);
        }

        private void OnDisable()
        {
            GameManager.GameStartEvent -= GameManager_GameStartEvent;
            GameManager.GamePauseEvent -= GameManager_GamePauseEvent;

            WallHealth.WallDamageEvent -= WallHealth_WallDamageEvent;
            WallHealth.WallRepairEvent -= WallHealth_WallRepairEvent;

            PlayerHealth.PlayerDamageEvent -= PlayerHealth_PlayerDamageEvent;

            resumeBtn.onClick.RemoveListener(OnResumeBtnClicked);
            restartBtn.onClick.RemoveListener(OnRestartBtnClicked);
            gOverRestartBtn.onClick.RemoveListener(OnRestartBtnClicked);
        }

        private void PlayerHealth_PlayerDamageEvent(float damage)
        {
            playerHealth.fillAmount = (float)damage / 5000;
        }

        private void Update()
        {
            if (gameManager.CurrentState == GameState.Running)
            {
                timercount += Time.deltaTime;
                timer.text = (timercount % 60f).ToString("00");
            }
        }

        private void GameManager_GameStartEvent()
        {
            introPanel.SetActive(false);
            inGameUIPanel.SetActive(true);
        }

        private void GameManager_GameOverEvent()
        {
            score.text = "" + scoreManager.GetScore();
            gameOverPanel.SetActive(true);
            GameManager.GameOverEvent -= GameManager_GameOverEvent;
        }

        private void GameManager_GamePauseEvent(bool isPause)
        {
            pausePanel.SetActive(isPause);
        }

        void OnResumeBtnClicked()
        {
            gameManager.PauseGame(false);
        }

        void OnRestartBtnClicked()
        {
            gameManager.RestartGame();
        }
    }
}