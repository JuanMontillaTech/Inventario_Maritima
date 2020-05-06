new Vue({

    el: "#app",
    data: {
        DataArticulos: [],
        DataAlmacen: [],
        DataPrecio: [],
        DataInventario: [],
        SelectAlmacen: '',
        SelectArticulo: '',
        SelectAccion: '1',
        CantidadInt: '',
         SendData: ''
     },
    methods: { 
        CallData: function () {

            axios.get('/Ubicacion/GetAll').then(response => (this.DataAlmacen = response.data.data))
                .catch(function (error) {
                    console.log(error);
                });
            axios.get('/Articulo/GetAll').then(response => (this.DataArticulos = response.data.data))
                .catch(function (error) {
                    console.log(error);
                });
            this.GetDataInventario()

        },
        GetDataInventario: function () {
            axios.get('/Inventario/GetAll').then(response => (this.DataInventario = response.data.data))
                .catch(function (error) {
                    console.log(error);
                });
        },
        SetAccion: function () {
            const _DataPrecio = {
                id: null,
                idalmacen: this.SelectAlmacen,
                idarticulo: this.SelectArticulo,
                cantidad: this.CantidadInt,
                Accion: this.SelectAccion
            };
 
            this.SendData = JSON.stringify(_DataPrecio) 
            axios.post('/Inventario/PostInvenario/?data=' + this.SendData).then(function (response) { 
                 
                toastr.success(response.data.message);
                 
                
               
            }).catch(function (response) {
                toastr.error(response.message);
            });
          
           
        },
        CallUbicacion: function (id) {
            var result = this.DataAlmacen.filter(x => x.id == id)            
            if (result.length > 0) {
                return result[0].descripcion
            } else {
                return "No encontrado"
            }

        },
        CallArticulo: function (id) {
            var result1 = this.DataArticulos.filter(x => x.id == id)
             
            if (result1.length > 0) {
                return result1[0].nombre
            } else {
                return "No encontrado"
            }
          
          
        },
    }, mounted() {
        this.CallData()
         
    }

});