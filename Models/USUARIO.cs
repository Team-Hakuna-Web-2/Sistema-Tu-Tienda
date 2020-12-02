namespace Sistema_TuTienda_Lizarraga_Belizario_Loja.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("USUARIO")]
    public partial class USUARIO
    {
        [Key]
        public int ID_USUARIO { get; set; }

        [Required]
        [StringLength(60)]
        public string NOMBRE { get; set; }

        [Required]
        [StringLength(60)]
        public string APELLIDO { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        [StringLength(15)]
        public string TELEFONO { get; set; }

        [StringLength(20)]
        public string PAIS { get; set; }

        [StringLength(20)]
        public string CIUDAD { get; set; }

        [StringLength(40)]
        public string DIRECCION { get; set; }

        [Required]
        public byte[] IMAGEN { get; set; }


        public List<USUARIO> Listar()
        {
            var usuarios = new List<USUARIO>();

            try
            {
                using (var db = new Model1())
                {
                    usuarios = db.USUARIO.ToList();
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return usuarios;
        }



        public List<USUARIO> Buscar(string criterio)
        {
            var usuarios = new List<USUARIO>();

            try
            {
                using (var db = new Model1())
                {
                    usuarios = db.USUARIO.Include("TIPO_USUARIO")
                        .Where(x => x.NOMBRE.Contains(criterio) ||
                               x.APELLIDO.Contains(criterio))
                        .ToList();
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return usuarios;
        }



        public void Guardar()
        {
            try
            {
                using (var db = new Model1())
                {
                    if (this.ID_USUARIO > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(this).State = EntityState.Added;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }



        public void Eliminar()
        {
            try
            {
                using (var db = new Model1())
                {
                    db.Entry(this).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }




        public USUARIO Obtener(string id)
        {
            var usuario = new USUARIO();

            try
            {
                using (var db = new Model1())
                {
                    usuario = db.USUARIO.Include("TIPO_USUARIO")
                        .Where(x => x.ID_USUARIO.Equals(id))
                        .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return usuario;
        }




        public ResponseModel ValidarLogin(string Usuario, string Password)
        {
            var rm = new ResponseModel();

            try
            {
                using (var db = new Model1())
                {
                    Password = HashHelper.MD5(Password);

                    var usuario = db.USUARIO.Where(x => x.NOMBRE == Usuario)
                        .Where(x => x.NOMBRE == Password)
                        .SingleOrDefault();

                    if (usuario != null)
                    {
                        SessionHelper.AddUserToSession(usuario.NOMBRE.ToString());
                        rm.SetResponse(true);
                    }
                    else
                    {
                        rm.SetResponse(false, "Usuario y/o Password incorrectos");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return rm;
        }



    }
}
