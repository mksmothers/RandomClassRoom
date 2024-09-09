using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RandomSeats.Models;

[Table("ClassUnit")]
public partial class ClassUnit
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("TeacherID")]
    public int TeacherId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    public bool Active { get; set; }

    [InverseProperty("Class")]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    [ForeignKey("TeacherId")]
    [InverseProperty("ClassUnits")]
    public virtual Teacher Teacher { get; set; } = null!;
}
