using UnityEngine;
using System.IO;

public class ScreenShot : MonoBehaviour
{
    public string folderPath = "Screenshots";

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string fileName = string.Format("{0}/{1}.png", folderPath, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
            ScreenCapture.CaptureScreenshot(fileName);

            Debug.Log("Screenshot captured: " + fileName);
        }
    }
}

