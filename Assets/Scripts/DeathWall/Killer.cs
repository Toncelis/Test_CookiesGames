using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Objects
{
    /// <summary>
    /// �������� �������� �� ����������� ������ ��� ��������� �������� ������� (�����).
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
