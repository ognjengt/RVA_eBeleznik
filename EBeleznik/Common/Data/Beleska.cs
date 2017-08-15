using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Data
{
    public class Beleska : BeleskaPrototype
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Naslov { get; set; }
        public string Sadrzaj { get; set; }
        public string Grupe { get; set; }

        public override Beleska Clone()
        {
            Beleska clone = new Beleska();

            clone.Naslov = this.Naslov;
            clone.Sadrzaj = this.Sadrzaj;
            clone.Grupe = this.Grupe;
            return clone;
        }
    }
}
