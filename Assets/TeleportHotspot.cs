using UnityEngine;

public class TeleportHotspot : MonoBehaviour
{
    [Header("Referência ao Gerenciador")]
    public Photo360Manager photoManager;

    [Header("Foto de Destino Deste Hotspot")]
    [Tooltip("A foto para onde este portal vai te levar.")]
    public Texture2D fotoDestino;

    public void MudarFoto()
    {
        Texture2D fotoDeOndeVim = photoManager.TransitarParaFoto(fotoDestino);
        fotoDestino = fotoDeOndeVim;
    }
}