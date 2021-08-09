using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_Restart : MonoBehaviour
{
    /// <summary>
    /// Выход из игры и поражение по клику
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Game.Controllers.LevelController.GetInstance().Lose();
        }
    }
}
