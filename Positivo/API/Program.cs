var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Curso> cursos = new List<Curso>(){
    new Curso(1, "Ciência da Computação"),
    new Curso(2, "Engenharia de Software")
};

app.MapGet("/", () => {
    return Results.Ok(cursos);
});

app.MapGet("/{id}", ([FromRoute] int id) => {
return Results.Ok(cursos.Find(curso => curso.Id == id));
});

app.MapPost("/", ([FromBody] Curso curso) => {
    cursos.Add(curso);
    return Results.Created(curso);
});

app.run();