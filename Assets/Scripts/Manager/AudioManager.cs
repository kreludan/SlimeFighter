using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private List<AudioSource> listAudioSource;
    public List<AudioSource> ListAudioSource => listAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAudioSource(int audioNum)
    {
        listAudioSource[audioNum].Play();
    }

}
