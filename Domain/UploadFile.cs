using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class UploadFile :BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
    }
}
