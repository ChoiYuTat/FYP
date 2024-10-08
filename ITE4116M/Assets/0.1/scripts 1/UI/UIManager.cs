
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test {
    public class UIManager
    {
        private static UIManager _instance;

        private Transform _uiRoot;

        public Dictionary<string, string> S;

        private Dictionary<string, GameObject> prefabDict;

        private Dictionary<string, BasePanel> panelDict;
        public static UIManager instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UIManager();
                }
                return _instance;
            }
        }

        public Transform UIRoot
        {
            get
            {
                if(_uiRoot == null)
                {
                    _uiRoot = GameObject.Find("Canvas").transform;
                }return _uiRoot;
            }
        }

        private UIManager()
        {
            IntDicts();
        }

        private void IntDicts()
        {
            panelDict = new Dictionary<string, BasePanel>();
            prefabDict = new Dictionary<string, string>();
            pathDict = new Dictionary<string, string>()
            {
                {UIConst.MainMenuPanel,"MainMenuPanel"},
                {UIConst.UserPanel,"UserPanel"},
                {UIConst.NewUserPanel,"NewUserPanel"},
            };
        }

        public BasePanel OpenPanel(string name)
        {
            BasePanel panel = null;
            if(panelDict.TryGetValue(name, out panel))
            {
                Debug.LogError("Open :" + name);
                return null;
            }

            string path = "";
            if(!pathDict.TryGetValue(name , out path))
            {
                Debug.LogError("Error name : " + name);
                return null;
            }

            GameObject panelPrefab = null;
            if(!prefabDict.TryGetValue(name,out panelPrefab))
            {
                string realPath = "Prefab/Panel/" + path;
                panelPrefab = Resources.Load<GameObject>(realPath) as GameObject;
                prefabDict.Add(name, panelPrefab);
            }

            GameObject panelObject = GameObject.Instantiate(panelPrefab, UIRoot, false);
            panel = panelObject.GetComponent<BasePanel>();
            panelDict.Add(name, panel);
            return null;
        }

        public bool ClosePanel(string name)
        {
            BasePanel panel = null;
            if(!panelDict.TryGetValue(name , out panel))
            {
                Debug.LogError("NOT OPEN :" + name);
                return false;
            }

            panel.closePanel();
            return true;
        }

    }


    public class UIConst
    {
        public const string MainMenuPanel = "MainMenuPanel";
        public const string UserPanel = "UserPanel";
        public const string NewUserPanel = "NewUserPanel";

    }
}
