﻿namespace RhinoBill.CRUD.Models;

public record Application
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public DateTime ApplicationDate { get; set; }

    public required Student Student { get; set; }
    public required Course Course { get; set; }
}
