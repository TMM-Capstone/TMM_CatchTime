using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    private static AudioPlay instance; // AudioPlay 클래스의 인스턴스를 저장하기 위한 변수
    private AudioSource audioSource;

    private void Awake()
    {
        // 인스턴스가 null인 경우에만 현재 인스턴스를 저장
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시 파괴되지 않도록 설정
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            // 이미 인스턴스가 있을 경우 현재 GameObject를 파괴하여 중복 생성을 방지
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    public void PlayMusic()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }
}