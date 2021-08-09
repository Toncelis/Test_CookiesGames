using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Ball
{
    /// <summary>
    /// ������ ������� ��������, ���������������� �������� � ������������ ����� ���, ���������������� ��������.
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class Rotator : MonoBehaviour
    {
        private Rigidbody myRigidbody;

        [Tooltip("����������� ��������� �������� �������� � �������� ��������")]
        [SerializeField] private float rotationCoef;

        private void Start()
        {
            myRigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            myRigidbody.angularVelocity = new Vector3 (myRigidbody.velocity.y, -myRigidbody.velocity.x, 0) * rotationCoef;
        }
    }

}