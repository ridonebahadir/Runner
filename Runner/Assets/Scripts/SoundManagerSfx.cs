using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerSfx : MonoBehaviour
{
    [Header("AUDÝO SFX")]
    public static AudioClip coinCollect;
    public static AudioClip levelUp;
    public static AudioClip DoorUpMoney;
    public static AudioClip DoorDownMoney;
   
    static AudioSource audioSrc;
    private void Start()
    {
        coinCollect = Resources.Load<AudioClip> ("Money");
        levelUp = Resources.Load<AudioClip> ("LevelUp");
        DoorUpMoney = Resources.Load<AudioClip> ("DoorUpMoney");
        DoorDownMoney = Resources.Load<AudioClip> ("DoorDownMoney");
        
        audioSrc = GetComponent<AudioSource>();
    }
    public static void PlaySfx(string clip)
    {
        switch (clip)
        {
            case "Money":
                audioSrc.PlayOneShot(coinCollect);
                Debug.Log("PARA SESÝ");
                break;
            //SoundManagerSfx.PlaySfx("GlassBreakk");
            case "LevelUp":
                audioSrc.PlayOneShot(levelUp);
                Debug.Log("LEVELUP SESÝ");
                break;
            case "DoorUpMoney":
                audioSrc.PlayOneShot(DoorUpMoney);
                Debug.Log("DoorUpMoney SESÝ");
                break;
            case "DoorDownMoney":
                audioSrc.PlayOneShot(DoorDownMoney);
                Debug.Log("DoorDownMoney SESÝ");
                break;
            default:
                break;
        }
    }
}
