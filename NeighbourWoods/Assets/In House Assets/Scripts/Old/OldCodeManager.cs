//#region AudioType Enum
//public enum AudioType
//{
//    CHARACTER,
//    CHARACTER_DIALOGUE,
//    PLAYER_DIALOGUE,
//    PLAYER,
//    SOUND_EFFECT,
//    GAME,
//    MUSIC,
//}
//#endregion
//#region LocationID Enum
//public enum LocationID
//{
//    HOME,
//    STREETS,
//    HOUSES_OF_THE_NEIGHBOURHOOD,
//    SHOBES_HOUSE,
//    EBONYS_AND_ROGERS_HOUSE,
//    OSCAR_MILY_AND_LIEAS_HOUSE,
//    THE_CHICKENS_HOUSE,
//    MURPHY_CALLIE_FRANGELINA_AND_GINGIES_HOUSE,
//    ARCHIES_HOUSE,
//    THE_TRIOS_HOUSE,
//    BUNDY_AND_SNOWBALLS_HOUSE,
//    MIDNIGHT_AND_GINGERS_HOUSE,
//    MUFFLES_AND_KEGS_HOUSE,
//    LILLAS_HOUSE,
//    ABANDONED_HOUSE,
//    WTICHS_HOUSE,
//    HOUSE_1,
//    HOUSE_2,
//    HOUSE_3,
//    HOUSE_4,
//    HOUSE_5,
//    HOUSE_6,
//    HOUSE_7,
//    HOUSE_8,
//    HOUSE_9,
//    HOUSE_10,
//    CONCESSION_STORE,
//    PARK,
//    JUNKYARD,
//    STRAYS_DEN,
//    WOOD_TRAIL,
//    THE_BRAMBLES,
//    FOX_DEN,
//    PINIC_AREA,
//    THE_WARREN,
//    THE_CLEARING,
//    KELPIE_POOL,
//    UNICORN_GLADE,
//    THE_MYSTERIOUS_ENTITYS_LAIR,
//}
//#endregion
//public enum DialogueID
//{
//    MORNING_DAY_1,
//    MIDDAY_DAY_1,
//    AFTERNOON_DAY_1,
//    EVENING_DAY_1,
//    MORNING_DAY_2,
//    MORNING_DAY_3,
//    MORNING_DAY_4,
//    MORNING_DAY_5,
//    MORNING_DAY_6,
//    MORNING_DAY_7,
//}
//public enum DialoguePorCHolder
//{
//    Player,
//    Character,
//}
//public enum TaskName
//{
//    FIND_PUUPIES,
//    GIVE_TURTLES_PIZZA,
//    CHASE_OFF_FOX,
//    SECURE_CHICKEN_COOP,
//    DEAL_WITH_FOX,
//    MEDIATE_BETWEEN_FOX_AND_CHICKENS,
//    HELP_SQUIRREL,
//    CONVENIENCE_STORE_HEIST,
//    DEAL_WITH_DEER,
//    MEET_UNICORN,
//    FAWN_RESCUE,
//    WITCH_HOUSE_VISIT,
//    FIND_SOCKS_FOR_ARCHIE
//}
//public enum Taskstype
//{
//    Dialogue,
//    Fetch,
//    Puzzle,
//    // other
//}
public class OldCodeManager
{
    //Old movement variables
    //public int forwardSpeed = 10;
    //public int backwardSpeed = 10;
    //public int leftSpeed = 10;
    //public int rightSpeed = 10;
    //private string inventoryManagerMethodPickupItem = "PickupItem";
    //private string inventoryManagerUpdateItemIcon = "OnItemPickup";
    //public Levels[] levels;
    //public Image ballIcon;
    //public List<DialogueList> dialogueList;
    //public TMP_Text characterNameText;
    //public TMP_Text characterDialogueText;
    //public TMP_Text playerNameText;
    //public TMP_Text playerDialogueText;
    //private Queue<string> sentences;
    //public List<string> sent;
    //public LuaNetworkCommands Lua;
    //public DialogueDatabase neighbourWoodsDatabase;
    //public DialogueActor playerActor;
    //public DialogueActor TestCharacter;
    //public DialogueActor TestCharacter2;
    //public DialogueActor TestCharacter3;
    //public Conversation conversation;
    //public int conversationID;
    //public int dialogueEntryID;
    //void Start()
    //{
    //    sentences = new Queue<string>();
    //    sent = new List<string>();
    //}
    //void Update()
    //{
    //    itemImageUI.enabled = true;
    //}
    //void OnTaskPointsChange(LuaWatchItem luaWatchItem, Lua.Result newValue)
    //{
    //    DialogueManager.AddLuaObserver("Variable['TaskPoints']", LuaWatchFrequency.EveryDialogueEntry, OnTaskPointsChange);
    //    Debug.Log("Number of TaskPoints change to: " + newValue.AsInt);
    //}
    //public void MorningTime()// to change into turning off visual components because characters need to be updated when not visualable but for prototype it will do
    //{

    //}
    //public void DebugUpdateTime()
    //{
    //    timeSlot++;
    //    GameEvents.ReportGameStateChange(GameState.FREE_ROAM);
    //    if ((int)timeSlot == 4)
    //    {
    //        day++;
    //        timeSlot = TimeSlot.MORNING;
    //        if ((int)day == 2)
    //        {
    //            SceneManager.LoadScene("OverworldScene");
    //        }
    //        if ((int)day == 7)
    //        {
    //            //make gameevent reportgameover 
    //        }
    //    }
    //    GameEvents.ReportOnTimeChange(timeSlot, day);
    //}
    //uiManager.SendMessage("UpdateItemIcon");
    //inventoryManager.SendMessage(inventoryManagerMethodPickupItem, bananaIcon);
    //int foodValue;
    //attempt to parse the value using the TryParse functionality of the integer type
    //int.TryParse(food, out foodValue);
    //masterFood += foodValue;
    // Old movement code
    //if (Input.GetKey(KeyCode.W))
    //{
    //    transform.position += Vector3.forward * Time.deltaTime * forwardSpeed;
    //}
    //if (Input.GetKey(KeyCode.A))
    //{
    //    transform.position += Vector3.left * Time.deltaTime * leftSpeed;
    //}
    //if (Input.GetKey(KeyCode.D))
    //{
    //    transform.position += Vector3.right * Time.deltaTime * rightSpeed;
    //}
    //if (Input.GetKey(KeyCode.S))
    //{
    //    transform.position += Vector3.back * Time.deltaTime * backwardSpeed;
    //}
    //public void StartDialogue(DialogueList dialogueList)
    //{
    //    //playerNameText.text = dialogueList.dialogueHolderName;
    //    sentences.Clear();
    //    //sent.Clear();
    //    playerDialogueText.text = "";
    //    characterDialogueText.text = "";
    //    foreach (string sentence in dialogueList.sentences)
    //    {
    //        //sent.Add(sentence);
    //        sentences.Enqueue(sentence);
    //        //Debug.Log(sentence);
    //    }
    //    DisplayNextSentence();
    //}
    //public void DisplayNextSentence()
    //{
    //    if (sentences.Count == 0)
    //    {
    //        EndDialogue();
    //        return;
    //    }
    //    string sentence = sentences.Dequeue();
    //    //string sentence = sent[0];
    //    //Debug.Log(sent[0]);
    //    if (sentence.EndsWith("/P01/"))
    //    {
    //        sentence = sentence.Remove(sentence.Length - 5);
    //        playerDialogueText.text = sentence;
    //        characterDialogueText.DOFade(0.5f, 0.3f);
    //        characterNameText.DOFade(0.5f, 0.3f);
    //        playerDialogueText.DOFade(1,0.3f);
    //        playerNameText.DOFade(1, 0.3f);
    //    }
    //    else if (sentence.EndsWith("/P02/"))
    //    {
    //        sentence = sentence.Remove(sentence.Length - 5);
    //        characterDialogueText.text = sentence;
    //        playerNameText.DOFade(0.5f, 0.3f);
    //        playerDialogueText.DOFade(0.5f, 0.3f);
    //        characterDialogueText.DOFade(1, 0.3f);
    //        characterNameText.DOFade(1, 0.3f);
    //    }
    //    else if (sentence.EndsWith("/END/"))
    //    {
    //        EndDialogue();
    //    }
    //    //sent.RemoveAt(0);
    //    //Debug.Log(sentence);
    //}
    //public void EndDialogue()
    //{
    //    Debug.Log("End of converstion.");
    //    if (gameState == GameState.DIALOGUE)
    //    {
    //        gameState = GameState.FREE_ROAM;
    //    }
    //    GameEvents.ReportGameStateChange(GameState.FREE_ROAM);
    //}
    //void GetConversation()
    //{
    //    taskPoints = DialogueLua.GetVariable("TaskPoints").asInt;
    //    if (Input.GetKeyDown(KeyCode.Q))
    //    {
    //        Debug.Log(taskPoints);
    //    }
    //}
    //public void OnGameStateChange(GameState gameState)
    //{
    //    if (gameState == GameState.DIALOGUE)
    //    {
    //        gameState = GameState.DIALOGUE;
    //        GameEvents.ReportGameStateChange(GameState.DIALOGUE);
    //    }
    //    else
    //    {
    //        gameState = GameState.FREE_ROAM;
    //        GameEvents.ReportGameStateChange(GameState.FREE_ROAM);
    //    }
    //}
    //void OnEnable() //Subscribes to our game events
    //{
    //    GameEvents.OnGameStateChange += OnGameStateChange;
    //}
    //void OnDisable() //Unsubscribes to our game events
    //{
    //    GameEvents.OnGameStateChange -= OnGameStateChange;
    //}
    //public void TaskStarted(Tasks tasks) // name and value in the Parameters
    //{
    //    //Sends started task to eventmanager 
    //}
    //public void TaskCompleted(Tasks tasks) // name and value in the Parameters
    //{
    //    //Sends completed task to eventmanager
    //}
}
//public class DialogueCollider : MonoBehaviour
//{
//    public Collider dialoguecol;
//    public DialogueID dialogueID;
//    public GameState gameState;
//    public CanvasGroup otherDialogueName;
//    public CanvasGroup buttonPressBox;
//    public DialogueManager dialogueManager;
//    public TaskManager taskManager;
//    public bool canStartDialogue = false;
//    public void SetDialogueID()
//    {
//        foreach (DialogueList dl in dialogueManager.dialogueList)
//        {
//            if (dl.dialogueID == dialogueID)
//            {
//                dialogueManager.StartDialogue(dl);
//                Debug.Log(dl);
//            }  
//        }
//    }
//    void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            canStartDialogue = true;
//            Debug.Log("Entering in character collider working");
//        }
//    }
//    void OnTriggerStay(Collider Other)
//    {
//        if (Other.tag == "Player")
//        {
//            buttonPressBox.alpha = 1;
//        }
//        if (canStartDialogue && Input.GetKeyDown(KeyCode.E))
//        {
//            if (gameState == GameState.FREE_ROAM)
//            {
//                gameState = GameState.DIALOGUE;
//                GameEvents.ReportGameStateChange(gameState);
//                SetDialogueID();
//            }
//            else
//            {
//                gameState = GameState.FREE_ROAM;
//                GameEvents.ReportGameStateChange(gameState);
//                buttonPressBox.alpha = 2;
//            }
//        }
//    }
//    void OnTriggerExit(Collider other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            canStartDialogue = false;
//            GameEvents.ReportGameStateChange(GameState.FREE_ROAM);
//            Debug.Log("Exiting from character collider working");
//            buttonPressBox.alpha = 0;
//        }
//    }
//}
//public class DialogueTrigger
//{
//    public DialogueManager dialogueManager;
//    public string characterName;
//    public DialogueList[] dialogueList;
//    public void GetCharacterID()
//    {
//        foreach (DialogueList dl in dialogueManager.dialogueList)
//        {
//            if(dl.dialogueID == )
//            Debug.Log(dl.characters);
//        }
//    }
//    public void TriggerDialogue()
//    {
//        dialogueManager.StartDialogue(characterName);
//        GetCharacterID();
//    }
//}
//[Groups("Base Settings")]
//[System.Serializable]
//public class DialogueList
//{
//    public DialoguePorCHolder dialoguePorCHolder;
//    public Characters characters;
//    public DialogueID dialogueID;
//    [TextArea(3, 10)]
//    public string[] sentences;
//}
//#region Levels Class
//[Groups("Base Settings")]
//[System.Serializable]
//public class Levels
//{
//    public LocationID locationID; 
//    public BoxCollider areaCollider;
//    public Tasks tasksInArea;
//}
//#endregion
//#region Environment Class
//[Groups("Base Settings")]
//[System.Serializable]
//public class Environments
//{

//}
//#endregion