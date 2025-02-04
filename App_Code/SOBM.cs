using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SOBM
/// </summary>
public class SOBM
{
    public SOBM()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string ComponentName { get; set; }
    public string Version { get; set; }
    public string Description { get; set; }
    public string Supplier { get; set; }
    public string License { get; set; }
    public string Origin { get; set; }
    public string Dependencies { get; set; }
    public string Criticality { get; set; }
    public string UsageRestrictions { get; set; }
    public string ChecksumHash { get; set; }
    public string Comments { get; set; }

    public static List<SOBM> GetSampleData()
    {
        return new List<SOBM>
        {
            new SOBM { ComponentName = "Newtonsoft.Json", Version = "13.0.1", Description = "JSON framework", Supplier = "Newtonsoft", License = "MIT", Origin = "NuGet", Dependencies = "None", Criticality = "Low", UsageRestrictions = "None", ChecksumHash = "abc123", Comments = "Commonly used library" },
            new SOBM { ComponentName = "ClosedXML", Version = "0.93.0", Description = "Excel library", Supplier = "ClosedXML Team", License = "MIT", Origin = "NuGet", Dependencies = "None", Criticality = "Medium", UsageRestrictions = "None", ChecksumHash = "xyz789", Comments = "Free and easy-to-use" }
        };
    }
}