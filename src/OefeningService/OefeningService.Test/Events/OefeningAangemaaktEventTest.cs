using Microsoft.VisualStudio.TestTools.UnitTesting;
using OefeningService.Constants;
using OefeningService.Events;

namespace OefeningService.Test.Events
{
    [TestClass]
    public class OefeningAangemaaktEventTest
    {
        [TestMethod]
        public void Ctor_ShouldSetTopic()
        {
            // Act
            var target = new OefeningAangemaaktEvent();
            
            // Assert
            Assert.AreEqual(TopicNames.OefeningAangemaakt, target.Topic);
        }
    }
}