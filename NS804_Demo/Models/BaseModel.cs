using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NS804_Demo.Models
{
    /// <summary>
    /// BaseModel<PK> is used for creating an standard for
    /// auditory information, primary key and logical delete
    /// field (IsActive), so we avoid repeting code and we
    /// can implement some general rules that apply to the
    /// current models and those that can be included later.
    /// </summary>
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