using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.UI; //ʹ��Unity UI��ʽ�졣 (Text��UI��һ����Ŷ! Ҫʹ�þͱ��Ҫ�ӣ���Ȼ�����F�e�`!)



public class textEffect : MonoBehaviour
{

    public Text mytext;

    void Start()
    {

        InvokeRepeating("showHide", 0.5f, 0.5f);

        //0.5���ᣬÿ0.5�����}����showHide��ʽ��

        //InokeRepeating ���}����(����ʽ��������һ���g�������У�ÿ�������һ��)��

    }

    void showHide()
    {

        if (mytext.text == "")
        { //��� mytext�����ǿյ�

            mytext.text = "~press space bar to star game~"; //�� mytext���ݸ�׃

        }
        else
        { //��t

            mytext.text = ""; //�� mytext���ݸĳɿյ�

        }

    }

}