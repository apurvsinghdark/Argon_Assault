using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private void Awake()
    {
        int numOfMusicPlayer = FindObjectsOfType<MusicPlayer>().Length;
        
        if (numOfMusicPlayer > 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);
    }
}
