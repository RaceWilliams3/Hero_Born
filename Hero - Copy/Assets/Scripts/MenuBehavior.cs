using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuBehavior : MonoBehaviour
{
    float x1 = 102;
    float x2 = 194;
    float y1 = -40;
    float y2 = 120;
    // Start is called before the first frame update
    private void Start()
    {
        Cursor.visible = true;
    }
    private void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - x1, Screen.height / 2 - y1, x2, y2), "Press to Start"))
        {
            SceneManager.LoadScene(1);
            Time.timeScale = 1.0f;
        }
    }
}
