using UnityEngine;


public class SFXManager : MonoBehaviour
{
    public AudioClip bloodCellClip;
    public AudioClip invaderCellClip;

    private AudioSource _source;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
    }

    public void PlayBloodCellClip()
    {
        _source.clip = bloodCellClip;
        _source.Play();
    }

    public void PlayInvaderCellClip()
    {
        _source.clip = invaderCellClip;
        _source.Play();
    }
}
