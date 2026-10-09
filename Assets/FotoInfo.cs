using UnityEngine;

[System.Serializable]
public class FotoInfo
{
    public string idFoto;
    public Texture2D textura360;
    public string titulo;
    [TextArea(3, 5)]
    public string descricao;
}