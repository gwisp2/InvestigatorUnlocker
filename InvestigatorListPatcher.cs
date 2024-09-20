using System.Collections.Generic;
using System.Linq;
using HarmonyLib;

namespace InvestigatorUnlocker;

[HarmonyPatch(typeof(MoMDatabase))]
public class InvestigatorListPatcher
{
    [HarmonyPrefix]
    [HarmonyPatch("GetAvailableInvestigators")]
    static bool PreGetAvailableInvestigators(ref IEnumerable<InvestigatorModel> __result)
    {
        var hashSet = new HashSet<InvestigatorModel>();
        var productCollection = UserCollectionManager.GetProductCollection();
        foreach (var productModel in productCollection.Keys)
        {
            hashSet.UnionWith(productModel.Investigators);
        }
        __result = hashSet.OrderBy(i => Localization.Get(i.Name.Key));
        return false;
    }
}