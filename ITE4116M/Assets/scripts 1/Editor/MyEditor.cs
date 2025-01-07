 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using OfficeOpenXml;
using System.Data;
using Unity.Collections;
using OfficeOpenXml.Style;
using Excel;
using UnityEngine.UIElements;
public static class MyEditor
{
    [MenuItem("MyTool/excelTotxt")]
    public static void ExportExcelToTxt()
    {
        //_ExcelPath
        string assetPath = Application.dataPath + "/_Excel";
        FileInfo fileinfo = new FileInfo(assetPath);
        string[] files = Directory.GetFiles(assetPath, "*.xlsx");

        for (int i = 0; i < files.Length; i++)
        {
            files[i] = files[i].Replace("\\", "/");
            Debug.Log(files[i]);

            //Get file for filestream
            using (FileStream fs = File.Open(files[i],FileMode.Open,FileAccess.Read))
            {
                //FileStream to excel object 
                var excelDataReader = ExcelReaderFactory.CreateOpenXmlReader(fs);
                //get excel data
                DataSet dataSet = excelDataReader.AsDataSet();
                DataTable table = dataSet.Tables[0];

                readTableToTxt(files[i], table);

            }
        }

        AssetDatabase.Refresh();
    }

    private static void readTableToTxt(string filePath, DataTable table)
    {
        string fileName = Path.GetFileNameWithoutExtension(filePath);

        string path = Application.dataPath + "/Resources/Data/" + fileName + ".txt";

        if(File.Exists(path))
        {
            File.Delete(path);
        }

        using (FileStream fs = File.Open(path, FileMode.Create))
        {
            using(StreamWriter sw = new StreamWriter(fs))
            {
                for(int row = 0;row< table.Rows.Count; row++)
                {
                    DataRow dataRow = table.Rows[row];

                    string str = "";
                    for(int col = 0; col < table.Columns.Count; col++)
                    {
                        string val  = dataRow[col].ToString();

                        str = str + val+"\t";
                    }

                    sw.Write(str);

                    if(row!= table.Rows.Count-1)
                    {
                        sw.WriteLine();
                    }
                }
            }
        }
    }



}
