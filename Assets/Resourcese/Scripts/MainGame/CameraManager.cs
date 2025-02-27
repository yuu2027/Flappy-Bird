using System.Collections;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // シェイクの強さ
    [SerializeField] float shakeDuration = 0.5f; // シェイクが続く時間
    [SerializeField] float shakeMagnitude = 0.4f; // シェイクの強さ

    // 元のカメラ位置を保存するための変数
    private Vector3 originalPos;

    void Start()
    {
        // 初期のカメラ位置を保存
        originalPos = transform.localPosition;
    }

    // コルーチンでシェイクを行う
    public IEnumerator Shake()
    {
        float elapsed = 0.0f;

        while (elapsed < shakeDuration)
        {
            // ランダムにカメラの位置を揺らす
            float x = Random.Range(-1f, 1f) * shakeMagnitude;
            float y = Random.Range(-1f, 1f) * shakeMagnitude;

            // 新しい位置にカメラを移動
            transform.localPosition = new Vector3(originalPos.x + x, originalPos.y + y, originalPos.z);

            // 経過時間を更新
            elapsed += Time.deltaTime;

            yield return null;
        }

        // シェイクが終わったら元の位置に戻す
        transform.localPosition = originalPos;
    }
}
