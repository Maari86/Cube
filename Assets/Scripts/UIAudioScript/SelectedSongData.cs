using UnityEngine;

[CreateAssetMenu(fileName = "SelectedSongData", menuName = "Music/Selected Song Data")]
public class SelectedSongData : ScriptableObject
{
    //public AudioClip selectedSong;
    public string songName;
    public string songLocation;
    public AudioType songFormat;
}
