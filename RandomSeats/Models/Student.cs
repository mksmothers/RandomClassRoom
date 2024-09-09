using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RandomSeats.Models;

[Table("Student")]
public partial class Student
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("ClassID")]
    public int ClassId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    public bool Active { get; set; }

    [ForeignKey("ClassId")]
    [InverseProperty("Students")]
    public virtual ClassUnit Class { get; set; } = null!;
}
