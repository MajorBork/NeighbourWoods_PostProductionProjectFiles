using UnityEngine;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem;
using Manager.Inventory;
using Manager.UI;

public class BallQuestObject : MonoBehaviour
{
    public string questTitle;
    public QuestState newQuestState = QuestState.Active;
    //private QuestState newQuestState = QuestState.Success;
    public GameObject questObject;
    public string message;
    public string itemNameOnObject;
    public InventoryManager inventoryManager;
    public UIManager uiManager;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiManager.SendMessage("UpdateItem",itemNameOnObject);
            QuestLog.SetQuestState(questTitle, newQuestState);
            DialogueManager.ShowAlert(message);
            questObject.SetActive(false);
        }
    }
}
