﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ShopMagzine_2
{
 public   class Authors
    {
        public int AuthorsId;
        public string AutherName;
        public List<Books> Books = new List<Books>();
    }
}
