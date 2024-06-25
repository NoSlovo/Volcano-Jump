using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PolicyLoader : MonoBehaviour
{
  [SerializeField]
    private UniWebView webBrowser;
    [SerializeField]
    private string policyUrl;
    [SerializeField]
    private GameObject noConnectionUI;
    [SerializeField]
    private GameObject loadingIndicatorUI;
    [SerializeField]
    private GameObject policyBgUI, alternateBgUI;

    private bool isPolicyPageLoaded = false;
    private bool isRetrying = false;
    private const string PolicyConfirmationKey = "PolicyConfirmation";

    private void Start()
    {
        ConfigureScreenOrientation();
        CheckInternetOnStart();
    }

    private void ConfigureScreenOrientation()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }

    private void CheckInternetOnStart()
    {
        if (IsInternetUnavailable())
        {
            DisplayNoInternetUI();
        }
        else
        {
            ProceedWithPolicyCheck();
        }
    }

    private bool IsInternetUnavailable()
    {
        return Application.internetReachability == NetworkReachability.NotReachable;
    }

    private void DisplayNoInternetUI()
    {
        loadingIndicatorUI.SetActive(false);
        noConnectionUI.SetActive(true);
    }

    private IEnumerator TryReconnectAndProceed()
    {
        isRetrying = true;
        while (IsInternetUnavailable())
        {
            DisplayNoInternetUI();
            yield return new WaitForSeconds(5f);
        }
        isRetrying = false;
        LoadPolicyPage();
    }

    private void LoadPolicyPage()
    {
        noConnectionUI.SetActive(false);
        loadingIndicatorUI.SetActive(true);
        StartPolicyPageLoading();
    }

    private void StartPolicyPageLoading()
    {
        webBrowser.OnPageFinished += OnPolicyPageLoadComplete;
        webBrowser.Load(policyUrl);
    }

    private void OnPolicyPageLoadComplete(UniWebView webBrowser, int statusCode, string currentUrl)
    {
        if (isPolicyPageLoaded) return;

        UpdateUIForPolicyPage(currentUrl);
        webBrowser.Show();

        if (policyUrl != currentUrl)
        {
            Destroy(this.gameObject);
        }

        isPolicyPageLoaded = true;
        loadingIndicatorUI.SetActive(false);
    }

    private void UpdateUIForPolicyPage(string currentUrl)
    {
        bool isPolicyPage = currentUrl == policyUrl;
        policyBgUI.SetActive(isPolicyPage);
        alternateBgUI.SetActive(!isPolicyPage);
        Screen.orientation = isPolicyPage ? ScreenOrientation.Portrait : ScreenOrientation.AutoRotation;
        PlayerPrefs.SetString(PolicyConfirmationKey, isPolicyPage ? "Accepted" : currentUrl);
    }

    public void OnUserPolicyConfirmation()
    {
        ProceedWithPolicyCheck();
    }

    private void ProceedWithPolicyCheck()
    {
        string confirmationStatus = PlayerPrefs.GetString(PolicyConfirmationKey, "");
        if (string.IsNullOrEmpty(confirmationStatus))
        {
            if (!isRetrying)
            {
                StartCoroutine(TryReconnectAndProceed());
            }
        }
        else if (confirmationStatus == "Accepted")
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            ShowPreviouslyLoadedPolicyPage(confirmationStatus);
        }
    }

    private void ShowPreviouslyLoadedPolicyPage(string url)
    {
        webBrowser.Load(url);
        webBrowser.Show();
        alternateBgUI.SetActive(true);
    }

    public void RetryLoadingPolicy()
    {
        CheckInternetOnStart();
    }

    // New feature: Manual Internet Check
    public void ManualInternetCheck()
    {
        if (IsInternetUnavailable())
        {
            DisplayNoInternetUI();
        }
        else
        {
            noConnectionUI.SetActive(false);
            LoadPolicyPage();
        }
    }

    // New feature: Clear Policy Confirmation
    public void ClearPolicyConfirmation()
    {
        PlayerPrefs.DeleteKey(PolicyConfirmationKey);
        PlayerPrefs.Save();
    }
}
