using Authentication.Proto;
using Grpc.Core;

namespace Authentication.Service
{
    public class CheckPermissionService : checkPermissionService.checkPermissionServiceBase
    {
        public override Task<checkPermissionResponse> checkPermission(checkPermissionRequest request, ServerCallContext context)
        {
            List<string> permisssions = ["get-all", "get", "create", "edit", "delete"];

            var Isallowed = permisssions.Any(c => c == request.Permission);

            return Task.FromResult(new checkPermissionResponse() { Isallowed = Isallowed });
        }
    }
}
