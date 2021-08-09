using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Ball
{
    /// <summary>
    /// ��������� ������ ������ (������� ���������� ����� ������),
    /// ��������� ������ � ������ ��������,
    /// � ��������� ����� ����������� ������ � ���������� ��������� ������
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class Launcher : MonoBehaviour
    {
        private Rigidbody myRigidbody;
        private Vector3 startPosition;

        [Header("Launch settings")]
        [Tooltip("�������� ������� ������� ������ �������� UnityInputSystem (������������� Fire1)")]
            [SerializeField] private string fireButtonName;
        [Tooltip("����������� ���������� ���������� �� ��������� ��� ������� ������ (�������)")]
            [SerializeField] private float maxStartAngle;
        [Tooltip("�������� ������ ��� �������")]
            [SerializeField] private float startSpeed;

        [Header("Acceleration settings")]
        [Tooltip("����������� ��������� ������ (���������������� ������ FixedUpdate)")]
            [SerializeField] private float accelerationCoef;
        [Tooltip("������������ �������� ������")] // ���� ��������� ���������� �� ����� ������ FixedUpdate
            [SerializeField] private float maxSpeed;

        private void Start()
        {
            startPosition = transform.position;
            myRigidbody = GetComponent<Rigidbody>();
            PrepareToLaunch();
        }

        private void Launch ()
        {
            float launchingAngle = Random.Range(-maxStartAngle, maxStartAngle);
            myRigidbody.velocity = startSpeed * Vector3.RotateTowards(Vector3.up, Vector3.right, launchingAngle, 0);
            coroutine = StartCoroutine(Accelerating_Routine());
        }

        public void PrepareToLaunch()
        {
            myRigidbody.velocity = Vector3.zero;
            transform.position = startPosition;
            transform.rotation = Quaternion.identity;

            if (coroutine!=null)
            {
                StopCoroutine(coroutine);
            }
            coroutine = StartCoroutine(WaitingForLaunch_Routine());
        }

        Coroutine coroutine;
        
        IEnumerator WaitingForLaunch_Routine ()
        {
            Debug.Log("Start waiting for launch");
            while (true)
            {
                if (Input.GetButton(fireButtonName))
                {
                    Debug.Log("Fire the ball!");
                    break; 
                }
                yield return null;
            }
            StopCoroutine(coroutine);
            Launch();
            yield return null;
        }

        IEnumerator Accelerating_Routine ()
        {
            float debugTimer;
            debugTimer = 0f;

            while (myRigidbody.velocity.magnitude < maxSpeed)
            {
                myRigidbody.velocity *= accelerationCoef;
                debugTimer += Time.fixedDeltaTime;
                yield return new WaitForFixedUpdate();
            }
            Debug.Log("Max speed = " + myRigidbody.velocity.magnitude + " in " + debugTimer + " seconds");
            myRigidbody.velocity = myRigidbody.velocity.normalized * maxSpeed;
            StopCoroutine(coroutine);
            yield return null;
        }
    }
}
