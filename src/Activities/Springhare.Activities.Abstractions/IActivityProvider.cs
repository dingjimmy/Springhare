// Copyright (c) James C Dingle. All rights reserved.

using System.Collections.Generic;

namespace Springhare.Activities.Abstractions
{
    public interface IActivityProvider
    {
        string ActivityInstallDirectory { get; set; }

        IEnumerable<ActivityDefinition> GetDefinitions();

        void LoadDefinitions();
    }
}
