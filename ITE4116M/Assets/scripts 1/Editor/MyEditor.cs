using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Data;
using Unity.Collections;
using ExcelDataReader;

public static class MyEditor
{
    [MenuItem("MyTool/excelTotxt")]
    public static void ExportExcelToTxt()
    {
        //_ExcelPath
        string assetPath = Application.dataPath + "/_Excel";

        string[] files = Directory.GetFiles(assetPath, "*.xlsx");

        for (int i = 0; i < files.Length; i++)
        {
            files[i] = files[i].Replace("\\", "/");
            Debug.Log(files[i]);

            using (FileStream fs = File.Open(files[i], FileMode.Open, FileAccess.Read))
            {
                IExcelDataReader excelDataReader = ExcelReaderFactory.CreateOpenXmlReader(fs);

                DataSet dataSet = excelDataReader.
            }
        }
    }

}
