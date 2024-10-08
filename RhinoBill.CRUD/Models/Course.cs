﻿using System.ComponentModel.DataAnnotations.Schema;

namespace RhinoBill.CRUD.Models;

public record Course
{
    public int Id { get; init; }
    public string Code { get; init; } = string.Empty;
    public string Title { get; init; } = string.Empty;
    public int Credits { get; init; }
    [NotMapped]
    public string CodeAndTitle { get { return $"{Code} - {Title}"; } }
    public ICollection<Application>? Applications { get; set; }
}
