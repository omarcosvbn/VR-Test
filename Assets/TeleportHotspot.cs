using UnityEngine;

public class TeleportHotspot : MonoBehaviour
{
    [Header("Objeto da Foto 360")]
    [Tooltip("Arraste aqui a Esfera Invertida onde a foto 360 é exibida.")]
    public Renderer esferaRenderer;

    [Header("Configurações da Nova Foto")]
    [Tooltip("Arraste a nova textura 360 para esta variável.")]
    public Texture2D novaFoto360;

    public void MudarFoto()
    {
        esferaRenderer.material.SetTexture("_BaseMap", novaFoto360);
    }
}