using System.Collections.Generic;
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
        bool shouldGrant = true;
        foreach (KeyValuePair<string, bool> kvp in results.toggleValues)
            if (kvp.Value != true)
                shouldGrant = false;
        
        if(shouldGrant)
            Advertising.GrantDataPrivacyConsent();
        
        if (!RuntimeManager.IsInitialized())
        {
            RuntimeManager.Init();
        }
    }
}