using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance;
    [SerializeField] private SfxSource[] _sfxSources;

    public void Awake()
    {
        Instance = this;
    }

    public void PlayAudio(Sfx sfx)
    {
        foreach (var source in _sfxSources)
        {
            if (source.Effect == sfx) source.Source.Play();
        }
    }

    public void StopAudio(Sfx sfx)
    {
        foreach (var source in _sfxSources)
        {
            if (source.Effect == sfx) source.Source.Stop();
        }
    }
}

[System.Serializable]
public class SfxSource
{
    public Sfx Effect;
    public AudioSource Source;
}

public enum Sfx
{
    ring, message, click
}
