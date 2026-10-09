using UnityEngine;

public class AnexarAoComandoEsquerdo : MonoBehaviour
{
    [Header("Referências")]
    [Tooltip("Arraste o objeto Left Controller (ou LeftHand Controller) do XR Origin.")]
    public Transform comandoEsquerdo;

    [Tooltip("Arraste a Main Camera do VR (ou deixará automático).")]
    public Transform cameraVR;

    [Header("Ajustes de Posição no Comando")]
    [Tooltip("Deslocamento em relação ao controle (X: Lado, Y: Altura acima do controle, Z: Frente).")]
    public Vector3 offsetPosicao = new Vector3(0f, 0.2f, 0.05f);

    [Header("Comportamento")]
    [Tooltip("Se verdadeiro, o painel roda suavemente para olhar na direção da câmera.")]
    public bool olharParaCamera = true;

    private void Start()
    {
        if (cameraVR == null && Camera.main != null)
        {
            cameraVR = Camera.main.transform;
        }

        // Tenta encontrar o controlador se não tiver sido atribuído no Inspector
        if (comandoEsquerdo == null)
        {
            GameObject leftHand = GameObject.Find("Left Controller") ?? GameObject.Find("LeftHand Controller");
            if (leftHand != null) comandoEsquerdo = leftHand.transform;
        }
    }

    private void LateUpdate()
    {
        if (comandoEsquerdo == null) return;

        // 1. Atualiza a posição para ficar fixo logo acima do controle
        transform.position = comandoEsquerdo.TransformPoint(offsetPosicao);

        // 2. Orienta o painel
        if (olharParaCamera && cameraVR != null)
        {
            // Aponta a frente do Canvas para a câmera do VR
            Vector3 direcaoParaCamera = cameraVR.position - transform.position;
            transform.rotation = Quaternion.LookRotation(-direcaoParaCamera);
        }
        else
        {
            // Acompanha rigidamente a rotação do próprio controle
            transform.rotation = comandoEsquerdo.rotation;
        }
    }
}