using EscolaAPI.Contexts;
using EscolaAPI.Interfaces;
using EscolaAPI.Models;

namespace EscolaAPI.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        // Responsavel com se comunicar diretamente com BD

        //Injetar o context- Uma cozinha precisa do fogo (EscolaContext) para fazer os pratos. Em vez de criar a classe contect sozinha, e ela pede no construtor da api para entregar pronto 
        //isso se chama injecao de independencia; 
        private readonly EscolaContext _context;
        // Injecao de dependencia a api entrega o EscolaContext pronto

        public CursoRepository(EscolaContext context)
        {
            _context = context;
        }

        public void Atualizar(int id, Curso curso)
        {
            Curso? curso_encontrado = _context.Curso.Find(id); 
            if (curso_encontrado != null)
            {
                // preparar para atualiar a linha do BD
                curso_encontrado.Nome = curso.Nome;
                curso_encontrado.CargaHoraria = curso.CargaHoraria;

                //realizar
                _context.SaveChanges();
            }

        }

        public Curso? BuscarPorId(int id)
        {

            return _context.Curso.Find(id); ;
        }

        public void cadastra(Curso curso)
        {
            _context.Curso.Add(curso); //coloca na fila
            _context.SaveChanges(); // grava no banco
        }


        //delete from curso whare id_curso = @id
        public void Delete(int id)
        {
           Curso? curso_encontrado = _context.Curso.Find(id);
            if (curso_encontrado != null) 
            {
                _context.Curso.Remove(curso_encontrado); // prepara
                _context.SaveChanges(); // deleta
            
            }
        }

        public List<Curso> ListarTodos()
        {
            return _context.Curso.ToList(); 

        }
    }
}
