using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationPattern.Domain.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        /// <summary>
        /// Lista todos os registro do banco
        /// </summary>
        /// <returns> Retorna uma lista com todos os registros do banco</returns>
        Task<IEnumerable<T>> GetAll();

        /// <summary>
        /// Busca determinado registro no banco
        /// </summary>
        /// <param name="id"> id do registro ser buscado </param>
        /// <returns> Retorna uma lista com todos os registros do banco</returns>
        Task<T> Get(long id);

        /// <summary>
        /// Persite uma entidade no banco
        /// </summary>
        /// <param name="entity"> Entidade a ser persisitido </param>
        /// <returns>Retorna a entidade já persistida no banco</returns>
        Task<T> Save(T entity);

        /// <summary>
        /// Persite uma range de entidades no banco
        /// </summary>
        /// <param name="entity"> IEnumerablea de Entidades a serem persisitidas </param>
        /// <returns>Retorna a IEnumerablea com as entidades já persistidas no banco</returns>
        Task<IEnumerable<T>> SaveRange(IEnumerable<T> entity);

        /// <summary>
        /// Atualiza um registro no banco
        /// </summary>
        /// <param name="entity">Entidade atualizada</param>
        /// <param name="id">Id da entidade a ser atualizada</param>
        Task Update(T entity);

        /// <summary>
        /// Atualiza um range de registros no banco
        /// </summary>
        /// <param name="entity">IEnumerablea de Entidades a serem atualizadas</param>
        Task UpdateRange(IEnumerable<T> entity);

        /// <summary>
        /// Remove um registro no banco
        /// </summary>
        /// <param name="id">Id da entidade a ser removida</param>
        Task Delete(long id);

        /// <summary>
        /// Remove um range de registros no banco
        /// </summary>
        /// <param name="entity">IEnumerablea de Entidades a serem atualizadas</param>
        Task DeleteRange(IEnumerable<T> entity);
    }
}
