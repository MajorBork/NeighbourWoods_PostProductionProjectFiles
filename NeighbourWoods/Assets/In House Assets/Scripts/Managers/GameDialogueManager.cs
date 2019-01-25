using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using PixelCrushers.DialogueSystem;
using Language.Lua;
using Manager.Environment;
using Manager;
namespace Manager.GameDialogue
{
    public class GameDialogueManager : MonoBehaviour
    {
        #region Variables
        [Header("Object references for scripts")]
        public EnvironmentManager environmentManager;
        public GameManager gameManager;
        [Header("Random Variables")]
        public int food;
        public int taskPoints;
        public string currentActor;
        #endregion
        #region Start and Update Methods
        void Start() // Use this for initialization
        {

        }
        void Update() // Use this for initialization
        {

        }
        #endregion
        #region Start and EndDialogue Methods
        public void StartDialogue()
        {
            Debug.Log("Start of converstion.");
            if (GameManager.instance.gameState == GameState.FREE_ROAM)
            {
                GameEvents.ReportGameStateChange(GameState.DIALOGUE);
            }
        }
        public void OnConversationStart(Transform actor)
        {
            currentActor = actor.name;
            Debug.Log(string.Format("Starting conversation with {0}", actor.name));
            int DSfood = DialogueLua.GetVariable(currentActor + "FriendPoint").asInt;
            Debug.Log(DSfood);
            GameEvents.ReportCharacterTalkingChange(DSfood);
        }
        public void OnConversationPoint()
        {
            int DSfood = DialogueLua.GetVariable(currentActor + "FriendPoint").asInt;
            Debug.Log(DSfood);
            GameEvents.ReportCharacterTalkingChange(DSfood);
        }
        public void EndDialogue()
        {
            Debug.Log("End of converstion.");
            if (GameManager.instance.gameState == GameState.DIALOGUE)
            {
                GameEvents.ReportGameStateChange(GameState.FREE_ROAM);
            }
        }
        // SendMessage(UpdateTime,,GameManager); Delay({{5}})
        #endregion
    }
    #region DialogueList Class
    //[Groups("Base Settings")]
    //[System.Serializable]
    //public class DialogueList
    //{

    //}
    #endregion
}
