using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogPanel : BasePanel
{
    private static string name = "DialogPanel";
    private static string path = "Prefab/Panel/Menu/DialogPanel";
    public static readonly UIType uIType = new UIType(path, name);
    public DialogPanel() : base(uIType)
    {

    }
}
