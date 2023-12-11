using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mamba.Core.Models
{
    public class Team:BaseEntity
    {
        public string FullName { get; set; }    
        public string MediaUrl { get; set; }
        public int ProfessionId {  get; set; }
        public Profession? Profession { get; set; }
        public string ImageUrl {  get; set; }

        [NotMapped]
        public List<IFormFile>? ImageFile { get; set; }
       

    }
}
