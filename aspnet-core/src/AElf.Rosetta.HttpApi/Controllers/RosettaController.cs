using AElf.Rosetta.Localization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace AElf.Rosetta.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class RosettaController : AbpControllerBase
{
    protected RosettaController()
    {
        LocalizationResource = typeof(RosettaResource);
    }
    
}
