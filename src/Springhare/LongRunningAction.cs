﻿// Copyright (c) James C Dingle. All rights reserved.

using System;
using System.Collections.Generic;

namespace Springhare
{
    public class LongRunningAction : IAction
    {
        public uint Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<ConfigurationParameter> Configuration { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ActionResult Execute()
        {
            return ActionResult.Success;
        }

        public ActionResult Setup()
        {
            return ActionResult.Success;
        }

        public ActionResult Teardown()
        {
            return ActionResult.Success;
        }
    }
}
