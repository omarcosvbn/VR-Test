using UnityEngine;
using UnityEngine.InputSystem;

public class InputControllerEsquerdo : MonoBehaviour
{
    [Header("Referência ao Gerenciador")]
    public Photo360Manager photoManager;

    [Header("Atalho do Teclado para Testes no Editor")]
    [Tooltip("Tecla para abrir/fechar o painel no simulador.")]
    public Key teclaAtalho = Key.G;

    private void Update()
    {
        if (Keyboard.current != null && Keyboard.current[teclaAtalho].wasPressedThisFrame)
        {
            AlternarPainel();
        }
    }

    private void AlternarPainel()
    {
            photoManager.AlternarPainelInfo();
    }
}