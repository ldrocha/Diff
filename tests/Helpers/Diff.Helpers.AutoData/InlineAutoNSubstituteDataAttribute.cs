﻿using System;
using AutoFixture.Xunit2;
using Xunit;

namespace Diff.Helpers.AutoData
{
    public class InlineAutoNSubstituteDataAttribute : CompositeDataAttribute
    {
        public InlineAutoNSubstituteDataAttribute(params object[] values)
            : base(
                new InlineDataAttribute(values),
                new AutoNSubstituteDataAttribute())
        {
        }
    }
}

