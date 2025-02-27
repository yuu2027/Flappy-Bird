using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    /* �l */
    string[] rankNames = { "1st", "2nd", "3rd" };        // �����L���O��
    const int rankCnt = SaveData.rankCnt;                 // �����L���O��

    /* �R���|�[�l���g�擾�p */
    [SerializeField]
    TextMeshProUGUI[] rankTexts = new TextMeshProUGUI[rankCnt];              // �����L���O�̃e�L�X�g
    [SerializeField]
    private Timer timer;
    SaveData data;                                       // �Q�Ƃ���Z�[�u�f�[�^

    private void Start()
    {
        data = GetComponent<DataManager>().data;

    }

    public void SetRank()
    {
        float score = timer.gametimer;
        for(int i = 0; i < rankCnt; i++)
        {
            if (score > data.rank[i])
            {
                var rep = data.rank[i];
                data.rank[i] = score;
                score = rep;
            }
        }
        DispRank();
    }

    private void DispRank()
    {
        for(int i = 0; i< rankCnt; i++)
        {
            if (data.rank[i] != 0)
            {
                rankTexts[i].text = data.rank[i].ToString("f2");
            }
        }
    }
}
