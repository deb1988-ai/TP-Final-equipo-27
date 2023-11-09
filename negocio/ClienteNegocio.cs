﻿using dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class ClienteNegocio
    {
        public List<Cliente> listarClientes()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select IdCliente, Nombre, Apellido, Email, Telefono from clientes");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Cliente aux = new Cliente();
                    aux.DatosCliente = new Persona();
                    aux.IdCliente = (int)datos.Lector["IdCliente"];
                    aux.DatosCliente.Nombre = (string)datos.Lector["Nombre"];
                    aux.DatosCliente.Apellido = (string)datos.Lector["Apellido"];
                    aux.DatosCliente.Email = (string)datos.Lector["Email"];
                    aux.DatosCliente.Telefono = (string)datos.Lector["Telefono"];

                    listaClientes.Add(aux);
                }
                return listaClientes;
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
        public Cliente BuscarClientesID(int id)
        {
            Cliente aux = new Cliente();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select Nombre, Apellido, Email, Telefono from clientes where IdCliente = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();
                aux.DatosCliente = new Persona();
                aux.IdCliente = id;
                if (datos.Lector.Read())
                {
                    aux.DatosCliente.Nombre = (string)datos.Lector["Nombre"];
                    aux.DatosCliente.Apellido = (string)datos.Lector["Apellido"];
                    aux.DatosCliente.Email = (string)datos.Lector["Email"];
                    aux.DatosCliente.Telefono = (string)datos.Lector["Telefono"];
                   
                }
                return aux;
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

        public void AgregarCliente(Cliente cliente)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Insert into clientes (Nombre, Apellido, Email, Telefono)values(@nombre, @apellido, @email, @telefono)");
                datos.setearParametro("@nombre", cliente.DatosCliente.Nombre);
                datos.setearParametro("@apellido", cliente.DatosCliente.Apellido);
                datos.setearParametro("@email", cliente.DatosCliente.Email);
                datos.setearParametro("@telefono", cliente.DatosCliente.Telefono);
                datos.ejecutarAccion();
                datos.cerrarConexion();
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

        public void ModificarCliente(Cliente cliente)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("update cliente set Nombre = @nombre, Apellido = @apellido, Email = @email, Telefono = @telefono where IdCliente = @idcliente");
                datos.setearParametro("@nombre", cliente.IdCliente);
                datos.setearParametro("@nombre", cliente.DatosCliente.Nombre);
                datos.setearParametro("@apellido", cliente.DatosCliente.Apellido);
                datos.setearParametro("@email", cliente.DatosCliente.Email);
                datos.setearParametro("@telefono", cliente.DatosCliente.Telefono);
                datos.ejecutarAccion();
                datos.cerrarConexion();
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
    }
}
