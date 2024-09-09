using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RandomSeats.Models;

[Table("Teacher")]
public partial class Teacher
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    public bool Active { get; set; }

    [InverseProperty("Teacher")]
    public virtual ICollection<ClassUnit> ClassUnits { get; set; } = new List<ClassUnit>();
}
