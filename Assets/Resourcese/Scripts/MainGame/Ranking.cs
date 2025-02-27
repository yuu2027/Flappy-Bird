using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    /* 値 */
    string[] rankNames = { "1st", "2nd", "3rd" };        // ランキング名
    const int rankCnt = SaveData.rankCnt;                 // ランキング数

    /* コンポーネント取得用 */
    [SerializeField]
    TextMeshProUGUI[] rankTexts = new TextMeshProUGUI[rankCnt];              // ランキングのテキスト
    [SerializeField]
    private Timer timer;
    SaveData data;                                       // 参照するセーブデータ

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
