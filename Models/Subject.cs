using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using pdf6b3.Databases;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;

namespace pdf6b2.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Boolean Status { get; set; }
        public ICollection<Mark> Mark { get; set; }
    }


public static class SubjectEndpoints
{
	public static void MapSubjectEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Subject").WithTags(nameof(Subject));

        group.MapGet("/", async (StudentDbContext db) =>
        {
            return await db.Subjects.ToListAsync();
        })
        .WithName("GetAllSubjects")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Subject>, NotFound>> (int id, StudentDbContext db) =>
        {
            return await db.Subjects.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Subject model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetSubjectById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Subject subject, StudentDbContext db) =>
        {
            var affected = await db.Subjects
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Id, subject.Id)
                  .SetProperty(m => m.Name, subject.Name)
                  .SetProperty(m => m.Status, subject.Status)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateSubject")
        .WithOpenApi();

        group.MapPost("/", async (Subject subject, StudentDbContext db) =>
        {
            db.Subjects.Add(subject);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Subject/{subject.Id}",subject);
        })
        .WithName("CreateSubject")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, StudentDbContext db) =>
        {
            var affected = await db.Subjects
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteSubject")
        .WithOpenApi();
    }
}}
