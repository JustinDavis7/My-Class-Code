using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using FinalProjectTodo.Models;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;
using Newtonsoft.Json.Linq;

namespace FinalProjectTodo.Test
{
    public class Tests
    {
        private TodoList _todo;
        private CompletedList _completed;
        private string _fileName;
        private List<string> _projectTags;
        private List<string> _contextTags;
        private Dictionary<string, string> _dict;

        [SetUp]
        public void Setup()
        {
            File.Delete("testTodo.txt");
            File.Delete("completedTodo.txt");
            _fileName = "C:\\Users\\strik\\Desktop\\todo.txt";
            _todo = new TodoList();
            File.Delete(_fileName);
            _todo.InitializeTodo(_fileName);
            _projectTags = new List<string>();
            _projectTags.Add("+tag1");
            _projectTags.Add("+tag2");
            _contextTags = new List<string>();
            _contextTags.Add("@tag4");
            _contextTags.Add("@tag3");
            _dict = new Dictionary<string, string>();
            _dict.Add("due","2021-06-10");
            _todo.Add(new Task("","(A)","","2021-06-10",_projectTags, _contextTags, _dict));
            TodoList.WriteTodo(_todo, _fileName);

            _fileName = "C:\\Users\\strik\\Desktop\\completedtodo.txt";
            _completed = new CompletedList();
            _projectTags = new List<string>();
            _projectTags.Add("+tag2");
            _contextTags = new List<string>();
            _contextTags.Add("@tag4");
            _dict = new Dictionary<string, string>();
            _dict.Add("due", "2021-06-10");
            File.Delete(_fileName);
            _completed.InitializeTodo(_fileName);
            _completed.Add(new Task("x", "(C)","2021-06-10","2021-06-10",_projectTags, _contextTags, _dict));
            CompletedList.WriteCompleted(_completed, _fileName);
        }

        [Test]
        public void TodoList_AllowsCreationOfNewTodoList()
        {
            // Arrange

            // Act
            var todo = new TodoList();
            todo.InitializeTodo("testTodo.txt");

            // Assert
            Assert.True(File.Exists("testTodo.txt"));
        }

        [Test]
        public void TodoList_ReadsDataFromExistingFileUsingToStringToCheck()
        {
            // Arrange

            // Act
            var todo = new TodoList();
            todo.InitializeTodo("C:\\Users\\strik\\Desktop\\todo.txt");
            var temp = todo.ToString();

            // Assert
            Assert.True(temp.Equals("(A)  2021-06-10 +tag1 +tag2  @tag4 @tag3  due:2021-06-10\n"));
        }

        [Test]
        public void CompletedList_AllowsCreationOfNewCompletedList()
        {
            // Arrange

            // Act
            var completed = new CompletedList();
            completed.InitializeTodo("completedtodo.txt");

            // Assert
            Assert.True(File.Exists("completedtodo.txt"));
        }

        [Test]
        public void CompletedList_ReadsDataFromExistingFileUsingToStringToCheck()
        {
            // Arrange

            // Act
            var completed = new CompletedList();
            completed.InitializeTodo("C:\\Users\\strik\\Desktop\\completedtodo.txt");
            var temp = completed.ToString();

            // Assert
            Assert.True(temp.Equals("x (C) 2021-06-10 2021-06-10 +tag2 @tag4 due:2021-06-10\n"));
        }

        [Test]
        public void TodoList_GetsStringOrderedByProjectTags()
        {
            // Arrange
            _projectTags.Add("+f");
            _todo.Add(new Task("", "(B)", "", "2021-06-10", _projectTags, _contextTags, _dict));

            // Act
            var temp = _todo.ToStringProjectTag();

            // Assert
            Assert.True(temp.Equals("(A)  2021-06-10 +tag1 +tag2 @tag4 @tag3 due:2021-06-10\n(B)  2021-06-10 +tag2 +f @tag4 due:2021-06-10\n"));
        }

        [Test]
        public void TodoList_GetsStringOrderedByContextTags()
        {
            // Arrange
            _projectTags.Add("+f");
            _todo.Add(new Task("", "(B)", "", "2021-06-10", _projectTags, _contextTags, _dict));

            // Act
            var temp = _todo.ToStringContextTag();

            // Assert
            Assert.True(temp.Equals("(B)  2021-06-10 +tag2 +f @tag4 due:2021-06-10\n(A)  2021-06-10 +tag1 +tag2 @tag4 @tag3 due:2021-06-10\n"));
        }

        [Test]
        public void TodoList_GetsStringOrderedByPriority()
        {
            // Arrange
            _projectTags.Add("+f");
            _todo.Add(new Task("", "(B)", "", "2021-06-10", _projectTags, _contextTags, _dict));

            // Act
            var temp = _todo.ToStringPriority();

            // Assert
            Assert.True(temp.Equals("(A)  2021-06-10 +tag1 +tag2 @tag4 @tag3 due:2021-06-10\n(B)  2021-06-10 +tag2 +f @tag4 due:2021-06-10\n"));
        }

        [Test]
        public void TodoList_ToStringOrderedByPriority()
        {
            // Arrange
            _projectTags.Add("+f");
            _todo.Add(new Task("", "(B)", "", "2021-06-10", _projectTags, _contextTags, _dict));

            // Act
            var temp = _todo.ToString();

            // Assert
            Assert.True(temp.Equals("(A)  2021-06-10 +tag1 +tag2  @tag4 @tag3  due:2021-06-10\n(B)  2021-06-10 +tag2 +f  @tag4  due:2021-06-10\n"));
        }

        [Test]
        public void TodoList_UpdateChangesTodo()
        {
            // Arrange
            var temp1 = _todo.ToString();
            // Act
            _todo.UpdateTask(0, _completed, "(B)", "null", "null", "null", "null", "null", "null", _fileName);
            var temp2 = _todo.ToString();
            // Assert
            Assert.True(temp1 != temp2);
        }

        [Test]
        public void TodoList_UpdateMoveCompletedTaskToCompletedTodoList()
        {
            // Arrange
            var temp1 = _todo.ToString();
            _todo.Add(new Task("", "(B)", "", "2021-06-10", _projectTags, _contextTags, _dict));

            // Act
            _todo.UpdateTask(1, _completed, "(B)", "+Idk", "@Somewheremeaningfulmaybe?", "x", "due:nottodaysatan", "WhoReallyKnows", "Someday", _fileName);

            // Assert
            Assert.True(_completed.Tasks.Count == 2);
        }

        [Test]
        public void Task_CreatesANewTask()
        {
            // Arrange
            var task = new Task("", "(B)", "2021-06-11", "2021-06-10", _projectTags, _contextTags, _dict);

            // Act
            var check = (task.CreationDate == "2021-06-10" && task.CompletionDate == "2021-06-11" && task.Priority == "(B)");
            
            // Assert
            Assert.True(check);
        }

        [Test]
        public void Task_CreatesANewTaskFromExistingTask()
        {
            // Arrange
            var task = new Task(_todo.Tasks[0]);

            // Act
            var check = (task.CreationDate == "2021-06-10" && task.CompletionDate == "" && task.Priority == "(A)");

            // Assert
            Assert.True(check);
        }
    }
}