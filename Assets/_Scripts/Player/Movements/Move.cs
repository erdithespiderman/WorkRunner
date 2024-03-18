using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Player
{
    public class Move : MonoBehaviour
    {


        // Update is called once per frame

        public float moveSpeed = 5f;

        void Update()
        {
            // Yatay eksen giri�ini al
            float moveInput = Input.GetAxisRaw("Horizontal");

            // Hareket vekt�r� olu�tur
            Vector3 moveDirection = new Vector3(moveInput, 0f, 0f).normalized;

            // Hareketi uygula
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        }
    }
}

