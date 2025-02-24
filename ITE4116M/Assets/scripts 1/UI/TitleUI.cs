using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleUI : MonoBehaviour
{
    public Button Continue;
    public Button Load;
    public Button Save;
    public Button Exit;
    public Button New;

    public GameObject recordPanel;

    private void Awake()
    {
        Continue.onClick.AddListener(() => LoadRecord(RecordData.Instance.lastID));
        Load.onClick.AddListener(OpenRecordPanel);
        OnlyLoad.OnLoad += LoadRecord;
        New.onClick.AddListener(NewGame);
        Exit.onClick.AddListener(QuitGame);
    }

    private void OnDestroy()
    {
        OnlyLoad.OnLoad -= LoadRecord;
    }


    // Start is called before the first frame update
    void Start()
    {
        RecordData.Instance.Load();
        
        if(RecordData.Instance.lastID != 233)
        {
            Continue.interactable= true;
            Load.interactable= true;
        }
    }

    void LoadRecord(int i)
    {
        Savedata.Instance.Load(i);

        if(i!=RecordData.Instance.lastID)
        {
            RecordData.Instance.lastID = i;
            RecordData.Instance.Save();
        }

        SceneManager.LoadScene(Savedata.Instance.scensName);
    }

    void OpenRecordPanel()
    {
        recordPanel.SetActive(!recordPanel.activeSelf);

    }

    void NewGame()
    {
        SceneManager.LoadScene(Savedata.Instance.scensName);
    }

    void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
