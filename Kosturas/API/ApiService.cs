using Domain;
using Kosturas.JsonModels;
using Kosturas.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Kosturas.API
{
    public class ApiService
    {

        DataContextLocal db = new DataContextLocal();
    
        public async Task Facturar()
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("http://costulatam.facturaelectronicacrc.com");
                var url = "/api/web/facturas";
                FacturaJSON factura = new FacturaJSON();
               var login=await Login("3101708154", "pruebas");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + login.Token);
                factura.user_id = login.Id;


                var Fecha = DateTime.Today.ToShortDateString();
                var desde = Fecha + " 00:00";
                var hasta = Fecha + " 23:59";
                var fdesde = DateTime.Parse(desde);
                var fhasta = DateTime.Parse(hasta);




                var ordenes = db.Ordenes.Where(q => q.FeEnt >= fdesde && q.FeEnt <= fhasta).ToList();

                Cliente cliente = new Cliente();
                TemDetallesOrdenes temDetalles = new TemDetallesOrdenes();
                TemDetallesOrdenPrenda ordenPrenda = new TemDetallesOrdenPrenda();
                string request;
                StringContent body;
                List<Detalle> lista = new List<Detalle>();
          
                foreach (var item in ordenes.ToList())
                {

                    cliente.Nombre = item.Cliente.Nombre;
                    cliente.Email = item.Cliente.Email;
                    cliente.TelefonoPrincipal = item.Cliente.TelefonoPrincipal;
                    cliente.Cedula = item.Cliente.Cedula;
                    cliente.numeroProvincia = item.Cliente.numeroProvincia;
                    cliente.numeroCanton = item.Cliente.numeroCanton;
                    cliente.numeroDistrito = item.Cliente.numeroDistrito;
                    cliente.Direcion = item.Cliente.Direcion;
                    factura.factura = new Factura
                    {
                        condicion_venta = "01",
                        medio_pago = "01",
                        plazo_credito = "0",
                        moneda = "CRC",
                        tipo_cambio = 560,
                        receptor_nombre = cliente.Nombre,
                        receptor_tipo_identificacion = "01",
                        receptor_numero_identificacion = cliente.Cedula,
                        receptor_provincia = cliente.numeroProvincia.Value,
                        receptor_canton = cliente.numeroCanton.Value,
                        receptor_distrito = cliente.numeroDistrito.Value,
                        receptor_otras_senas = cliente.Direcion,
                        receptor_codigo_telefono = 506,
                        receptor_telefono = int.Parse(cliente.TelefonoPrincipal),
                        receptor_email = cliente.Email
                    };


                    foreach (var itemT in item.Prendas)
                        {
                            ordenPrenda.Cantidad = itemT.Cantidad;
                            ordenPrenda.Prenda = itemT.Prenda;
                            foreach (var itemdos in itemT.DetalleTareas)
                            {
                                temDetalles.Precio = itemdos.Precio;
                                temDetalles.Descuento = itemdos.Descuento;
                                temDetalles.Detalle=itemdos.Detalle;
                                temDetalles.Detalle.DetalleTareas = itemdos.Detalle.DetalleTareas;
                                temDetalles.DetalleOrdenPrendaId = itemdos.DetalleOrdenPrendaId;
                              
                                lista.Add(new Detalle
                                {


                                    codigo = temDetalles.DetalleOrdenPrendaId.ToString(),
                                    cantidad = ordenPrenda.Cantidad,
                                    precio_unitario = decimal.Parse(temDetalles.Precio.ToString()),
                                    unidad_medida_codigo = "Sp",
                                    detalle = ordenPrenda.Prenda.TipoRopa+ " " + temDetalles.Detalle.Tarea.NombreTareas+ " " + temDetalles.Detalle.DetalleTareas,
                                    monto_descuento = decimal.Parse((temDetalles.Descuento* temDetalles.Precio/100).ToString()),
                                    naturaleza_descuento = (temDetalles.Descuento * temDetalles.Precio / 100).ToString(),
                                    impuesto_tarifa = null,
                                    tipo_documento_exoneracion = null,
                                    num_documento_exoneracion = null,
                                    nombre_institucion_emite_exoneracion = null,
                                    fecha_emision_exoneracion = null,
                                    monto_impuesto_exonerado = null,
                                    porcentaje_compra_exoneracion = null,
                                    impuesto_incluido = 1

                                });
                          

                                

                            }

                        
                  
                    }
                    factura.detalles = lista;
                    request = JsonConvert.SerializeObject(factura);
                 
                    body = new StringContent(request, Encoding.UTF8, "application/json");
                    var prueba = await client.PostAsync(url, body);
                    var result = await prueba.Content.ReadAsStringAsync();
                    lista = new List<Detalle>();
              
                }
              

        
               
            }
            catch
            {
                
            }
        }


        public async Task<Response> Login(string email, string password)
        {
            try
            {
                var loginRequest = new LoginRequest
                {
                    username = email,
                    password = password,
                };

                var request = JsonConvert.SerializeObject(loginRequest);
                var body = new StringContent(request, Encoding.UTF8, "application/json");
                var client = new HttpClient();
                client.BaseAddress = new Uri("http://costulatam.facturaelectronicacrc.com");
                var url = "/api/web/site/login";
                var response = await client.PostAsync(url, body);

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Mensaje = "Usuario o contraseña incorrectos",
                    };
                }

                var result = await response.Content.ReadAsStringAsync();
               

                ResultJson data = JsonConvert.DeserializeObject<ResultJson>(result);

              

                return new Response
                {
                    IsSuccess = true,
                    Mensaje = "Login Ok",
                     Id = data.data.id,
               Token = data.data.access_token
            };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Mensaje = ex.Message,
                };
            }
        }
    }
}
