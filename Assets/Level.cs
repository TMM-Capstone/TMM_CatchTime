using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class for defining a level range and the corresponding experience cap increase for that range
[System.Serializable]
public class LevelRange
{
    // ���� ����
    //���� ����
    public int startLevel;
    // ������
    public int endLevel;
    // ����ġ��
    public int experienceCapIncrease;
}


public class Level : MonoBehaviour
{
    [Header("Experience/Level")]
    public int experience = 0;
    public int level = 1;
    public int experienceCap;

    // �젫 ���� ����Ʈ
    public List<LevelRange> levelRanges;

    void Start()
    {
        // ����Ʈ 0��°�� ����ġ�� �ҷ�����
        experienceCap = levelRanges[0].experienceCapIncrease;
    }

    public void IncreaseExperience(int amount)
    {
        // ������ ����ġ ���ϱ�
        experience += amount;

        // ������ �ϴ��� Ȯ��
        LevelUpChecker();
    }

    void LevelUpChecker()
    {
        // ���� ����ġ�� �����ٸ�?
        if (experience >= experienceCap)
        {
            // ���� ��
            level++;
            // ����ġ �ٿ��ֱ�
            experience -= experienceCap;

            int experienceCapIncrease = 0;
            foreach (LevelRange range in levelRanges)
            {
                /*
                 * ���� ���� ������ ����Ʈ�ȿ� �ִ� startLevel���� ũ�� endLevel���� ������ �����ϰ� ����������
                 * �����ϰ� 0�� ����Ʈ�� ������ ������ ������ �ʱ�ȭ
                 */
                if (level >= range.startLevel && level <= range.endLevel)
                {
                    experienceCapIncrease = range.experienceCapIncrease;
                    break;
                }
            }

            experienceCap += experienceCapIncrease;
        }
    }

}
