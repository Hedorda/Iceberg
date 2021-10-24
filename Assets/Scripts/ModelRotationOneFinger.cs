using System;
using UnityEngine;

namespace Custom.TouchRotation
{
    public class ModelRotationOneFinger : MonoBehaviour
    {
        Vector2 lastPos;
        float rotationSpeed = 0.5f;
        bool isNotUI;
        private GameObject _mainCamera;

        private void Start()
        {
            _mainCamera = Camera.main.gameObject;
        }

        private void Update()
        {
            if (Input.touchCount == 1)
            {
                var touch = Input.GetTouch(0);
                {
                    switch (touch.phase)
                    {
                        case TouchPhase.Began:
                            
                                lastPos = touch.position;
                            break;

                        case TouchPhase.Moved:
                            
                                var lookUp = Vector3.Normalize(_mainCamera.transform.up);
                                var lookLeft = Vector3.Normalize(-_mainCamera.transform.right);

                                
                                var rotationX = (touch.position.x - lastPos.x) * rotationSpeed;
                                var rotationY = (touch.position.y - lastPos.y) * rotationSpeed;
                                transform.Rotate(lookUp, -rotationX, Space.World);
                                transform.Rotate(lookLeft, -rotationY, Space.World);
                                lastPos = touch.position;
                            break;

                    }
                }
            }

#if UNITY_EDITOR || UNITY_STANDALONE
            if (Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.LeftControl))
            {
                lastPos = (Input.mousePosition);
            }
            else if (Input.GetMouseButton(0) && !Input.GetKey(KeyCode.LeftControl))
            {
                
                var lookUp = Vector3.Normalize(_mainCamera.transform.up);
                var lookLeft = Vector3.Normalize(-_mainCamera.transform.right);
                
                var rotationX = (Input.mousePosition.x - lastPos.x) * rotationSpeed;
                var rotationY = (Input.mousePosition.y - lastPos.y) * rotationSpeed;
                
                transform.Rotate(lookUp, -rotationX, Space.World);
                transform.Rotate(lookLeft, -rotationY, Space.World);
                
                lastPos = Input.mousePosition;
            }
            var lookFront = Vector3.Normalize(_mainCamera.transform.forward);
            var rotationZ = (Input.mouseScrollDelta.y) * rotationSpeed*4;
            transform.Rotate(lookFront, -rotationZ, Space.World);
#endif
        }
    }
}
