using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Manager.Item;
using DG.Tweening;
using UnityEngine.UI;
namespace Manager
{
    #region GameState Enum
    public enum GameState
    {
        FREE_ROAM,
        DIALOGUE,
        TITLE_SCREEN,
        PAUSE_SCREEN,
        CREDIT_SCREEN,
    }
    #endregion
    #region GameManager 
    public class GameManager : Singleton<GameManager>
    {
        public int foodLevel;
        //public ItemType itemType;
        public GameState gameState;
        public bool Debug;
        public Image startScreen;
        
        void Start()
        {
            GameEvents.ReportGameStateChange(GameState.TITLE_SCREEN);
        }
        void Update()
        {
            if (Input.GetButtonDown("Map"))
            {
                startScreen.DOFade(1, 0.3f);
            }
            else
            {
                startScreen.DOFade(0, 0.3f);
            }
        }
        private void OnEnable()
        {
            GameEvents.OnGameStateChange += OnGameStateChange;
        }
        private void OnDisable()
        {
            GameEvents.OnGameStateChange -= OnGameStateChange;
        }
        void OnGameStateChange(GameState gs)
        {
            gameState = gs;
        }
    }
    #endregion
}
