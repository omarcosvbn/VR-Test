using UnityEngine;

public class Photo360Manager : MonoBehaviour
{
    [Header("Componente de Exibição")]
    [Tooltip("Arraste aqui a Esfera Invertida/Mesh Renderer.")]
    public Renderer esferaRenderer;

    [Header("Histórico de Fotos")]
    [Tooltip("Guarda a foto que está sendo exibida no momento.")]
    public Texture2D imagemAtual;
    
    [Tooltip("Guarda a foto exibida anteriormente (ponto de retorno).")]
    public Texture2D imagemAnterior;

    private void Start()
    {
            imagemAtual = (Texture2D)esferaRenderer.material.GetTexture("_BaseMap");
    }

    public Texture2D TransitarParaFoto(Texture2D novaFoto)
    {
        imagemAnterior = imagemAtual;
        imagemAtual = novaFoto;

        esferaRenderer.material.SetTexture("_BaseMap", imagemAtual);

        return imagemAnterior;
    }
}