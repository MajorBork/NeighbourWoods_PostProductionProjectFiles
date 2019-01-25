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
        public UIManager gameManagerUI;
        public GameObject itemObject;
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
            gameManagerUI.inventoryCanvas.alpha = 0;
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
        public void UpdateFood()
        {
            int DSfood = DialogueLua.GetVariable("Food").asInt;
            masterFood = DSfood;
            Debug.Log("I have Food " + masterFood);
            UIManager.instance.UpdateFoodText(masterFood);
        }
        #endregion
        #region Clue Methods
        public void UpdateClue()
        {
            int DSClue = DialogueLua.GetVariable("Clues").asInt;
            masterClue = DSClue;
            Debug.Log("I have Clue " + masterClue);
            UIManager.instance.UpdateClueText(masterClue);
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
                gameManagerUI.inventoryCanvas.DOFade(1, 0.3f);
                gameManagerUI.inventoryCanvas.interactable = true;
                gameManagerUI.inventoryCanvas.blocksRaycasts = true;
            }
            else
            {
                gameManagerUI.inventoryCanvas.DOFade(0, 0.3f);
                gameManagerUI.inventoryCanvas.interactable = false;
                gameManagerUI.inventoryCanvas.blocksRaycasts = false;
            }
        }
        #endregion
    }
    #endregion
}
