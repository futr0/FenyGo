using UnityEngine;
using System.IO;
using System;

public class ScoreFileManager : MonoBehaviour
{
    private readonly string scoresTxtPath = "Assets/Scores/Highscore.txt";
    public void SaveResultToFile(int points)
    {
        int result = GetBestResult();
        try
        {
            if (result < points)
            {
                using (TextWriter writer = new StreamWriter(scoresTxtPath, false))
                {
                    writer.WriteLine(points);
                    Debug.Log("Higscore.txt writed with: " + points);

                    writer.Close();
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    public int GetBestResult()
    {
        int result = 0;
        try
        {
            using (StreamReader reader = new StreamReader(scoresTxtPath))
            {
                var parsingResult = int.TryParse(reader.ReadToEnd(), out result);
                Debug.Log("Higscore.txt readed");
                reader.Close();
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
        return result;
    }
}
