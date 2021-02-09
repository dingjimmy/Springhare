// Copyright (c) James C Dingle. All rights reserved.

using System;
using System.Collections.Generic;

namespace Springhare
{
    public class LongRunningAction : IAction
    {
        public uint Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<ConfigurationParameter> Configuration { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Execute()
        {
            throw new NotImplementedException();
        }

        public void Setup()
        {
            throw new NotImplementedException();
        }

        public void Teardown()
        {
            throw new NotImplementedException();
        }
    }
}
