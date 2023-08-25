using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    //menyimpan variabel bola sebagai referensi untuk pengecekan
    public Collider bola;

    //untuk mengatur kecepatan bola setelah memantul
    public float multiplier;

    // untuk mengatur warna bumper
    public Color color;

    // komponen renderer pada object yang akan diubah
    private Renderer renderer;

    // kita tambahkan reference animator
    private Animator animator;

    // tambahkan audio manager untuk mengakses fungsi pada audio managernya
    public AudioManager audioManager;

    private void Start()
    {
        // karena material ada pada component Rendered, maka kita ambil renderernya
        renderer = GetComponent<Renderer>();

        // kita akses materialnya dan kita ubah warna nya saat Start
        renderer.material.color = color;

        // ambil animatornya saat Start
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //ambil rigidbody nya lalu kali kecepatannya sebanyak multiplier agar bisa memantul lebih cepat
        Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
        bolaRig.velocity *= multiplier;

        // saat ditabrak oleh bola, kita tinggal aktifkan trigger Hit
        animator.SetTrigger("Hit");

        // kita jalankan SFX saat tabrakan dengan bola pada posisi tabrakannya
        audioManager.PlaySFX(collision.transform.position);
    }
}
