using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Minimatch.Tests
{
    [TestClass]
    public class IssueTests
    {
        [TestMethod]
        public void TestIssue3()
        {
            var filterOptions = new Options
            {
                AllowWindowsPaths = true,
                IgnoreCase = true
            };

            var minimatcher = new Minimatcher("**/Thumbs.db", filterOptions);

            Assert.IsFalse(minimatcher.IsMatch(@"NewFolder\"));
        }
    }
}
