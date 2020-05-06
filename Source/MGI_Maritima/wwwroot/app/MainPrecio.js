new Vue({

    el: "#app",
    data: {
        DataPrecios:[],
        addPrecio: 0,
        IdArticulo: 0
    },
    methods: { 
        removeRow: function (index) {


            this.DataPrecios.splice(index, 1);
             this.SetData()

        }, addRow: function () {
            this.DataPrecios.push({
                id: null,
                precio: this.addPrecio,
                idArticulo: this.IdArticulo
            })
            this.addPrecio = 0
            this.SetData()
        },

        CallData: function () {

            axios.get('/Precios/Get', {
            params: {
                    ID: $("#id").val()
            }
        }).then(response => (this.DataPrecios = response.data.data))            
                .catch(function (error) {
                    console.log(error);
                });

        },
        SetIds: function () {
            this.IdArticulo = $("#id").val()
        },
        SetData: function () {
            $("#DataPrecio").val(JSON.stringify(this.DataPrecios))
             
        }
    }, mounted() {
        this.CallData()
        this.SetIds()
    }

});