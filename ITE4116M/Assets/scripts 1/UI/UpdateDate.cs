using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UpdateDate : MonoBehaviour
{
    public TextMeshProUGUI Hp;
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI Mp;
    public CharacteBase Characte;

    public void changeDate(CharacteBase characte)
    {
        Hp.text = characte.currentHp.ToString()+"/"+characte.MaxHp;
        playerName.text = characte.Name;
        Mp.text = characte.currentHp.ToString()+"/"+characte.MaxMp;
    }
    private void Update()
    {
        changeDate(Characte);
    }
}
