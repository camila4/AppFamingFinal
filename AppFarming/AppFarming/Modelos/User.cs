﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AppFarming.Modelos
{
    class User
    {
        public Boolean Success { get; set; }
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
    }
}
