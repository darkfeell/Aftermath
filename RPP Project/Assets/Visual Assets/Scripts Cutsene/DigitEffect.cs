using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(AudioSource))]

public class DigitEffect : MonoBehaviour
{
    private TextMeshProUGUI componenteTexto;
    private AudioSource _audioSource;
    private string mensagemOriginal;
    public bool imprimindo;

    private void Awake()
    {

    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }
}
