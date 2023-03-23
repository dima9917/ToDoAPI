using ToDoAPI.Models;

namespace ToDoAPI.Tests
{
    public class ToDoModelTests
    {
        [Fact]
        public void CanChangeName()
        {
            //Arrange
            var testToDo = new ToDoItem { Name = "1" };
            //Act
            testToDo.Name = "2";
            //Assert
            Assert.Equal(testToDo.Name, "2");
        }
                [Fact]
        public void FailingTest()
        {
            //Arrange
            var testToDo = new ToDoItem { Name = "1" };
            //Act
            testToDo.Name = "2";
            //Assert
            Assert.Equal(testToDo.Name, "1");
        }
    }
}
