using System.Collections.Generic;
using UnityEngine;
using TMPro; // Usando TextMeshPro para UI em VR

public class Photo360Manager : MonoBehaviour
{
    [Header("Exibição da Foto")]
    public Renderer esferaRenderer;

    [Header("Painel de Informações (UI)")]
    public GameObject painelInfoUI;
    public TextMeshProUGUI textoTitulo;
    public TextMeshProUGUI textoDescricao;

    [Header("Banco de Dados das Fotos")]
    public List<FotoInfo> listaFotos = new List<FotoInfo>();

    [Header("Histórico")]
    public Texture2D imagemAtual;
    public Texture2D imagemAnterior;

    private void Start()
    {
            imagemAtual = (Texture2D)esferaRenderer.material.GetTexture("_BaseMap");
            AtualizarUI();
        
            painelInfoUI.SetActive(false);   
    }

    public Texture2D TransitarParaFoto(Texture2D novaFoto)
    {

        imagemAnterior = imagemAtual;
        imagemAtual = novaFoto;

        esferaRenderer.material.SetTexture("_BaseMap", imagemAtual);

        AtualizarUI();

        return imagemAnterior;
    }

    public void AlternarPainelInfo()
    {
            bool estadoAtual = painelInfoUI.activeSelf;
            painelInfoUI.SetActive(!estadoAtual);
    }

    private void AtualizarUI()
{
    if (imagemAtual == null) return;

    FotoInfo info = listaFotos.Find(f => f.textura360 != null && f.textura360.name == imagemAtual.name);

    if (info != null)
    {
        if (textoTitulo != null) textoTitulo.text = info.titulo;
        if (textoDescricao != null) textoDescricao.text = info.descricao;
    }
    else
    {
        if (textoTitulo != null) textoTitulo.text = imagemAtual.name;
        if (textoDescricao != null) textoDescricao.text = "Sem descrição cadastrada na Lista Fotos.";
    }
}
}