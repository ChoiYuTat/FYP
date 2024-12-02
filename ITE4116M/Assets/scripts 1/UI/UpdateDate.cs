using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UpdateDate : MonoBehaviour
{
    public TextMeshProUGUI Hp;
    public TextMeshProUGUI Mp;
    public TextMeshProUGUI playerName;
    public Slider Hpslider;
    public Slider Mpslider;
    public CharacteBase Characte;

    public void changeDate(CharacteBase characte)
    {
        Hp.text = characte.currentHp.ToString()+"/"+characte.MaxHp;
        playerName.text = characte.Name;
        Mp.text = characte.currentHp.ToString()+"/"+characte.MaxMp;
        Hpslider.maxValue = characte.MaxHp;
        Hpslider.value = characte.currentHp;
        Mpslider.maxValue = characte.MaxMp;
        Mpslider.value = characte.MaxMp;
    }
    private void Update()
    {
       
        changeDate(Characte);
    }
}
