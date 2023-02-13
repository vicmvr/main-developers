using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Developers
{
    static class Variable
    { 
        //TIPO DE CAMBIO
        static public String Fecha = "";
        static public Double TipoCambio = 0.0;
        //DATOS DE USUARIO ACTIVO
        static public Int32 IDUsuarioActivo = 0;//variable almacena id usuario activo 
        static public String UsuarioActivo = "";//variable almacena nombre de usuario activo 
        static public String UsuarioRol = "";//variable almacena rol de usuario activo 
        //DATOS DE CAJA
        static public Int32 IDCaja = 0;//variable almacena id de caja  
        static public String NombreCaja = "";//variable almacena nombre de caja   
        static public String ImpresoraTickets = "";//Nombre de la impresora predeterminada
        static public String ImpresoraReportes = "";//Nombre de la impresora predeterminada        
        //DATOS DE SUCURSAL
        static public Int32 IDSucursal = 0;//variable almacena numero de sucursal  
        static public String NombreSucursal = "";
        static public int Almacen1 = 0;
        static public int Almacen2 = 0;        
        //VARIABLES DE CORTE
        static public int CorteAbierto = 0;
        static public String FechaCorteIni = "";
        static public String FechaCorteFin = "";
        //VARIABLES DE TICKET
        static public Int32 IDTicketActual = 0;//variable almacena id ticket actual
        static public Int32 IDTicketCreditoActual = 0;//variable almacena id ticket actual 
        static public String pv2 = "";//variable auxiliar para imprimir ticket        
        //VARIABLES DE CLIENTE
        static public Int32 IDClienteActual = 0;//variable almacena id Cliente/Numero de credito 
        static public String NombreCliente = "NINGUNO";
        static public String ApePat = "";
        static public String ApeMat = "";
        static public Double LimiteCredito = 0;
        static public String Calle = "";
        static public String Colonia = "";
        static public String NumExt = "";
        static public String NumInt = "";
        static public String CiudadCliente = "";
        static public String TelefonoCliente = "";
        static public String RFCCliente = "";
        static public String CURPCliente = "";
        static public String CorreoCliente = "";
        static public Double Saldo = 0.0;
        static public String FechaUltimoAbono = "";
        static public Int32 DiasTrans = 0;
        static public Int32 DiasAtraso = 0;
        static public Double InteresGenerado = 0;
        static public Double SaldoDisponible = 0;

        public static string CantAtrasada;
        public static string FechaUltimoPago; 
        //VARIABLES DE PRODUCTO
        static public String IDProducto = "";
        static public String Descripcion = "";
        static public String TipoVenta = "";
        static public Double PrecioCompra = 0;
        static public Double PrecioMenudeo = 0;
        static public Double PrecioMayoreo = 0;
        static public Double PrecioCredito = 0;
        static public Int32 IDDepartamento = 0;
        static public String Departamento = "";
        static public Double Existencias = 0;
        static public Double ExistenciaMin = 0;
        static public Double ExistenciaMax = 0;
        static public Double IVA = 0;
        static public Double Desc = 0;
        //VARIABLES DE VENTA
        static public Int32 IDVenta = 0;
        static public String FechaVenta = "";
        static public Double Precio = 0;
        static public Double Cantidad = 0;
        static public Double SubTotalIVA = 0;
        static public Double SubTotalDesc = 0;
        static public Double SubTotalVenta = 0;
        //VARIABLES DE ABONO
        static public Int32 IDAbono = 0;
        static public Int32 IDClienteAbono = 0;
        static public String FechaAbono = "";
        static public Double CantidadAbono = 0;
        static public Double IDUsuarioAbono = 0;
        static public Double IDCajaAbono = 0;
        static public Double IDSucursalAbono = 0;
        //VARIABLES DE TICKET
        static public Int32 IDTicket = 0;
        static public Int32 IDCorteTicket = 0;
        static public Int32 IDUsuarioTicket = 0;
        static public Int32 IDClienteTicket = 0;
        static public Int32 IDCajaTicket = 0;
        static public Int32 IDSucursalTicket = 0;
        static public String FechaTicket = "";
        static public String HoraTicket = "";
        static public Double TipoCambioTicket = 0;
        static public Int32 Estado = 0;
        static public String FormaPago = "";//EFECTIVO,CREDITO,VALE,CHEQUE
        static public Double TotalDesc = 0;
        static public Double TotalIVA = 0;
        static public Double TotalTicket = 0;
        static public Double PagoCon = 0;
        static public Double PagoConUSD = 0;
        static public Double SuCambio = 0;

        //////////////////////

        static public Int32 VentaEnProceso = 0;//0=No 1=Si
        //Variable para margen de credito
        static public Double totalAcumulado = 0;
        static public Double PagoInicial = 0;
        static public Int32 TiempoLimite = 0;//semanas para pagar
        static public Int32 AtrasoPermitido = 0;//semanas de atraso permitidas
        static public double SaldoUpdate = 0;
        static public double PagoIni = 0;
        static public double totalAbonar = 0;
        static public int pv3 = 0;//variable auxiliar para imprimir comprobante de abono   
     
        /////


        static public string returnedDepto = "";

        /////

        static public Double xTotal = 0;
        static public Double xTotaliva = 0;
        static public List<Producto> list = new List<Producto>();
        static public Producto prod1 = new Producto();
        public static int xExistenciaenBD;
        public static int xID_Existencias;
        public static int xIDProductoExt;
        /////////////////
        public static string ProxAbono;
        static public Double CtdAbono = 0;
        public static int RegresaResetear=0;
        public static Double SaldoDisponiblePorDesc = 0;
        public static int cierraDescuentos;
        public static int NoAbonos = 0;


        public static string NombreClienteAbono { get; set; }
        public static string NumCteAbono { get; set; }
    }
}
