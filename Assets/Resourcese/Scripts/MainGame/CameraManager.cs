using System.Collections;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // �V�F�C�N�̋���
    [SerializeField] float shakeDuration = 0.5f; // �V�F�C�N����������
    [SerializeField] float shakeMagnitude = 0.4f; // �V�F�C�N�̋���

    // ���̃J�����ʒu��ۑ����邽�߂̕ϐ�
    private Vector3 originalPos;

    void Start()
    {
        // �����̃J�����ʒu��ۑ�
        originalPos = transform.localPosition;
    }

    // �R���[�`���ŃV�F�C�N���s��
    public IEnumerator Shake()
    {
        float elapsed = 0.0f;

        while (elapsed < shakeDuration)
        {
            // �����_���ɃJ�����̈ʒu��h�炷
            float x = Random.Range(-1f, 1f) * shakeMagnitude;
            float y = Random.Range(-1f, 1f) * shakeMagnitude;

            // �V�����ʒu�ɃJ�������ړ�
            transform.localPosition = new Vector3(originalPos.x + x, originalPos.y + y, originalPos.z);

            // �o�ߎ��Ԃ��X�V
            elapsed += Time.deltaTime;

            yield return null;
        }

        // �V�F�C�N���I������猳�̈ʒu�ɖ߂�
        transform.localPosition = originalPos;
    }
}
