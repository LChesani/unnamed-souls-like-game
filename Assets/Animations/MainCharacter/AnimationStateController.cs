using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    [SerializeField] MainCharacter self;
    [SerializeField] GameObject thirdPersonCam;
    float rotationSpeed = 2.0f * 720.0f; // Velocidade de rotação do personagem.
    float currentRotationSpeed; // Velocidade atual de rotação.

    float timerRoll;

    void Start()
    {
        animator = GetComponent<Animator>();
        currentRotationSpeed = rotationSpeed;
        timerRoll = 0;
    }

    void roll()
    {
        if (timerRoll > 0.0f)
        {
            timerRoll -= Time.deltaTime;
        }
        if (timerRoll <= 0)
        {
            animator.SetBool("isDashing", false);
            self.dashing = false;
            if (Input.GetKeyDown(KeyCode.Space) && timerRoll <= 0.0f && self.getStamina().x > 50.0f && self.isRunning)
            {
                self.dashing = true;
                timerRoll = 0.5f;
                self.adjustStamina(-50.0f);
                animator.SetBool("isDashing", true);
            }
        }
    }

    void rotate(float horizontalInput, float verticalInput)
    {
        // Calcule a direção de rotação com base nas teclas pressionadas.
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        if (direction != Vector3.zero)
        {
            // Calcule o ângulo de rotação em graus.
            float targetRotationAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

            // Gire o personagem suavemente em direção ao ângulo calculado, considerando a rotação da câmera.
            float cameraRotationAngle = thirdPersonCam.transform.rotation.eulerAngles.y;
            targetRotationAngle += cameraRotationAngle; // Adicione a rotação da câmera

            Quaternion targetRotation = Quaternion.Euler(0, targetRotationAngle, 0);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, currentRotationSpeed * Time.deltaTime);
        }

        // Reduza gradualmente a velocidade de rotação quando não houver entrada.
        if (direction == Vector3.zero)
        {
            currentRotationSpeed = Mathf.Lerp(currentRotationSpeed, rotationSpeed, Time.deltaTime * 5.0f);
        }
        else
        {
            currentRotationSpeed = rotationSpeed;
        }
    }

    void pickItem()
    {
        if (self.pick)
        {
            animator.SetTrigger("pick");
            self.pick = false;
        }
    }


    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); // Valor de -1 a 1 para as teclas "A" e "D".
        
        self.isRunning = input.x != 0.0f || input.y != 0.0f;

        animator.SetBool("isRunning", self.isRunning);
        animator.SetBool("isFast", Input.GetKey(KeyCode.LeftShift) && self.isRunning && !self.getStaminaRunOut() );
        animator.SetBool("inAltar", self.inAltar && !self.isRunning);
        animator.SetBool("isHealing", self.healing);
        animator.SetBool("isAttacking", Input.GetMouseButton(0) && (self.Using != null) && (self.Stamina.x > self.Using.staminaCost));
        pickItem();
        rotate(input.x, input.y);
        roll();
    }
}
