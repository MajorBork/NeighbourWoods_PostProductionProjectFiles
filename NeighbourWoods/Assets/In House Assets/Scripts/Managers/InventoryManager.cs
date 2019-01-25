using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager.Item;
using Manager.UI;
using DG.Tweening;
using Language.Lua;
using PixelCrushers.DialogueSystem;

namespace Manager.Inventory 
{
    #region InventoryVis Enum
    public enum InventoryVis
    {
        IS_LOOKING_IN_INVENTORY,
        NOT_LOOKING_IN_INVENTORY,
    }
    #endregion
    #region InventoryManager Class
    public class InventoryManager : Singleton<InventoryManager>
    {
        //public Items iteminInventory;
        [Header("Object Variables")]
        public GameManager gameManager;
        [Header("Bool Variables (do not touch)")]
        public bool inventoryShowing;
        public bool hasItem;
        [Header("String Variables (do not touch)")]
        public string uiManagerMethod = "UpdateFoodText";
        [Header("Int Variables (do not touch)")]
        public int masterFood;
        public int masterClue;
        #region Start and Update
        void Start() // Use this for initialization
        {
            inventoryShowing = false;
            gameManager.uiManager.inventoryCanvas.alpha = 0;
        }
        void Update() // Update is called once per frame
        {
            //AddFood();
        }
        #endregion
        void GetRidOfItem()
        {
            UIManager.instance.GetRidOfItem();
        }
        #region Food Methods
        /// <summary> Updates the food level for the player.
        /// <para> It accesses the lua in the Dialogue System and add or takes away from the amount displayed in the inventory menu. </para>
        /// </summary>
        public void UpdateFood()
        {
            int DSfood = DialogueLua.GetVariable("Food").asInt;
            masterFood = DSfood;
            Debug.Log("I have Food " + masterFood);
            gameManager.uiManager.instance.UpdateFoodText(masterFood);
        }
        #endregion
        #region Clue Methods
        public void UpdateClue()
        {
            int DSClue = DialogueLua.GetVariable("Clues").asInt;
            masterClue = DSClue;
            Debug.Log("I have Clue " + masterClue);
            gameManager.uiManager.instance.UpdateClueText(masterClue);
        }
        #endregion
        #region Inventory Event Methods
        void OnEnable()
        {
            GameEvents.OnInventoryVisChange += OnShowInventoryChange;
        }
        void OnDisable()
        {
            GameEvents.OnInventoryVisChange -= OnShowInventoryChange;
        }
        void OnShowInventoryChange(bool inventoryVis)
        {
            if (inventoryVis)
            {
                gameManager.uiManager.inventoryCanvas.DOFade(1, 0.3f);
                gameManagerUI.inventoryCanvas.interactable = true;
                gameManagerUI.inventoryCanvas.blocksRaycasts = true;
            }
            else
            {
                gameManager.uiManager.inventoryCanvas.DOFade(0, 0.3f);
                gameManager.uiManager.inventoryCanvas.interactable = false;
                gameManager.uiManager.inventoryCanvas.blocksRaycasts = false;
            }
        }
        #endregion
    }
    #endregion
}
