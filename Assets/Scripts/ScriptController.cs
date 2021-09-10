using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class ScriptController: MonoBehaviour
{
    // Nome de usuário do jogador.
    public static string userName = "";

    // Password do jogador.
    public static string password = "";

    // Vidas do jogador.
    public static int userLife = 10;

    // Password do jogador.
    public  static int userPoints = 0;

    void Start () {
     carregaHistoria();
     //M();
   }
    public static void carregaHistoria()
{
        string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string path = Application.persistentDataPath+"dat.txt";// Path.Combine(docPath, "WriteLines.txt");//@"c:\MyTest.txt";
        FileInfo DB = new FileInfo(path);
        Console.WriteLine(path);
        string line = "teste2";
        // Delete the file if it exists.
        if (DB.Exists)
        {
             using (StreamReader sr = DB.OpenText())
        {
            string s = "";
            while ((s = sr.ReadLine()) != null)
            {
                Console.WriteLine(s);
            }
        }
        }
        else{
         
            using (StreamWriter outputFile = new StreamWriter(path))
        {
            
            outputFile.WriteLine(line);
         
        }
        }
}
 private const string FILE_NAME = "Test.data";

    public static void M()
    {
        if (File.Exists(FILE_NAME))
        {
            Console.WriteLine($"{FILE_NAME} already exists!");
            return;
        }

        using (FileStream fs = new FileStream(FILE_NAME, FileMode.CreateNew))
        {
            using (BinaryWriter w = new BinaryWriter(fs))
            {
                for (int i = 0; i < 11; i++)
                {
                    w.Write(i);
                }
            }
        }

        using (FileStream fs = new FileStream(FILE_NAME, FileMode.Open, FileAccess.Read))
        {
            using (BinaryReader r = new BinaryReader(fs))
            {
                for (int i = 0; i < 11; i++)
                {
                    Console.WriteLine(r.ReadInt32());
                }
            }
        }
    }

}
