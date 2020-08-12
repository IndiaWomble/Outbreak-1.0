using System;
using UnityEngine;

namespace Outbreak
{
    public class ScoreManager : MonoBehaviour
    {
        DateTime startTime;
        DateTime stopTime;

        private void OnEnable()
        {
            GameManager.GameStartEvent += GameManager_GameStartEvent;
            GameManager.GameOverEvent += GameManager_GameOverEvent;
        }

        private void GameManager_GameStartEvent()
        {
            startTime = DateTime.Now;
        }

        private void GameManager_GameOverEvent()
        {
            stopTime = DateTime.Now;
        }

        private void OnDisable()
        {
            GameManager.GameStartEvent -= GameManager_GameStartEvent;
            GameManager.GameOverEvent -= GameManager_GameOverEvent;
        }

        public int GetScore()
        {
            return (int)(stopTime - startTime).TotalSeconds;
        }
    }
}