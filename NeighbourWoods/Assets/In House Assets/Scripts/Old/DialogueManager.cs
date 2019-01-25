//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using TMPro;
//using DG.Tweening;
//using EasyEditor;
//using PixelCrushers.DialogueSystem;
//using Language.Lua;
//using Manager.Character;
//using Manager.Environment;
//namespace Manager.GameDialogue 
//{
//    #region DialogueManager Class
//    public class DialogueManager : Singleton<DialogueManager>
//    {
//        #region Variables
//        public LuaNetworkCommands Lua;
//        public DialogueDatabase neighbourWoodsDatabase;
//        public DialogueActor playerActor;
//        public DialogueActor TestCharacter;
//        public DialogueActor TestCharacter2;
//        public DialogueActor TestCharacter3;
//        public EnvironmentManager environmentManager;
//        public int food;
//        public int taskPoints;
//        public int conversationID;
//        public int dialogueEntryID;
//        public GameState gameState;
//        #endregion
//        #region Start and Update Methods
//        void Start() // Use this for initialization
//        {
//            //IfActorSpoke();
//        }
//        void Update() // Use this for initialization
//        {
//            GetConversation();
//        }
//        #endregion
//        void GetConversation()
//        {
//            taskPoints = DialogueLua.GetVariable("TaskPoints").asInt;
//            if (Input.GetKeyDown(KeyCode.Q))
//            {
//                Debug.Log(taskPoints);
//            }
            
//        }
//        public void StartDialogue()
//        {
//            Debug.Log("Start of converstion.");
//            if (gameState == GameState.FREE_ROAM)
//            {
//                gameState = GameState.DIALOGUE;
//            }
//            GameEvents.ReportGameStateChange(GameState.DIALOGUE);
//        }
//        public void EndDialogue()
//        {
//            Debug.Log("End of converstion.");
//            if (gameState == GameState.DIALOGUE)
//            {
//                gameState = GameState.FREE_ROAM;
//            }
//            GameEvents.ReportGameStateChange(GameState.FREE_ROAM);
//        }
//        public void GetCurrentDialogueConversation()
//        {
//            int dayModifierDialgoue = DialogueManager.lastConversationID;
//            int dayModifier = DialogueManager.currentConversationState.pcResponses.GetLength(4);
//            if (dayModifierDialgoue == 3)
//            {
//                Debug.Log(dayModifierDialgoue);
//                if (dayModifier == 3)
//                {
//                    Debug.Log(dayModifier);

//                }
//            }
//        }
//    }
//    #endregion
//    #region DialogueList Class
//    [Groups("Base Settings")]
//    [System.Serializable]
//    public class DialogueList
//    {

//    }
//    #endregion
//}
