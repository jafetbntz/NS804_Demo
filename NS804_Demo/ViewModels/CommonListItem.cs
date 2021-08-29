using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NS804_Demo.ViewModels
{
    public class CommonListItem<T>
    {
        public T Id { get; set; }
        public String Name { get; set; }

        public CommonListItem() {}

        public CommonListItem(T id, String Name) {

            this.Id = id;
            this.Name = Name;
        }

    }
}