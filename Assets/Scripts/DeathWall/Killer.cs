using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Objects
{
    /// <summary>
    /// Вызывает проигрыш из контроллера уровня при активации триггера игроком (шаром).
    /// </summary>
    public class Killer : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Controllers.LevelController.GetInstance().Lose();
            }
        }
    }
}
