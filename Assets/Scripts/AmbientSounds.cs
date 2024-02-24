using UnityEngine;

public class AmbientSounds : MonoBehaviour
{
    AudioSource _audioSource;
    int lastReturnedClipIndex = -1;
    [SerializeField] AudioClip[] _audioClips;
    [SerializeField] [Range(3f, 20f)] float _timeBetweenPlaysMin = 5f;
    [SerializeField] [Range(3f, 20f)] float _timeBetweenPlaysMax = 10f;
    float _timeBetweenPlays;
    float _timer;
    [SerializeField] [Range(0f, 1f)] float _volumeMin;
    [SerializeField] [Range(0f, 1f)] float _volumeMax;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        UpdateTimeBetweenPlays();
        PlayRandomClip();
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _timeBetweenPlays)
        {
            PlayRandomClip();
            UpdateTimeBetweenPlays();
            _timer = 0;
        }
    }

    void PlayRandomClip()
    {
        _audioSource.PlayOneShot(RandomClip(), Random.Range(_volumeMin, _volumeMax));
    }

    void UpdateTimeBetweenPlays()
    {
        _timeBetweenPlays = Random.Range(_timeBetweenPlaysMin, _timeBetweenPlaysMax);
    }

    /// <summary>
    /// Returns a random sound different from the last returned.
    /// </summary>
    AudioClip RandomClip()
    {
        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, _audioClips.Length);
        } while (randomIndex == lastReturnedClipIndex);

        lastReturnedClipIndex = randomIndex;
        return _audioClips[randomIndex];
    }
}
