<template>
  <div>
    <v-toolbar color="white" flat>
        <v-btn icon light>
          <v-icon @click="goback">arrow_back</v-icon>
        </v-btn>

        <v-toolbar-title class="grey--text text--darken-4">{{ title }}</v-toolbar-title>
    </v-toolbar>

      <v-container style='background-color: white;' grid-list-sm class="pa-4">
        <div class="xs6">
          <v-form ref="form">
            <v-layout id="fields" row wrap>
              <v-flex xs12>
                <v-text-field v-model="model.Name" label="Nome" :validate-on-blur='true' :rules="[(v) => !!v || 'Esse campo é obrigatório']"></v-text-field>
              </v-flex>
              <v-flex xs12>
                <v-text-field v-model="model.Email" label="Email" :validate-on-blur='true' :rules="[(v) => /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(v) || 'E-mail inválido']"></v-text-field>
              </v-flex>
              <v-flex xs12>
                <v-text-field v-model="model.AcademicTitle" label="Título" :validate-on-blur='true' :rules="[(v) => !!v || 'Esse campo é obrigatório']"></v-text-field>
              </v-flex>
              <v-flex xs12>
              <br>
              <p>Grupos do Usuário</p>
              </v-flex>
              <v-flex xs4>
                <v-switch v-model="model.Administrator" label="Administrador"></v-switch>
              </v-flex>
              <v-flex xs4>
                <v-switch v-model="model.Coordinator" label="Coordenador"></v-switch>
              </v-flex>
              <v-flex xs4>
                <v-switch v-model="model.Professor" label="Professor"></v-switch>
              </v-flex>
            </v-layout>
            <br>
          </v-form>
          <v-btn v-if="parseInt(this.id) > 0" color="warning" @click="edit">Salvar</v-btn>
          <v-btn v-else color="success" @click="create">Salvar</v-btn>
        </div>
      </v-container>


    <v-snackbar v-model="snackbar"
      :multi-line="true"
      color="red"
      :timeout="5000"
    >
      Selecione pelo menos um grupo para o usuário
      <v-btn dark flat @click="snackbar = false">
        Ok
      </v-btn>
    </v-snackbar>
  </div>
</template>

<script>
  import {User} from "../../scripts/api_user"
  var api = new User();

  export default {
    name: 'userDetails',
    props: {
        id: String
    },
    data: function() {
        return {
          title: "Usuário",
          gobackUrl: "/user",
          snackbar: false,
          model: {
            Id: 0,
            Name: '',
            Email: '',
            AcademicTitle: '',
            Administrator: false,
            Coordinator: false,
            Professor: false
          }
        }
    },
    created() {
      if(parseInt(this.id) > 0)
      {
        this.getItem(parseInt(this.id));
      }
    },
    methods: {
      create: function() {
        var isValid = this.$refs.form.validate();

        if(!this.model.Administrator && !this.model.Professor && !this.model.Coordinator)
        {
          this.snackbar = true;
          isValid = false;
        }
        
        if(!isValid) return;

        var vm = this;
        api.post({ 
          data: this.model,
          success: () => { 
            alert("Item salvo com sucesso");
            vm.$router.push(vm.gobackUrl);
          }
        });
      },
      edit: function() {
        var isValid = this.$refs.form.validate();

        if(!this.model.Administrator && !this.model.Professor && !this.model.Coordinator)
        {
          this.snackbar = true;
          isValid = false;
        }
        
        if(!isValid) return;

        var vm = this;
        api.put({
          data: this.model, 
          path_params: [this.model.Id],
          success: () => { 
            alert("Item editado com sucesso");
            vm.$router.push(vm.gobackUrl);
          }
        });
      },
      getItem: function(id) {
        var vm = this;
        api.get({ path_params: [id], success: (data) => { vm.model = data; } });
      },
      goback: function() {
        this.$router.push(this.gobackUrl);
      }
    }
  }
</script>