using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using HW4.Models;
using HW4.DAL.Abstract;

namespace HW4.ViewModels
{
    public class PersonToDoVM
    {   
        public Person _user {get; set;}
        public ToDoItem _item {get; set;}
        public PersonToDoVM()
        {
        }
    }
}