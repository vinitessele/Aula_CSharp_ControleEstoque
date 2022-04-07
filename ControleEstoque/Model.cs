using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace ControleEstoque
{
    public class Model
    {
        public void SetUsuario(DtoUsuario u)
        {
            Context db = new Context();

            db.usuario.Add(u);
            db.SaveChanges();
        }

        public void EditUsuario(DtoUsuario u)
        {
            Context db = new Context();
            DtoUsuario e = db.usuario.FirstOrDefault(p => p.id == u.id);
            e.nome = u.nome;
            e.login = u.login;
            e.senha = u.senha;
            
            db.SaveChanges();
        }

        public List<DtoUsuario2> ListUsuarios()
        {
            Context db = new Context();
            List<DtoUsuario2> result = (from a in db.usuario
                                  select new DtoUsuario2
                                  {
                                      id = a.id,
                                      nome = a.nome
                                  }).ToList();

            return new List<DtoUsuario2>(result);
        }
        public List<DtoProduto2> ListProdutos()
        {
            Context db = new Context();
            List<DtoProduto2> result = (from a in db.produto
                                        select new DtoProduto2
                                        {
                                            id = a.id,
                                            nome = a.nome,
                                            valorCusto = a.valorCusto,
                                            valorVenda = a.valorVenda,
                                            quantidade = a.quantidade
                                        }).ToList();

            return new List<DtoProduto2>(result);
        }

        internal void SetProduto(DtoProduto p)
        {
            Context db = new Context();

            db.produto.Add(p);
            db.SaveChanges();
        }

        internal void EditProduto(DtoProduto p)
        {
            Context db = new Context();
            DtoProduto e = db.produto.FirstOrDefault(pr => pr.id == p.id);
            e.nome = p.nome;
            e.valorCusto = p.valorCusto;
            e.valorVenda = p.valorVenda;
            e.quantidade = p.quantidade;

            db.SaveChanges();
        }

        public DtoUsuario2 GetUsuarioId(int id)
        {
            Context db = new Context();
            var result = (from a in db.usuario
                             where a.id == id
                                   select new DtoUsuario2
                                   {
                                       id = a.id,
                                       nome = a.nome
                                   }).FirstOrDefault();

            var result1 = db.usuario.Where(p => p.id == id).FirstOrDefault();

            return result;
        }

        public void DeletarUsuario(int id)
        {
            Context db = new Context();
            DtoUsuario u = db.usuario.FirstOrDefault(p => p.id == id);
            db.usuario.Remove(u);
            db.SaveChanges();
        }
    }
}
