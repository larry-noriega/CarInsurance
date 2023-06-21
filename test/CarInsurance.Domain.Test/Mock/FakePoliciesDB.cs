using CarInsurance.Core.Models.CarPolicy;

namespace MockAsynchronousMethods.Tests.Mock
{
    public static class FakePoliciesDB
    {
        public static readonly List<Policy> Policies = new()
        {
            new Policy
            {
                Name = "Archibald",
                Coverage = new()
                {
                    "Comprehensive and collision coverage"
                },
                Amount = 1084,
                CreationDate = new(2023, 01, 20),                
                ExpirationDate = new(2023,08,20)
            },
            new Policy
            {
                Name = "Farrago",
                Coverage = new()
                {
                    "Comprehensive and collision coverage",
                    "Medical payment coverage",
                    "Uninsured/underinsured motorist (UM) coverage",
                    "Liability coverage"
                },
                Amount = 1394,
                CreationDate = new(2023, 06, 20),
                ExpirationDate = new(2024, 02, 20)
            },
            new Policy
            {
                Name = "Savage",
                Coverage = new()
                {
                     "Liability coverage"
                },
                Amount = 1127,
                CreationDate = new(2022, 01, 20),
                ExpirationDate = new(2022,08, 20)
            }
        };
    }
}
