using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
//using Manager.Task;
//namespace Manager.Character
//{
//    #region CharacterID Enum
//    public enum CharacterID
//    {
//        SHOBE,
//        FOREST_UNICORN,
//        FOREST_SPIRIT_RICK,
//        LEIA,
//        OSCAR,
//        CONE_DOG,
//        DEER,
//        MUFFLES,
//        KEG,
//        THE_STRAYS,
//        BUNDY,
//        MILLY,
//        MIDNIGHT,
//        GINGER,
//        MISHKA,
//        BULLY_DOG,
//        CHICKENS,
//        FAMILLIAR,
//        KOMONDOR,
//        THE_COLONY,
//        MURPHY_AND_CALLIE,
//        FRANGELINA_FRANKENFACE,
//        GINGIE,
//        SNOWBALL,
//        ARCHIE,
//        THE_MURDER,
//        EBONY,
//        ROGER,
//        MOTHER_DUCK,
//        MOTHER_CAT,
//        THE_TRIO,
//        SQUIRREL,
//        THE_FOX,
//        OWNER,
//        WITCH,
//        CHILDREN,
//        MOLE,
//        YOUNG_TURTLES,
//        KELPIE,
//        THE_SHOPKEEPER,
//        LILLA,
//    }
//    #endregion
//    #region CharacterGender Enum
//    public enum CharacterGender
//    {
//        Male,
//        Female,
//        Unknown,
//        Mixed,
//    }
//    #endregion
//    #region CharacterType Enum
//    public enum CharaterType
//    {
//        Dog,
//        Cat,
//        Fox,
//        Rabbit,
//        Crow,
//        Duck,
//        Squirrel,
//        Chickens,
//        Deer,
//        ForestSpirit,
//        RedFox,
//        Unknown,
//    }
//    #endregion
//    #region CharacterBreed Enum
//    public enum CharacterBreed
//    {
//        ShibaInu,
//        Unicorn,
//        Mutt,
//        Corgi,
//        Pug,
//        Staffy,
//        GreatDane,
//        BlackDwarfLop,
//        Dward,
//        BlackBritishShorthair,
//        Chihuahua,
//        Bengal,
//        Komondor,
//        Chickens,
//        BorderCollies,
//        AmericanShorthairBreed,
//        GingerShorthair,
//        BlackDomesticShorthair,
//        Labrador,
//        ShetlandSheepdog,
//        Unknown,
//    }
//    #endregion
//    #region CharacterManager Class
//    public class CharacterManager : MonoBehaviour
//    {
//        public Characters[] characters;
//    }
//    #endregion
//    #region Characters Class
//    [Groups("Base Settings")]
//    [System.Serializable]
//    public class Characters
//    {
//        public CharacterID characterName;
//        public CharacterGender characterGender;
//        public CharaterType characterType;
//        public CharacterBreed characterBreed;
//        public int basePlayerLoyalty;
//        public int baseHumanLoyalty;
//        public string task;
//        public string dialogueID;
//        public Image icon;
//    }
//    #endregion
//}