using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    private Vector3 defaultPosition;

    // buat dummy target untuk set variabel target ke dummy target saat FocusAtTarget
    public Transform dummyTarget;

    private void Start()
    {
        defaultPosition = transform.position;
        target = null;
    }

    private void Update()
    {
        // space untuk bergerak ke posisi target
        if (Input.GetKey(KeyCode.Space))
        {
            FocusAtTarget(dummyTarget);
        }

        // tombol R untuk membuatnya kembali ke posisi default
        if (Input.GetKey(KeyCode.R))
        {
            GoBackToDefault();
        }
    }

    public void FocusAtTarget(Transform targetTransform)
    {
        // ubah target
        target = targetTransform;
    
    // disini perlu ditambahkan kalkulasi posisi kamera dari target
    // masih kosong

        // dan fungsi untuk menggerakan kameranya
    StartCoroutine(MovePosition(targetTransform.position, 5));
    }

    // belum dipakai
    public void GoBackToDefault()
    {
        target = null;

        // disini perlu ditambahkan fungsi untukmengggerakan ke posisi default
    }

    private IEnumerator MovePosition(Vector3 target, float time)
    {
        float timer = 0;
        Vector3 start = transform.position;

        while (timer < time)
        {
            // pindahkan posisi camera secara bertahap menggunakan Lerp
            // Lerp ini kita tambahkan smoothing menggunakan SmoothStep
            transform.position = Vector3.Lerp(start, target, Mathf.SmoothStep(0.0f, 1.0f, timer / time));

            // di lakukan berulang2 tiap frame selama parameter time
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        // kalau proses pergerakan sudah selesai, kamera langsung dipaksa pindah
        // ke posisi target tepatnya agar tidak bermasalah nantinya
        transform.position = target;
    }
}
