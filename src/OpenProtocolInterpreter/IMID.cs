﻿using System.Collections.Generic;

namespace OpenProtocolInterpreter
{
    public interface IMid
    {
        Mid.Header HeaderData { get; set; }
        Dictionary<int, List<DataField>> RevisionsByFields { get; set; }
        Mid Parse(string package);
        
        string BuildPackage();
    }
}
