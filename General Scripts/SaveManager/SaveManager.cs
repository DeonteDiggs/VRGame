using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SaveSystem
{
    public class SaveManager : MonoBehaviour
    {
        public static SaveManager saveManager;

        public SaveData saveData;
        public static bool isFirstTimePlaying = true;
        public bool isDataLoaded;
        public static bool isFirstSave = false;

        private void Awake()
        {

            saveManager = this;
            LoadGame();
        }


        public void SaveGame()
        {

            string dataPath = Application.persistentDataPath;


            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SaveData));
            FileStream fileStream = new FileStream(string.Concat(dataPath, "/SquareMan.saveData"), FileMode.Create);

            xmlSerializer.Serialize(fileStream, saveData);
            fileStream.Close();
        }

        public void LoadGame()
        {

            string dataPath = Application.persistentDataPath;

            if (File.Exists(dataPath + "/SquareMan.saveData"))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(SaveData));
                FileStream fileStream = new FileStream(dataPath + "/SquareMan.saveData", FileMode.Open);
                saveData = xmlSerializer.Deserialize(fileStream) as SaveData;

                fileStream.Close();

                isDataLoaded = true;
                isFirstTimePlaying = false;
            }

        }

        public void DeleteGameData()
        {

            string dataPath = Application.persistentDataPath;

            if (File.Exists(dataPath + "/SquareMan.saveData"))
            {
                File.Delete(dataPath + "/SquareMan.saveData");
                isDataLoaded = false;
                isFirstTimePlaying = true;
            }
        }

    }

    [System.Serializable]
    public class SaveData
    {
        [Header("OptionsMenuData")]
        public float volume = 0.5f;

        public bool sfx = true;

        [Header("ButtonData")]
        public bool isButtonInactive;

        [Header("InGameData")]
        public int trackLevelCount = 1;
        public bool isLevelComplete;



        [Header("ResultMenu")]
        public string[] bestTime = new string[9];
    }

    [CreateAssetMenu(fileName = "New Item Database" , menuName = "Inventory System/Items/Database")]
    public class ItemDatabaseObject : ScriptableObject , ISerializationCallbackReceiver
    {
        public ItemObject[] items;
        public Dictionary<ItemObject, int> GetId = new Dictionary<ItemObject, int>();

        public void OnAfterDeserialize()
        {
            for (int i = 0; i < items.Length; i++)
            {
                items[i].Id = i;
                GetId.Add(items[i] , i);
            }
        }

        public void OnBeforeSerialize()
        {
            GetId = new Dictionary<ItemObject, int>();
        }
    }

}
