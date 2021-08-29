using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NS804_Demo.Models
{
    public class Quote : BaseModel<long>
    {

        public String Text { get; set; }
        public String Author { get; set; }

    }
}