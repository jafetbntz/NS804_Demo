using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NS804_Demo.Models
{
    public class BaseModel<PK>
    {
        [Key]
        public PK Id { get;  set; } 


        [JsonIgnore]
        public DateTime CreationDate { get; set; }

        [JsonIgnore]
        public DateTime LastUpdate { get; set; }

        [JsonIgnore]
        [ForeignKey("CreatedBy")]
        public String CreatorId { get; set; }

        [JsonIgnore]
        public NSUser CreatedBy { get; set; }


        [JsonIgnore]
        [ForeignKey("UpdatedBy")]
        public String LastEditorId { get; set; }

        [JsonIgnore]
        public NSUser UpdatedBy { get; set; }

        [JsonIgnore]
        public bool IsActive { get; set; }

    }
}