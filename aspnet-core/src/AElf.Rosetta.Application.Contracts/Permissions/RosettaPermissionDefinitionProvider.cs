using AElf.Rosetta.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AElf.Rosetta.Permissions;

public class RosettaPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(RosettaPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(RosettaPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<RosettaResource>(name);
    }
}
