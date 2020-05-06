new Vue({

    el: "#app",
    data: {
        DatoReporte: [] 
    },
    methods: { 

        CallData: function () {

            axios.get('/Inventario/Get').then(response => (this.DatoReporte = response.data.data))
                .catch(function (error) {
                    console.log(error);
                });

        } 
    }, mounted() {
        this.CallData()
        
    }

});