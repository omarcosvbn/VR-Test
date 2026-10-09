using UnityEngine;
using UnityEngine.InputSystem;

public class InputControllerEsquerdo : MonoBehaviour
{
    [Header("Referência ao Gerenciador")]
    public Photo360Manager photoManager;

    [Header("Ação do Trigger Esquerdo")]
    [Tooltip("Arraste a Input Action correspondente ao Trigger do Left Controller.")]
    public InputActionProperty leftTriggerAction;

    private void OnEnable()
    {
        leftTriggerAction.action.Enable();
        leftTriggerAction.action.performed += OnTriggerPressed;
    }

    private void OnDisable()
    {
        leftTriggerAction.action.performed -= OnTriggerPressed;
        leftTriggerAction.action.Disable();
    }

    private void OnTriggerPressed(InputAction.CallbackContext context)
    {
            photoManager.AlternarPainelInfo();
    }
}