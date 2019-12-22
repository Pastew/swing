using EasyMobile;
using UnityEngine;

public class EasyMobileInitializer : MonoBehaviour
{
    void Awake()
    {
        ConsentDialog dialog = Privacy.GetDefaultConsentDialog();
        dialog.Show(false);
        dialog.Completed += DefaultDialog_Completed;
    }

    private void DefaultDialog_Completed(ConsentDialog dialog, ConsentDialog.CompletedResults results)
    {
        Advertising.GrantDataPrivacyConsent();

        if (!RuntimeManager.IsInitialized())
        {
            RuntimeManager.Init();
        }
    }
}