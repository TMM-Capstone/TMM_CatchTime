using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    private static AudioPlay instance; // AudioPlay Ŭ������ �ν��Ͻ��� �����ϱ� ���� ����
    private AudioSource audioSource;

    private void Awake()
    {
        // �ν��Ͻ��� null�� ��쿡�� ���� �ν��Ͻ��� ����
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // �� ��ȯ �� �ı����� �ʵ��� ����
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            // �̹� �ν��Ͻ��� ���� ��� ���� GameObject�� �ı��Ͽ� �ߺ� ������ ����
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