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

            if (source.Effect == sfx)
            {
                if (sfx == Sfx.voice1 || sfx == Sfx.voice2 || sfx == Sfx.angvoice)
                {
                    source.Source.pitch = Random.Range(1.2f, 1.5f);
                }

                source.Source.Play();
            }
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
    ring, message, click, voice1, voice2, angvoice, hangup
}
