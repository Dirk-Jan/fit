using Microsoft.VisualStudio.TestTools.UnitTesting;
using OefeningService.Commands;
using OefeningService.Constants;

namespace OefeningService.Test.Commands
{
    [TestClass]
    public class MaakOefeningAanCommandTest
    {
        [TestMethod]
        public void Ctor_ShouldSetQueueName()
        {
            var target = new MaakOefeningAanCommand();
            
            Assert.AreEqual(QueueNames.MaakOefeningAan, target.DestinationQueue);
        }
    }
}