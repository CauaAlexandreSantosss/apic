/*criar o "construtor" da aplicacao
 * ler o appsetting.json
 * e prepara a lista de servicos que a api vai usar */
using EscolaAPI.Contexts;
using EscolaAPI.Interfaces;
using EscolaAPI.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// part 1 - registros os servicoes (o que a api vat ter disponivel)
// habilita o uso de conrilleer na api (as classes da pasta controller)
builder.Services.AddControllers();

// Registrar o escolaContex (a "ponte" com o banco ) para a api poder usa-lo
builder.Services.AddDbContext<EscolaContext>( options => 
       options.UseSqlServer( builder.Configuration.GetConnectionString("Escola"))
    // DIZ O QUE O BANCO E SQL SERVE E BUSCA A CONNECTION STRING CHAMADA "ESCOLA".
    // dentro da secao connectionString do appsettings.json 


    
    );

// NOVO: quando  quando alguem pedir ICursoRepository, a API entrega um ICursoRepository 
// NOVO: quando alguem pedir ICursoRepository, a API entrega a classe CursoRepository 
builder.Services.AddScoped<ICursoRepository, CursoRepository>();
builder.Services.AddControllers(o =>
    o.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

//monta a aplicacao com tudo o que foi registrador acima 
// daqui para  baixo nao mais para registrar servicos.
var app = builder.Build();

// Configure the HTTP request pipeline.
// PARTE 2  -- O CAMINHO DE CADA REQUISICAO (PIPPLINE)

//SE algeuem acessar o endereco htpp, a api redireciona para https (mais seguro)
app.UseHttpsRedirection();
//vericar as permissoes de acesso. (vamos ultilizart quando tivermos login)
app.UseAuthorization();
//api/curso - lig aas rotas definidas nas controllers
app.MapControllers();

app.MapGet("/api/cursos", (EscolaContext db) => db.Curso.ToList());

// liga as api e deixa ela espereando as requisicoes
app.Run();
