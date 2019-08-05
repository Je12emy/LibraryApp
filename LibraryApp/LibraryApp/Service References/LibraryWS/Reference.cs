﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryApp.LibraryWS {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="LibraryWS.LibraryWebServiceSoap")]
    public interface LibraryWebServiceSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/VerificarBibliotecario", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable VerificarBibliotecario(string usuario, string clave);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/VerificarBibliotecario", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataTable> VerificarBibliotecarioAsync(string usuario, string clave);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/InsertarLibro", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int InsertarLibro(string titulo, string autor, bool disponibilidad, int codigoUbicacion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/InsertarLibro", ReplyAction="*")]
        System.Threading.Tasks.Task<int> InsertarLibroAsync(string titulo, string autor, bool disponibilidad, int codigoUbicacion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ModificarLibro", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int ModificarLibro(int codigoLibro, string titulo, string autor, bool disponibilidad, int codigoUbicacion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ModificarLibro", ReplyAction="*")]
        System.Threading.Tasks.Task<int> ModificarLibroAsync(int codigoLibro, string titulo, string autor, bool disponibilidad, int codigoUbicacion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/EliminarLibro", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int EliminarLibro(int codigoLibro);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/EliminarLibro", ReplyAction="*")]
        System.Threading.Tasks.Task<int> EliminarLibroAsync(int codigoLibro);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UbicarLibro", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable UbicarLibro(int codigoLibro);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UbicarLibro", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataTable> UbicarLibroAsync(int codigoLibro);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/BuscarLibros", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable BuscarLibros();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/BuscarLibros", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataTable> BuscarLibrosAsync();
        
        // CODEGEN: Parameter 'estado' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HistorialSocio", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        LibraryApp.LibraryWS.HistorialSocioResponse HistorialSocio(LibraryApp.LibraryWS.HistorialSocioRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HistorialSocio", ReplyAction="*")]
        System.Threading.Tasks.Task<LibraryApp.LibraryWS.HistorialSocioResponse> HistorialSocioAsync(LibraryApp.LibraryWS.HistorialSocioRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/BuscarPrestamosTodo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable BuscarPrestamosTodo();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/BuscarPrestamosTodo", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataTable> BuscarPrestamosTodoAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/InsertarPrestamo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int InsertarPrestamo(int codigoSocio, int codigoLibro, System.DateTime fechaPrestamo, bool estado);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/InsertarPrestamo", ReplyAction="*")]
        System.Threading.Tasks.Task<int> InsertarPrestamoAsync(int codigoSocio, int codigoLibro, System.DateTime fechaPrestamo, bool estado);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ModificarPrestamo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int ModificarPrestamo(int codigoPrestamo, int codigoSocio, int codigoLibro, System.DateTime fechaPrestamo, bool estado);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ModificarPrestamo", ReplyAction="*")]
        System.Threading.Tasks.Task<int> ModificarPrestamoAsync(int codigoPrestamo, int codigoSocio, int codigoLibro, System.DateTime fechaPrestamo, bool estado);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/EliminarPrestamo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int EliminarPrestamo(int codigoPrestamo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/EliminarPrestamo", ReplyAction="*")]
        System.Threading.Tasks.Task<int> EliminarPrestamoAsync(int codigoPrestamo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ComprobarSocio", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable ComprobarSocio(int codigoSocio);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ComprobarSocio", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataTable> ComprobarSocioAsync(int codigoSocio);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/VerificarSocio", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable VerificarSocio(int codigoSocio, string clave);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/VerificarSocio", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataTable> VerificarSocioAsync(int codigoSocio, string clave);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/BuscarSocio", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable BuscarSocio(int codigoSocio);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/BuscarSocio", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataTable> BuscarSocioAsync(int codigoSocio);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/BuscarSocioTodo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable BuscarSocioTodo();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/BuscarSocioTodo", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataTable> BuscarSocioTodoAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ModificarSocio", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int ModificarSocio(int codigoSocio, string nombre, string primerApellido, string segundoApellido, string direccion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ModificarSocio", ReplyAction="*")]
        System.Threading.Tasks.Task<int> ModificarSocioAsync(int codigoSocio, string nombre, string primerApellido, string segundoApellido, string direccion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/EliminarSocio", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int EliminarSocio(int codigoSocio);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/EliminarSocio", ReplyAction="*")]
        System.Threading.Tasks.Task<int> EliminarSocioAsync(int codigoSocio);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ContarPrestamosSocio", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable ContarPrestamosSocio(int codigoSocio);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ContarPrestamosSocio", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataTable> ContarPrestamosSocioAsync(int codigoSocio);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AgregarSocio", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int AgregarSocio(string nombre, string primerApellido, string segundoApellido, string direccion, bool estado, string clave);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AgregarSocio", ReplyAction="*")]
        System.Threading.Tasks.Task<int> AgregarSocioAsync(string nombre, string primerApellido, string segundoApellido, string direccion, bool estado, string clave);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ModificarEstadoSocio", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int ModificarEstadoSocio(int codigoSocio, bool estado);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ModificarEstadoSocio", ReplyAction="*")]
        System.Threading.Tasks.Task<int> ModificarEstadoSocioAsync(int codigoSocio, bool estado);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="HistorialSocio", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class HistorialSocioRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public int codigoSocio;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<bool> estado;
        
        public HistorialSocioRequest() {
        }
        
        public HistorialSocioRequest(int codigoSocio, System.Nullable<bool> estado) {
            this.codigoSocio = codigoSocio;
            this.estado = estado;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="HistorialSocioResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class HistorialSocioResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public System.Data.DataTable HistorialSocioResult;
        
        public HistorialSocioResponse() {
        }
        
        public HistorialSocioResponse(System.Data.DataTable HistorialSocioResult) {
            this.HistorialSocioResult = HistorialSocioResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface LibraryWebServiceSoapChannel : LibraryApp.LibraryWS.LibraryWebServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LibraryWebServiceSoapClient : System.ServiceModel.ClientBase<LibraryApp.LibraryWS.LibraryWebServiceSoap>, LibraryApp.LibraryWS.LibraryWebServiceSoap {
        
        public LibraryWebServiceSoapClient() {
        }
        
        public LibraryWebServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public LibraryWebServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LibraryWebServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LibraryWebServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataTable VerificarBibliotecario(string usuario, string clave) {
            return base.Channel.VerificarBibliotecario(usuario, clave);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> VerificarBibliotecarioAsync(string usuario, string clave) {
            return base.Channel.VerificarBibliotecarioAsync(usuario, clave);
        }
        
        public int InsertarLibro(string titulo, string autor, bool disponibilidad, int codigoUbicacion) {
            return base.Channel.InsertarLibro(titulo, autor, disponibilidad, codigoUbicacion);
        }
        
        public System.Threading.Tasks.Task<int> InsertarLibroAsync(string titulo, string autor, bool disponibilidad, int codigoUbicacion) {
            return base.Channel.InsertarLibroAsync(titulo, autor, disponibilidad, codigoUbicacion);
        }
        
        public int ModificarLibro(int codigoLibro, string titulo, string autor, bool disponibilidad, int codigoUbicacion) {
            return base.Channel.ModificarLibro(codigoLibro, titulo, autor, disponibilidad, codigoUbicacion);
        }
        
        public System.Threading.Tasks.Task<int> ModificarLibroAsync(int codigoLibro, string titulo, string autor, bool disponibilidad, int codigoUbicacion) {
            return base.Channel.ModificarLibroAsync(codigoLibro, titulo, autor, disponibilidad, codigoUbicacion);
        }
        
        public int EliminarLibro(int codigoLibro) {
            return base.Channel.EliminarLibro(codigoLibro);
        }
        
        public System.Threading.Tasks.Task<int> EliminarLibroAsync(int codigoLibro) {
            return base.Channel.EliminarLibroAsync(codigoLibro);
        }
        
        public System.Data.DataTable UbicarLibro(int codigoLibro) {
            return base.Channel.UbicarLibro(codigoLibro);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> UbicarLibroAsync(int codigoLibro) {
            return base.Channel.UbicarLibroAsync(codigoLibro);
        }
        
        public System.Data.DataTable BuscarLibros() {
            return base.Channel.BuscarLibros();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> BuscarLibrosAsync() {
            return base.Channel.BuscarLibrosAsync();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        LibraryApp.LibraryWS.HistorialSocioResponse LibraryApp.LibraryWS.LibraryWebServiceSoap.HistorialSocio(LibraryApp.LibraryWS.HistorialSocioRequest request) {
            return base.Channel.HistorialSocio(request);
        }
        
        public System.Data.DataTable HistorialSocio(int codigoSocio, System.Nullable<bool> estado) {
            LibraryApp.LibraryWS.HistorialSocioRequest inValue = new LibraryApp.LibraryWS.HistorialSocioRequest();
            inValue.codigoSocio = codigoSocio;
            inValue.estado = estado;
            LibraryApp.LibraryWS.HistorialSocioResponse retVal = ((LibraryApp.LibraryWS.LibraryWebServiceSoap)(this)).HistorialSocio(inValue);
            return retVal.HistorialSocioResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<LibraryApp.LibraryWS.HistorialSocioResponse> LibraryApp.LibraryWS.LibraryWebServiceSoap.HistorialSocioAsync(LibraryApp.LibraryWS.HistorialSocioRequest request) {
            return base.Channel.HistorialSocioAsync(request);
        }
        
        public System.Threading.Tasks.Task<LibraryApp.LibraryWS.HistorialSocioResponse> HistorialSocioAsync(int codigoSocio, System.Nullable<bool> estado) {
            LibraryApp.LibraryWS.HistorialSocioRequest inValue = new LibraryApp.LibraryWS.HistorialSocioRequest();
            inValue.codigoSocio = codigoSocio;
            inValue.estado = estado;
            return ((LibraryApp.LibraryWS.LibraryWebServiceSoap)(this)).HistorialSocioAsync(inValue);
        }
        
        public System.Data.DataTable BuscarPrestamosTodo() {
            return base.Channel.BuscarPrestamosTodo();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> BuscarPrestamosTodoAsync() {
            return base.Channel.BuscarPrestamosTodoAsync();
        }
        
        public int InsertarPrestamo(int codigoSocio, int codigoLibro, System.DateTime fechaPrestamo, bool estado) {
            return base.Channel.InsertarPrestamo(codigoSocio, codigoLibro, fechaPrestamo, estado);
        }
        
        public System.Threading.Tasks.Task<int> InsertarPrestamoAsync(int codigoSocio, int codigoLibro, System.DateTime fechaPrestamo, bool estado) {
            return base.Channel.InsertarPrestamoAsync(codigoSocio, codigoLibro, fechaPrestamo, estado);
        }
        
        public int ModificarPrestamo(int codigoPrestamo, int codigoSocio, int codigoLibro, System.DateTime fechaPrestamo, bool estado) {
            return base.Channel.ModificarPrestamo(codigoPrestamo, codigoSocio, codigoLibro, fechaPrestamo, estado);
        }
        
        public System.Threading.Tasks.Task<int> ModificarPrestamoAsync(int codigoPrestamo, int codigoSocio, int codigoLibro, System.DateTime fechaPrestamo, bool estado) {
            return base.Channel.ModificarPrestamoAsync(codigoPrestamo, codigoSocio, codigoLibro, fechaPrestamo, estado);
        }
        
        public int EliminarPrestamo(int codigoPrestamo) {
            return base.Channel.EliminarPrestamo(codigoPrestamo);
        }
        
        public System.Threading.Tasks.Task<int> EliminarPrestamoAsync(int codigoPrestamo) {
            return base.Channel.EliminarPrestamoAsync(codigoPrestamo);
        }
        
        public System.Data.DataTable ComprobarSocio(int codigoSocio) {
            return base.Channel.ComprobarSocio(codigoSocio);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> ComprobarSocioAsync(int codigoSocio) {
            return base.Channel.ComprobarSocioAsync(codigoSocio);
        }
        
        public System.Data.DataTable VerificarSocio(int codigoSocio, string clave) {
            return base.Channel.VerificarSocio(codigoSocio, clave);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> VerificarSocioAsync(int codigoSocio, string clave) {
            return base.Channel.VerificarSocioAsync(codigoSocio, clave);
        }
        
        public System.Data.DataTable BuscarSocio(int codigoSocio) {
            return base.Channel.BuscarSocio(codigoSocio);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> BuscarSocioAsync(int codigoSocio) {
            return base.Channel.BuscarSocioAsync(codigoSocio);
        }
        
        public System.Data.DataTable BuscarSocioTodo() {
            return base.Channel.BuscarSocioTodo();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> BuscarSocioTodoAsync() {
            return base.Channel.BuscarSocioTodoAsync();
        }
        
        public int ModificarSocio(int codigoSocio, string nombre, string primerApellido, string segundoApellido, string direccion) {
            return base.Channel.ModificarSocio(codigoSocio, nombre, primerApellido, segundoApellido, direccion);
        }
        
        public System.Threading.Tasks.Task<int> ModificarSocioAsync(int codigoSocio, string nombre, string primerApellido, string segundoApellido, string direccion) {
            return base.Channel.ModificarSocioAsync(codigoSocio, nombre, primerApellido, segundoApellido, direccion);
        }
        
        public int EliminarSocio(int codigoSocio) {
            return base.Channel.EliminarSocio(codigoSocio);
        }
        
        public System.Threading.Tasks.Task<int> EliminarSocioAsync(int codigoSocio) {
            return base.Channel.EliminarSocioAsync(codigoSocio);
        }
        
        public System.Data.DataTable ContarPrestamosSocio(int codigoSocio) {
            return base.Channel.ContarPrestamosSocio(codigoSocio);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> ContarPrestamosSocioAsync(int codigoSocio) {
            return base.Channel.ContarPrestamosSocioAsync(codigoSocio);
        }
        
        public int AgregarSocio(string nombre, string primerApellido, string segundoApellido, string direccion, bool estado, string clave) {
            return base.Channel.AgregarSocio(nombre, primerApellido, segundoApellido, direccion, estado, clave);
        }
        
        public System.Threading.Tasks.Task<int> AgregarSocioAsync(string nombre, string primerApellido, string segundoApellido, string direccion, bool estado, string clave) {
            return base.Channel.AgregarSocioAsync(nombre, primerApellido, segundoApellido, direccion, estado, clave);
        }
        
        public int ModificarEstadoSocio(int codigoSocio, bool estado) {
            return base.Channel.ModificarEstadoSocio(codigoSocio, estado);
        }
        
        public System.Threading.Tasks.Task<int> ModificarEstadoSocioAsync(int codigoSocio, bool estado) {
            return base.Channel.ModificarEstadoSocioAsync(codigoSocio, estado);
        }
    }
}
