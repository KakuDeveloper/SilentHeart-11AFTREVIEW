using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
    public GameObject ghostPrefab;
    private GameObject currentGhost;
    public float currentRespawnTimer;
    public float respawnTimer;
    private BoxCollider2D spawnArea; // Tambahkan Collider2D untuk menentukan area spawn

    void Start()
    {
        spawnArea = gameObject.GetComponent<BoxCollider2D>();
        currentRespawnTimer = respawnTimer;
        // Memanggil metode SpawnGhost pada awal permainan
        SpawnGhost();
    }

    void Update()
    {
        // Cek apakah ghost sudah di-spawn
        if (currentGhost == null)
        {
            // Jika ghost di-destroy, atur timer untuk spawn ghost berikutnya
            currentRespawnTimer -= Time.deltaTime;

            if (currentRespawnTimer <= 0)
            {
                // Reset timer dan spawn ghost baru
                currentRespawnTimer = respawnTimer;
                SpawnGhost();
            }
        }
    }

    void SpawnGhost()
    {
        // Mengecek apakah spawnArea telah diatur
        if (spawnArea == null)
        {
            Debug.LogError("Spawn area collider not set!");
            return;
        }

        // Mendapatkan batasan spawnArea
        Bounds bounds = spawnArea.bounds;

        // Menghasilkan posisi acak dalam batasan spawnArea
        Vector2 randomSpawnPoint = new Vector2(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y)
        );

        // Membuat instance baru dari ghostPrefab pada posisi acak yang dihasilkan
        currentGhost = Instantiate(ghostPrefab, randomSpawnPoint, Quaternion.identity);
    }
}