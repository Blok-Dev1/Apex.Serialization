﻿using FluentAssertions;
using Xunit;

namespace Apex.Serialization.Tests
{
    public class InternTests : AbstractSerializerTestBase
    {
        public static readonly object TheObject = new object();

        [Fact]
        public void InternedObjectShouldKeepReferenceEquality()
        {
            (_serializerGraph as Binary).Intern(TheObject);
            RoundTripGraphOnly(TheObject, (original, loaded) => ReferenceEquals(loaded, TheObject).Should().BeTrue());
        }
    }
}