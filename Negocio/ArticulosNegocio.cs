using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
//using System.Windows.Forms;
using Dominio;
using Negocio;
using System.Net;
using System.ComponentModel;


namespace TPWinForm_EquipoN
{
    public class ArticulosNegocio
    {
        public List<Articulo> listar()

        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                //configuracion de la cadena de conexion
                //conexion.ConnectionString = "server = (localdb)\\MSSQLLocalDB; database = CATALOGO_P3_DB; integrated security = true";
                //comando.CommandType = System.Data.CommandType.Text;
                //comando.CommandText = "Select Codigo, Nombre, Descripcion, Precio from ARTICULOS";// la consulta que hago a la base de datos
                //comando.Connection = conexion;

                //conexion.Open();
                //lector = comando.ExecuteReader();
                datos.setearConsulta("select A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion as 'Marca', C.Descripcion as Categoria, A.Precio, I.ImagenUrl from ARTICULOS A Left Join MARCAS M on A.IdMarca = M.Id Left Join CATEGORIAS C on A.IdCategoria = C.Id Inner Join IMAGENES I on A.Id = I.IdArticulo");//la consulta que hago a la base de datos
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                { 
                    Articulo aux = new Articulo();
                    aux.Codigo = (string)datos.Lector["Codigo"] ;//esta es una forma
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    /*Marcas mar = new Marcas();
                    mar.Descripcion = "Sin marca";
                    mar.Descripcion = (string)datos.Lector["Marca"];
                                        
                    Categoria cat = new Categoria();
                    cat.Descripcion = "Sin Categoria";
                    cat.Descripcion = (string)datos.Lector["Categoria"]; 
     */
                                        
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
        public void AgregarArt(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into ARTICULOS(Codigo, Nombre, Descripcion, Precio) values('" + nuevo.Codigo + "', '"+nuevo.Nombre+"', '"+nuevo.Descripcion+"', "+nuevo.Precio+")");
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void ModifArt(Articulo modificar){


        }

        public void ElimArt(Articulo eliminar)
        {

        }
    }
}
