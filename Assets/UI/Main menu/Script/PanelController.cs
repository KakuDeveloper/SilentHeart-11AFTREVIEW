using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelController : MonoBehaviour
{
    public GameObject settingsCanvas; // Referensi ke panel pengaturan Anda
    public GameObject canvasMenu; // Referensi ke panel pengaturan Anda
    public GameObject menuPanel; // Seret panel menu Anda ke dalam slot ini di inspector Unity

    public GameObject popUpQuit; // Seret panel setting ke dalam slot ini di inspector Unity

    void Start()
    {
        menuPanel.SetActive(true); // Tampilkan panel menu saat memulai game
    }

    public void NewGame()
    {
        ResetGameData(); // Panggil metode untuk mengatur ulang data game
        SceneManager.LoadScene("TestCharacterDimas"); // Memuat ulang scene
        Time.timeScale = 1; // Melanjutkan waktu game
    }

    private void ResetGameData()
    {
        // Reset posisi checkpoint dan kesehatan pemain
        PlayerPrefs.DeleteKey("CheckpointX");
        PlayerPrefs.DeleteKey("CheckpointY");
        PlayerPrefs.DeleteKey("CheckpointZ");
        PlayerPrefs.DeleteKey("PlayerHealth");
        PlayerPrefs.DeleteKey("CurrentLevel");
        PlayerPrefs.DeleteKey("PlayerSanity");

        // Reset semua item fragment / memory yang telah dikumpulkan
        PlayerPrefs.SetInt("TotalCollectedItems", 0);
        PlayerPrefs.DeleteKey("Item Memory 1");
        PlayerPrefs.DeleteKey("Item Memory 2");
        PlayerPrefs.DeleteKey("Item Memory 3");
        
        // Tambahkan penghapusan kunci untuk inventori
        int numberOfInventorySlots = 2; // Ganti dengan jumlah sebenarnya dari slot inventori Anda
        for (int i = 0; i < numberOfInventorySlots; i++)
        {
            PlayerPrefs.DeleteKey($"InventorySlot{i}");
        }

        PlayerPrefs.Save(); // Jangan lupa untuk menyimpan perubahan setelah menghapus
    }


    public void OpenSettings()
    {
        settingsCanvas.SetActive(true); // Menampilkan panel pengaturan
        menuPanel.SetActive(false); // Sembunyikan panel menu
    }

    public void CloseSettings()
    {
        canvasMenu.SetActive(true); // Menampilkan panel pengaturan
        settingsCanvas.SetActive(false); // Sembunyikan panel menu
        menuPanel.SetActive(true); // Sembunyikan panel menu
    }


    public void ShowPopUpQuit()
    {
        menuPanel.SetActive(false); // Sembunyikan panel menu
        popUpQuit.SetActive(true); // Menampilkan panel setting
    }

    public void BackToMenuForQuitPopUp()
    {
        menuPanel.SetActive(true); // Tampilkan panel menu
        popUpQuit.SetActive(false); // Sembunyikan panel setting
    }

    public void QuitGame()
    {
        Application.Quit(); // Keluar dari game
        Debug.Log("Quit"); // Debug
    }

}
