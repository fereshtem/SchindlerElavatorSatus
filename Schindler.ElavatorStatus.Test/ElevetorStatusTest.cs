using NUnit.Framework;
using System;
using FluentAssertions;
using System.Collections.Generic;
using System.Text;
using Schindler.ElavatorStatus.Domain;

namespace Schindler.ElavatorStatus.Test
{
    public class ElevetorStatusTest
    {
        [TestCase("")]
        [TestCase(null)]
        public void Ctor_WithNameEmptyOrNull_ShouldThrowArgumentException(string status)
        {
            Action act = () => new Domain.ElavatorStatus(status);
            act.Should().Throw<ArgumentException>();
        }
        [Test]
        public void ElevetorStatus_WithValidValues_ShouldDoCorrectMapping()
        {
            string status = StatusType.Status1.ToString();
            var elevatorStatus = new Domain.ElavatorStatus(status);

            elevatorStatus.Status.Should().Be(status);
        }
    }
}
