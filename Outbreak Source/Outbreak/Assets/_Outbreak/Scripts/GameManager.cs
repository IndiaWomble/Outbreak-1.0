using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Outbreak.Player;
using Outbreak.World;
using Outbreak.Sound;

namespace Outbreak
{
    public enum GameState
    {
        Init,
        Running,
        Paused,
        GameOver
    }

    public class GameManager : MonoBehaviour
    {
        GameState currentState;
        bool isPause;

        public GameState CurrentState { get => currentState; }

        public delegate void GameStart();
        public delegate void GamePause(bool isPause);
        public delegate void GameOver();

        public static event GameStart GameStartEvent;
        public static event GamePause GamePauseEvent;
        public static event GameOver GameOverEvent;

        private void Start()
        {
            Init();
        }

        private void OnEnable()
        {
            PlayerHealth.PlayerDiedEvent += PlayerHealth_PlayerDiedEvent;
            WallHealth.WallDestroyEvent += WallHealth_WallDestroyEvent;
        }

        private void WallHealth_WallDestroyEvent()
        {
            RaiseGameOverEvent();
        }

        private void OnDisable()
        {
            PlayerHealth.PlayerDiedEvent -= PlayerHealth_PlayerDiedEvent;
            WallHealth.WallDestroyEvent += WallHealth_WallDestroyEvent;
        }

        private void PlayerHealth_PlayerDiedEvent()
        {
            RaiseGameOverEvent();
        }

        void Init()
        {
            currentState = GameState.Init;
            Invoke("DelayStart", 2f);
        }

        void DelayStart()
        {
            if (GameStartEvent != null)
            {
                currentState = GameState.Running;
                GameStartEvent();
            }
            else
            {
                Debug.LogError("ERR: GameStartEvent is not registered!");
            }
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                isPause = !isPause;
                PauseGame(isPause);
            }
        }

        public void PauseGame(bool isPause)
        {
            this.isPause = isPause;

            if (isPause)
            {
                Time.timeScale = 0;
                currentState = GameState.Paused;
            }
            else
            {
                Time.timeScale = 1.0f;
                currentState = GameState.Running;
            }

            if (GamePauseEvent != null)
            {
                GamePauseEvent(isPause);
            }
            else
            {
                Debug.LogError("ERR: GameStartEvent is not registered!");
            }
        }

        public void RestartGame()
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene("Main");
        }

        private void RaiseGameOverEvent()
        {
            Time.timeScale = 0;
            if (GameOverEvent != null)
            {
                currentState = GameState.GameOver;
                GameOverEvent();
            }
            else
            {
                Debug.LogError("ERR: GameOverEvent is not registered!");
            }
        }
    }
}