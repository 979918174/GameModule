using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Common
{
    public class BillboardUi : MonoBehaviour
    {
        private Camera playerCamera;
        // Start is called before the first frame update
        void Start()
        {
            playerCamera = Camera.main;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            LookAtPlayer();
        }

        private void LookAtPlayer()
        {
            transform.LookAt(transform.position + playerCamera.transform.rotation * Vector3.forward, playerCamera.transform.rotation * Vector3.up);
        }
    }

}

