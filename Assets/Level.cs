using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class for defining a level range and the corresponding experience cap increase for that range
[System.Serializable]
public class LevelRange
{
    // 레벨 범위
    //시작 레벨
    public int startLevel;
    // 끝레벨
    public int endLevel;
    // 경험치량
    public int experienceCapIncrease;
}


public class Level : MonoBehaviour
{
    [Header("Experience/Level")]
    public int experience = 0;
    public int level = 1;
    public int experienceCap;

    // 헤젷 전뤼 리스트
    public List<LevelRange> levelRanges;

    void Start()
    {
        // 리스트 0번째의 경험치량 불러오기
        experienceCap = levelRanges[0].experienceCapIncrease;
    }

    public void IncreaseExperience(int amount)
    {
        // 들어오는 경험치 더하기
        experience += amount;

        // 레벨업 하는지 확인
        LevelUpChecker();
    }

    void LevelUpChecker()
    {
        // 만약 경험치가 꽌찬다면?
        if (experience >= experienceCap)
        {
            // 레벨 업
            level++;
            // 경험치 줄여주기
            experience -= experienceCap;

            int experienceCapIncrease = 0;
            foreach (LevelRange range in levelRanges)
            {
                /*
                 * 만약 현재 레벨이 리스트안에 있는 startLevel보다 크고 endLevel보다 적으면 실행하고 빠져나오기
                 * 간단하게 0범 리스트에 조건이 맞으면 나오고 초기화
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
