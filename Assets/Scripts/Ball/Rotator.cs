using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Ball
{
    /// <summary>
    /// Задает объекту вращение, пропорциональное скорости и направленное вдоль оси, перпендикулярной скорости.
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class Rotator : MonoBehaviour
    {
        private Rigidbody myRigidbody;

        [Tooltip("Коэффициент отношения скорости вращения к скорости движения")]
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