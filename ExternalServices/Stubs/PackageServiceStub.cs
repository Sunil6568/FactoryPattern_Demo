using System;

namespace ExternalServices.Stubs
{
    public class PackageServiceStub : IPackageService
    {
        public Package GetPackage(string id)
        {
            return new Package();
        }
    }
}