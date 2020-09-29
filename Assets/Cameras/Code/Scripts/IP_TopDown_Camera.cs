using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;

namespace IndiePixel.Cameras
{
    public class IP_TopDown_Camera : MonoBehaviour
    {
        public Transform m_target;
        public float m_Height = 10f;
        public float m_Distance = 20f;
        public float m_Angle = 45f;
        public float M_SmoothSpeed = 0.5f;
        private Vector3 refVelocity;

        // Start is called before the first frame update
        void Start()
        {
            HandleCamera();
        }

        // Update is called once per frame
        void Update()
        {
            HandleCamera();
        }

        protected virtual void HandleCamera()
        {
            if (!m_target)
            {
                return;
            }

            // World position vector
            Vector3 worldPosition = (Vector3.forward * -m_Distance) + (Vector3.up * m_Height);
            //Debug.DrawLine(m_target.position, worldPosition, Color.red);

            //Build a rotated vector
            Vector3 rotatedVector = Quaternion.AngleAxis(m_Angle, Vector3.up) * worldPosition;
            //Debug.DrawLine(m_target.position, rotatedVector, Color.green);

            //Move the camera with the object
            Vector3 flatTargetposition = m_target.position;
            flatTargetposition.y = 0f;
            Vector3 finalposition = flatTargetposition + rotatedVector;
            //Debug.DrawLine(m_target.position, finalposition, Color.blue);

            transform.position = Vector3.SmoothDamp(transform.position, finalposition, ref refVelocity, M_SmoothSpeed);
            transform.LookAt(flatTargetposition);
        }

        void OnDrawGizmos()
        {
            Gizmos.color = new Color(0f, 1f, 0f, 0.25f);
            if (m_target)
            {
                Gizmos.DrawLine(transform.position, m_target.position);
                Gizmos.DrawSphere(m_target.position, 1.5f);
            }
            Gizmos.DrawSphere(transform.position, 1.5f);
        }

    }
}