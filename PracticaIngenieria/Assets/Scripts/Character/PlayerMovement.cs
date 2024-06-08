﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles

{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private float bulletOffset = 0.5f;

        public CharacterController controller;

        public float speed = 1f;
        public float gravity = -15f;

        Vector3 velocity;

        bool isGrounded;

        // Update is called once per frame
        void Update()
        {

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);

            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(bulletPrefab, transform.position + Vector3.up * bulletOffset, Quaternion.identity);
            }

        }
    }
}