// Copyright (c) James C Dingle. All rights reserved.

using Springhare.Activities.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Springhare.Activities
{
    public class ActivityProvider : IActivityProvider
    {
        private Dictionary<string, ActivityDefinition> _Definitions = new Dictionary<string, ActivityDefinition>();

        public string ActivityInstallDirectory { get; set; }

        public void LoadDefinitions()
        {
            _Definitions.Clear();

            var assembliesToLoad = Directory
                .GetFiles(ActivityInstallDirectory, "Springhare.Activities.*.dll", SearchOption.AllDirectories)
                .Select(x =>
                {
                    (string Name, string Path) t1 = (Path.GetFileName(x), x);
                    return t1;
                });

            foreach (var assemblyInfo in assembliesToLoad)
            {
                var loadedAssemblies = AppDomain
                    .CurrentDomain
                    .GetAssemblies()
                    .Select(x => x.ManifestModule.Name);

                if (loadedAssemblies.Contains(assemblyInfo.Name))
                {
                    continue;
                }

                var loadedAssembly = Assembly.LoadFrom(assemblyInfo.Path);

                var types = loadedAssembly.GetTypes().Where(x => x.IsSubclassOf(typeof(ActivityDefinition)));

                foreach (var type in types)
                {
                    var def = (ActivityDefinition)Activator.CreateInstance(type);
                    
                    _Definitions.TryAdd(def.Key, def);
                }
            }
        }

        public IEnumerable<ActivityDefinition> GetDefinitions()
        {
            return _Definitions.Values;
        }
    }
}
