using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Test
{
    public class BasePanel : MonoBehaviour
    {
        protected bool isRoemove = false;
        protected new string name;


        public virtual void OpenPanel(string name)
        {
            this.name = name;
            gameObject.SetActive(true);
        }

        public virtual void closePanel()
        {
            isRoemove = true;
            gameObject.SetActive(false);
            Destroy(gameObject);

            if (UIManager.instance.pathDict.ContainsKey(name))
            {
                UIManager.instance.pathDict.Remove(name);
            }
        }

    }
}
