﻿namespace FantasticWorder
{
    using System.Collections.Generic;

    public interface IDictionaryReader
    {
        List<string> Read(string file);
    }
}
