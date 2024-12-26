using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using XmlFormattingAssignment.Model;

namespace XmlFormattingAssignment.Model
{
    public class Instructor
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Address PresentAddress { get; set; }
        public Address PermanentAddress { get; set; }
        public List<Phone> PhoneNumbers { get; set; }
    }
}
