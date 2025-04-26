using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    RaceAPIResponse apiResponse;
    private bool raceFinished = false;
    private TaskCompletionSource<bool> dataReady = new TaskCompletionSource<bool>();

    private void Awake()
    {
        // Debug.Log($"Aa");
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        FetchWinnerData();

    }

    public void BikeFinished(AIBikeController bike)
    {
        if (raceFinished)
            return;

        raceFinished = true;
       // Debug.Log("Winner: " + bike.apiPlayerName);

    }


    private async void FetchWinnerData()
     {
        string apiUrl = "https://api.dnaracing.run/fbike/races/mini/8952172f22";

        UnityWebRequest request = UnityWebRequest.Get(apiUrl);
        request.timeout = 10;

        var asyncOp = request.SendWebRequest();

        while (!asyncOp.isDone)
        await Task.Yield(); // Non-blocking wait

        if (request.result == UnityWebRequest.Result.Success)
        {
            string json = request.downloadHandler.text;
            apiResponse = JsonConvert.DeserializeObject<RaceAPIResponse>(json);

            if (apiResponse.status == "success")
            {
                Debug.Log("API data fetched successfully.");
                dataReady.TrySetResult(true);
                return;
            }
        }
        Debug.LogError("API fetch failed: " + request.error);
        dataReady.TrySetResult(false); // Avoid deadlock
    }
    public async Task<RaceResult> GetApiResponseAsync()
    {
        await dataReady.Task; // Wait until data is ready
        return apiResponse.result;
    }
}
