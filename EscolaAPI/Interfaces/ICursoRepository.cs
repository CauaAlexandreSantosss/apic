using EscolaAPI.Models;

namespace EscolaAPI.Interfaces
{
    public interface ICursoRepository // - inteface e um  contarato, so diz que existe sem implementar.
    {
        // R - Read - devolve todos os curso

        List<Curso> ListarTodos(); // devolve uma lista de Curso.

        // R read: buscar um curso pelo id (ou null se não achar nada)
        Curso? BuscarPorId(int id);

        //create - cadastrar um numero novo

        void cadastra (Curso curso);

        void Atualizar(int id, Curso curso);
        void Delete(int id); 
    }
}
