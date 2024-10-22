using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Sounds : MonoBehaviour
{
    [SerializeField] private AudioClip[] _audioClips;
    [SerializeField] private float[] _volumes;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public static void PlaySound(int index)
    {

    }
}
